using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour
{
    const float DEFAULT_MOVE_SPEED = 10f;
    const float DEFAULT_MANEUVER_SPEED = 1f;

    [SerializeField]
    GameObject ship;

    ShipPanControl ship_pan_control;
    ShipMainControl ship_main_control;
    ShipShotScript ship_shot_control;

    // Start is called before the first frame update
    void Awake()
    {
        if (ship)
        {
            GameObject shipClone = Instantiate(ship, transform);
        }

        ship_main_control = GetComponent<ShipMainControl>();
        ship_pan_control = GetComponentInChildren<ShipPanControl>();
        ship_shot_control = GetComponentInChildren<ShipShotScript>();
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

    // Shot controls
    public void Shot() {
        if (ship_shot_control != null)
            ship_shot_control.Shot();
        else
            ship_shot_control = GetComponentInChildren<ShipShotScript>();
    }
}
