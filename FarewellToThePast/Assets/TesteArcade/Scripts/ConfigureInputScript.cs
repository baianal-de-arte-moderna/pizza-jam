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
    public Text playerNameText;
    GameObject lastSelectedObject;
    int currentPlayer;
    bool changed;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        currentPlayer = 0;
        changed = false;
        inputTexts = new Dictionary<string, Text>();

        foreach (string command in StaticConstants.CMD_LIST) {
            inputTexts[command] = transform.Find(command + " Input").GetComponent<Text>();
        }

        ReoloadCommands();
    }

    // Update is called once per frame
    void Update()
    {
        if (!overlayPanel.activeSelf) {
            var horizontalMove = Input.GetAxis("Horizontal");
            if (horizontalMove > 0) {
                ChangePlayer(1);
            } else if (horizontalMove != 0) {
                ChangePlayer(-1);
            } else {
                changed = false;
            }
        }
    }

    void ChangePlayer(int change) {
        if (!changed) {
            changed = true;
            currentPlayer = (currentPlayer + change) % StaticConstants.PLAYER_LIST.Length;
            while (currentPlayer < 0) {
                currentPlayer += StaticConstants.PLAYER_LIST.Length;
            }
            ReoloadCommands();
            overlayPanel.GetComponent<InputOverlayScript>().SetPlayer(StaticConstants.PLAYER_LIST[currentPlayer]);
            playerNameText.text = "Player " + (currentPlayer + 1);
        }
    }

    void ReoloadCommands() {
        StreamReader reader = new StreamReader(path); 
        var joypadConfiguration = reader.ReadToEnd();
        reader.Close();

        foreach (string command in StaticConstants.CMD_LIST) {
            inputTexts[command].text = "None";
        }

        var joypadConfigurationLines = joypadConfiguration.Split('\n');
        foreach (string line in joypadConfigurationLines) {
            var joypadConfigurationWords = line.Split('-', '=');
            if (joypadConfigurationWords.Length != 3 ||
                joypadConfigurationWords[0] != StaticConstants.PLAYER_LIST[currentPlayer] ||
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
