using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public delegate void OverlayCallback();
public class InputOverlayScript : MonoBehaviour
{
    bool working;
    public event OverlayCallback overlayCallback;
    string path = "Assets/TesteArcade/Text/JoypadConfiguration.txt";
    string player = "p1";
    string command = "";
    Dictionary<string, string> commandMap;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        commandMap = new Dictionary<string, string>();

        StreamReader reader = new StreamReader(path); 
        var joypadConfiguration = reader.ReadToEnd();
        reader.Close();

        var joypadConfigurationLines = joypadConfiguration.Split(System.Environment.NewLine.ToCharArray());
        foreach (string line in joypadConfigurationLines) {
            var joypadConfigurationWords = line.Split('=');
            if (joypadConfigurationWords.Length == 2) {
                commandMap[joypadConfigurationWords[0]] = joypadConfigurationWords[1];
            }
        }
        working = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (working) {
            foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
                if(Input.GetKeyDown(vKey)){
                    working = false;
                    SaveKey(vKey.ToString());
                    SaveFile();
                    break;
                }
            }
        }
    }

    public void SetCommand(string cmd) {
        command = cmd;
    }

    public void SetPlayer(string p) {
        player = p;
    }

    public void SaveKey(string key) {
        commandMap[player + '-' + command] = key;
    }

    public void SaveFile() {
        StreamWriter writer = new StreamWriter(path, false);
        foreach(KeyValuePair<string, string> entry in commandMap)
        {
            writer.WriteLine(entry.Key + "=" + entry.Value);
        }
        writer.Close();
        if (overlayCallback != null) {
            overlayCallback();
        }
        overlayCallback = null;
    }
}
