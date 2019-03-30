using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class ConfigureInputScript : MonoBehaviour
{
    string path = "Assets/TesteArcade/Text/JoypadConfiguration.txt";
    EventSystem eventSystem;
    public GameObject overlayPanel;
    Dictionary<string, Text> inputTexts;
    GameObject lastSelectedObject;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        inputTexts = new Dictionary<string, Text>();
        foreach (string command in StaticConstants.CMD_LIST) {
            inputTexts[command] = transform.Find(command + " Input").GetComponent<Text>();
        }

        ReoloadCommands();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReoloadCommands() {
        StreamReader reader = new StreamReader(path); 
        var joypadConfiguration = reader.ReadToEnd();
        reader.Close();

        var joypadConfigurationLines = joypadConfiguration.Split('\n');
        foreach (string line in joypadConfigurationLines) {
            var joypadConfigurationWords = line.Split('-', '=');
            if (joypadConfigurationWords.Length != 3 ||
                joypadConfigurationWords[0] != StaticConstants.PLAYER1_ID ||
                ! inputTexts.ContainsKey(joypadConfigurationWords[1])) {
                    continue;
                }
                inputTexts[joypadConfigurationWords[1]].text = StaticConstants.StringToKey(joypadConfigurationWords[2]).ToString();
        }
    }

    public void ChangeKey(string command) {
        eventSystem.enabled = false;
        lastSelectedObject = eventSystem.lastSelectedGameObject;
        overlayPanel.SetActive(true);
        overlayPanel.GetComponent<InputOverlayScript>().overlayCallback += EndKeyChange;
        overlayPanel.GetComponent<InputOverlayScript>().SetCommand(command);
    }

    public void EndKeyChange() {
        eventSystem.enabled = true;
        eventSystem.SetSelectedGameObject(lastSelectedObject);
        overlayPanel.SetActive(false);
        ReoloadCommands();
    }
}
