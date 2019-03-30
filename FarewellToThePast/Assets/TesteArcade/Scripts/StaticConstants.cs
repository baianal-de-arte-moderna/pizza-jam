using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticConstants
{
    // Player references
    public static string PLAYER1_ID = "p1";
    public static string PLAYER2_ID = "p2";
    public static string PLAYER3_ID = "p3"; 
    public static string PLAYER4_ID = "p4";
    public static string PLAYER5_ID = "p5";
    public static string PLAYER6_ID = "p6";
    public static string PLAYER7_ID = "p7";
    public static string PLAYER8_ID = "p8";

    // Command References
    public static string CMD_FORWARD = "Forward";
    public static string CMD_BRAKE = "Brake";
    public static string CMD_UP = "Up";
    public static string CMD_DOWN = "Down";
    public static string CMD_LEFT = "Left";
    public static string CMD_RIGHT = "Right";
    public static string[] CMD_LIST = {
        CMD_FORWARD,
        CMD_BRAKE,
        CMD_UP,
        CMD_DOWN,
        CMD_LEFT,
        CMD_RIGHT
    };

    // Key association
    public static KeyCode StringToKey(string text) {
        try {
            return (KeyCode) System.Enum.Parse(typeof(KeyCode), text);
        } catch (ArgumentException) {
            return KeyCode.None;
        }
    }
}
