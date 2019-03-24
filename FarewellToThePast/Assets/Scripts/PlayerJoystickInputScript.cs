using UnityEngine;
using System.Collections;

public class PlayerJoystickInputScript : PlayerInputScript
{
    protected override bool IsPitchDownPressed()
    {
        return Input.GetAxisRaw("Vertical") > 0;
    }
    protected override bool IsPitchUpPressed()
    {
        return Input.GetAxisRaw("Vertical") < 0;
    }

    protected override bool IsShotPressed()
    {
        return Input.GetKey(KeyCode.JoystickButton2);
    }

    protected override bool IsThrottleDownPressed()
    {
        return Input.GetKey(KeyCode.JoystickButton7);
    }

    protected override bool IsThrottleUpPressed()
    {
        return Input.GetKey(KeyCode.JoystickButton6);
    }

    protected override bool IsYawLeftPressed()
    {
        return Input.GetAxisRaw("Horizontal") < 0;
    }

    protected override bool IsYawRightPressed()
    {
        return Input.GetAxisRaw("Horizontal") > 0;
    }
}
