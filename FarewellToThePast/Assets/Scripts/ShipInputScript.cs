using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInputScript : MonoBehaviour
{
    const float ACCELERATION = 0.01f;
    const float MAX_ACCELERATION = 0.50f;

    ShipControl shipControl;
    float speed;
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
        // Acceleration
        if (Input.GetKey(KeyCode.Q) && MAX_ACCELERATION > speed) {
            speed += ACCELERATION;
        } else if (Input.GetKey(KeyCode.E) && MAX_ACCELERATION > -speed) {
            speed -= ACCELERATION;
        }
        shipControl.Accel(speed);

        // Vertical PAN
        if (Input.GetKey(KeyCode.W)) {
            shipControl.UpPan();
        } else if (Input.GetKey(KeyCode.S)) {
            shipControl.DownPan();
        }

        // Horizontal PAN
        if (Input.GetKey(KeyCode.A)) {
            shipControl.LeftPan();
        } else if (Input.GetKey(KeyCode.D)) {
            shipControl.RightPan();
        }

        // Vertical Rotation
        if (Input.GetKey(KeyCode.I)) {
            shipControl.UpRotation();
        } else if (Input.GetKey(KeyCode.K)) {
            shipControl.DownRotation();
        }

        // Horizontal Rotation
        if (Input.GetKey(KeyCode.J)) {
            shipControl.LeftRotation();
        } else if (Input.GetKey(KeyCode.L)) {
            shipControl.RightRotation();
        }
    }
}
