﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    const float DEFAULT_MOVE_SPEED = 0.2f;
    const float DEFAULT_MANEUVER_SPEED = 1f;
    ShipPanControl ship_pan_control;
    ShipMainControl ship_main_control;
    // Start is called before the first frame update
    void Start()
    {
        ship_main_control = GetComponent<ShipMainControl>();
        ship_pan_control = GetComponentInChildren<ShipPanControl>();
    }
    
    // Z-Axis functions
    public void Accel(float speed=DEFAULT_MOVE_SPEED) {
        ship_main_control.Accel(speed);
    }

    public void Reverse(float speed=DEFAULT_MOVE_SPEED) {
        ship_main_control.Reverse(speed);
    }

    // X-Axis functions
    public void LeftPan(float speed=DEFAULT_MOVE_SPEED) {
        ship_pan_control.LeftPan(speed);
    }

    public void RightPan(float speed=DEFAULT_MOVE_SPEED) {
        ship_pan_control.RightPan(speed);
    }

    public void LeftRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        ship_main_control.LeftRotation(speed);
        ship_pan_control.LeftRoll();
    }

    public void RightRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        ship_main_control.RightRotation(speed);
        ship_pan_control.RightRoll();
    }

    public void NoHorizontalRotation() {
        ship_pan_control.FixHorizontalRoll();
    }

    // Y-Axis functions
    public void UpPan(float speed=DEFAULT_MOVE_SPEED) {
        ship_pan_control.UpPan(speed);
    }

    public void DownPan(float speed=DEFAULT_MOVE_SPEED) {
        ship_pan_control.DownPan(speed);
    }

    public void UpRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        ship_main_control.UpRotation(speed);
        ship_pan_control.UpRoll();
    }

    public void DownRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        ship_main_control.DownRotation(speed);
        ship_pan_control.DownRoll();
    }

    public void NoVerticalRotation() {
        ship_pan_control.FixVerticalRoll();
    }
}
