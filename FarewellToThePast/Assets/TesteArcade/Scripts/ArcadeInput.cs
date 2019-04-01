using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeInput : MonoBehaviour
{
    public TextAsset joypadConfiguration;
    public Dictionary<string, KeyCode> inputCommands;
    public Dictionary<string, string> inputAxis;
    public Dictionary<string, char> inputDirections;
    // Start is called before the first frame update
    void Start()
    {
        inputCommands = new Dictionary<string, KeyCode>();
        inputAxis = new Dictionary<string, string>();
        inputDirections = new Dictionary<string, char>();
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
            var joypadConfigurationWords = line.Split('_', '=');
            if (joypadConfigurationWords.Length != 3) continue;

            var p = joypadConfigurationWords[0].Trim();
            var c = joypadConfigurationWords[1].Trim();
            var i = joypadConfigurationWords[2].Trim();
            if (p != StaticConstants.PLAYER1_ID ||
                !inputCommands.ContainsKey(c)) {
                    continue;
                }

                inputCommands[c] = StaticConstants.StringToKey(i);
                if (inputCommands[c] == KeyCode.None) {
                    inputAxis[c] = i.Substring(0, i.Length - 1);
                    inputDirections[c] = i[i.Length - 1];
                }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ProccessInput(StaticConstants.CMD_FORWARD)) {
            Debug.Log("Accelerating");
        }

        if (ProccessInput(StaticConstants.CMD_BRAKE)) {
            Debug.Log("Braking");
        }

        if (ProccessInput(StaticConstants.CMD_LEFT)) {
            Debug.Log("Left");
        }

        if (ProccessInput(StaticConstants.CMD_RIGHT)) {
            Debug.Log("Right");
        }

        if (ProccessInput(StaticConstants.CMD_UP)) {
            Debug.Log("Up");
        }

        if (ProccessInput(StaticConstants.CMD_DOWN)) {
            Debug.Log("Down");
        }
    }

    void ClearCommands() {
        foreach (string command in StaticConstants.CMD_LIST) {
            inputCommands[command] = KeyCode.None;
            inputAxis[command] = null;
            inputDirections[command] = '\0';
        }
    }

    bool ProccessButton(KeyCode button) {

        return false;
    }

    bool ProccessAxis(string axis, char direction) {
        return false;
    }

    bool ProccessInput(string cmd) 
    {
        if (inputAxis[cmd] != null)
        {
            var axisState = Input.GetAxis(inputAxis[cmd]);
            if (axisState == 0)
                return false;
            else if (inputDirections[cmd].Equals('+'))
                return (axisState > 0);
            else
                return (axisState < 0);
        }
        return Input.GetKey(inputCommands[cmd]);
    }
}
