using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour
{
    [SerializeField]
    public GameObject ship;

    ShipPanControl ship_pan_control;
    ShipMainControl ship_main_control;
    ShipShotScript ship_shot_control;

    // Start is called before the first frame update
    void Start()
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
    public void Accel()
    {
        ship_main_control.Accel();
    }

    public void Reverse()
    {
        ship_main_control.Reverse();
    }

    // X-Axis functions
    public void LeftPan() {
        ship_pan_control.LeftPan();
    }

    public void RightPan() {
        ship_pan_control.RightPan();
    }

    public void LeftRotation() {
        ship_main_control.LeftRotation();
        ship_pan_control.LeftRoll();
    }

    public void RightRotation() {
        ship_main_control.RightRotation();
        ship_pan_control.RightRoll();
    }

    public void NoHorizontalRotation() {
        ship_pan_control.FixHorizontalRoll();
    }

    // Y-Axis functions
    public void UpPan() {
        ship_pan_control.UpPan();
    }

    public void DownPan() {
        ship_pan_control.DownPan();
    }

    public void UpRotation() {
        ship_main_control.UpRotation();
        ship_pan_control.UpRoll();
    }

    public void DownRotation() {
        ship_main_control.DownRotation();
        ship_pan_control.DownRoll();
    }

    public void NoVerticalRotation() {
        ship_pan_control.FixVerticalRoll();
    }

    // Shot controls
    public void Shot() {
        ship_shot_control.Shot();
    }
}
