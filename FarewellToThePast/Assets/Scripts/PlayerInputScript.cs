using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInputScript : MonoBehaviour
{
    ShipControl shipControl;

    void Start()
    {
        // TODO: Import ship properties from selected ship
        shipControl = GetComponent<ShipControl>();
    }

    void FixedUpdate()
    {
        readAcceleration();
        readPitch();
        readYaw();
        readShot();
    }

    private void readAcceleration()
    {
        if (IsThrottleUpPressed())
        {
            shipControl.Accel();
        }
        else if (IsThrottleDownPressed())
        {
            shipControl.Reverse();
        }
    }

    private void readPitch()
    {
        if (IsPitchUpPressed())
        {
            shipControl.UpRotation();
        }
        else if (IsPitchDownPressed())
        {
            shipControl.DownRotation();
        }
        else
        {
            shipControl.NoVerticalRotation();
        }
    }

    private void readYaw()
    {
        if (IsYawLeftPressed())
        {
            shipControl.LeftRotation();
        }
        else if (IsYawRightPressed())
        {
            shipControl.RightRotation();
        }
        else
        {
            shipControl.NoHorizontalRotation();
        }
    }

    private void readShot()
    {
        if (IsShotPressed())
        {
            shipControl.Shot();
        }
    }

    abstract protected bool IsPitchDownPressed();
    abstract protected bool IsPitchUpPressed();
    abstract protected bool IsShotPressed();
    abstract protected bool IsThrottleUpPressed();
    abstract protected bool IsThrottleDownPressed();
    abstract protected bool IsYawLeftPressed();
    abstract protected bool IsYawRightPressed();
}
