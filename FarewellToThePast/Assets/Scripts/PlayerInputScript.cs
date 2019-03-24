using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    const float ACCELERATION = 0.01f;
    const float MAX_ACCELERATION = 0.50f;

    ShipControl shipControl;
    float speed;
    [SerializeField]
    private KeyCode yawLeft;
    [SerializeField]
    private KeyCode yawRight;
    [SerializeField]
    private KeyCode pitchUp;
    [SerializeField]
    private KeyCode pitchDown;
    [SerializeField]
    private KeyCode throttleUp;
    [SerializeField]
    private KeyCode throttleDown;
    [SerializeField]
    private KeyCode shot;

    public PlayerInputScript(KeyCode yawLeft, KeyCode yawRight, KeyCode pitchUp, KeyCode pitchDown, KeyCode throttleUp, KeyCode throttleDown, KeyCode shot)
    {
        this.yawLeft = yawLeft;
        this.yawRight = yawLeft;
        this.pitchUp = pitchUp;
        this.pitchDown = pitchDown;
        this.throttleUp = throttleUp;
        this.throttleDown = throttleDown;
        this.shot = shot;
    }

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Import ship properties from selected ship
        shipControl = GetComponent<ShipControl>();
        speed = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        readAcceleration();
        readPitch();
        readYaw();
        readShot();
    }

    private void readAcceleration()
    {
        if (Input.GetKey(throttleUp) && MAX_ACCELERATION > speed)
        {
            speed += ACCELERATION;
        }
        else if (Input.GetKey(throttleDown) && MAX_ACCELERATION > -speed)
        {
            speed -= ACCELERATION;
        }
        shipControl.Accel(speed);
    }

    private void readPitch()
    {
        if (Input.GetKey(pitchUp))
        {
            shipControl.UpRotation();
        }
        else if (Input.GetKey(pitchDown))
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
        if (Input.GetKey(yawLeft))
        {
            shipControl.LeftRotation();
        }
        else if (Input.GetKey(yawRight))
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
        if (Input.GetKeyDown(shot))
        {
            shipControl.Shot();
        }
    }
}
