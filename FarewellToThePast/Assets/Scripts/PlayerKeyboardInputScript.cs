using UnityEngine;
using System.Collections;

public class PlayerKeyboardInputScript : PlayerInputScript
{
    [SerializeField]
    private KeyCode pitchDown;
    [SerializeField]
    private KeyCode pitchUp;
    [SerializeField]
    private KeyCode shot;
    [SerializeField]
    private KeyCode throttleDown;
    [SerializeField]
    private KeyCode throttleUp;
    [SerializeField]
    private KeyCode yawLeft;
    [SerializeField]
    private KeyCode yawRight;

    protected override bool IsPitchDownPressed()
    {
        return Input.GetKey(pitchDown);
    }

    protected override bool IsPitchUpPressed()
    {
        return Input.GetKey(pitchUp);
    }

    protected override bool IsShotPressed()
    {
        return Input.GetKey(shot);
    }

    protected override bool IsThrottleDownPressed()
    {
        return Input.GetKey(throttleDown);
    }

    protected override bool IsThrottleUpPressed()
    {
        return Input.GetKey(throttleUp);
    }

    protected override bool IsYawLeftPressed()
    {
        return Input.GetKey(yawLeft);
    }

    protected override bool IsYawRightPressed()
    {
        return Input.GetKey(yawRight);
    }
}
