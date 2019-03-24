using UnityEngine;
using System.Collections;

public class PlayerMouseInputScript : PlayerInputScript
{
    protected override bool IsPitchDownPressed()
    {
        return Input.GetAxisRaw("Mouse Y") > 0;
    }
    protected override bool IsPitchUpPressed()
    {
        return Input.GetAxisRaw("Mouse Y") < 0;
    }

    protected override bool IsShotPressed()
    {
        return Input.GetMouseButton(0);
    }

    protected override bool IsThrottleDownPressed()
    {
        return Input.GetAxisRaw("Mouse ScrollWheel") > 0;
    }

    protected override bool IsThrottleUpPressed()
    {
        return Input.GetAxisRaw("Mouse ScrollWheel") < 0;
    }

    protected override bool IsYawLeftPressed()
    {
        return Input.GetAxisRaw("Mouse X") < 0;
    }

    protected override bool IsYawRightPressed()
    {
        return Input.GetAxisRaw("Mouse X") > 0;
    }
}
