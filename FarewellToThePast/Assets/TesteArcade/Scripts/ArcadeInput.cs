using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeInput : MonoBehaviour
{
    public TextAsset joypadConfiguration;
    public Dictionary<string, KeyCode> inputCommands;
    // Start is called before the first frame update
    void Start()
    {
        inputCommands = new Dictionary<string, KeyCode>();
        // Clear commands
        ClearCommands();

        // TODO: name check
        //var names = Input.GetJoystickNames();
        //foreach (var name in names)
        //{
        //    Debug.Log(name);
        //}

        var joypadConfigurationLines = joypadConfiguration.text.Split('\n');
        foreach (string line in joypadConfigurationLines) {
            var joypadConfigurationWords = line.Split('-', '=');
            if (joypadConfigurationWords.Length != 3 ||
                joypadConfigurationWords[0] != StaticConstants.PLAYER1_ID ||
                ! inputCommands.ContainsKey(joypadConfigurationWords[1])) {
                    continue;
                }
                inputCommands[joypadConfigurationWords[1]] = StaticConstants.StringToKey(joypadConfigurationWords[2]);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(inputCommands[StaticConstants.CMD_FORWARD])) {
            Debug.Log("Accelerating");
        }

        if (Input.GetKey(inputCommands[StaticConstants.CMD_BRAKE])) {
            Debug.Log("Braking");
        }

        if (Input.GetKey(inputCommands[StaticConstants.CMD_LEFT])) {
            Debug.Log("Left");
        }

        if (Input.GetKey(inputCommands[StaticConstants.CMD_RIGHT])) {
            Debug.Log("Right");
        }

        if (Input.GetKey(inputCommands[StaticConstants.CMD_UP])) {
            Debug.Log("Up");
        }

        if (Input.GetKey(inputCommands[StaticConstants.CMD_DOWN])) {
            Debug.Log("Down");
        }
    }

    void ClearCommands() {
        foreach (string command in StaticConstants.CMD_LIST) {
            inputCommands[command] = KeyCode.None;
        }
    }
}
