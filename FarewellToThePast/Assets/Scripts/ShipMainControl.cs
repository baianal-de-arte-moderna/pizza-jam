using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMainControl : MonoBehaviour
{
    const float DEFAULT_ACCELERATION = 0.01f;
    const float MAX_THRUSTER_SPEED = 0.50f;
    const float FORWARD_SPEED_LIMIT = 100f;
    const float BACKWARD_SPEED_LIMIT = -FORWARD_SPEED_LIMIT;

    const float DEFAULT_MANEUVER_SPEED = 1f;

    new Transform transform;
    new Rigidbody rigidbody;

    float forwardVelocity;
    float forwardThrusterSpeed;
    float backwardThrusterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        forwardVelocity = 0f;
        forwardThrusterSpeed = 0f;
        backwardThrusterSpeed = 0f;
    }

    private void Update()
    {
        if (Mathf.Approximately(forwardVelocity, 0))
        {

        }
        else
        {

        }
    }

    // Z-Axis functions
    public void Accel(float acceleration = DEFAULT_ACCELERATION) {
        forwardThrusterSpeed = Mathf.Min(forwardThrusterSpeed + acceleration, MAX_THRUSTER_SPEED);
        backwardThrusterSpeed = 0f;

        forwardVelocity = Mathf.Min(forwardVelocity + forwardThrusterSpeed, FORWARD_SPEED_LIMIT);
        rigidbody.velocity = transform.forward * forwardVelocity;
    }

    public void Reverse(float acceleration = DEFAULT_ACCELERATION) {
        forwardThrusterSpeed = 0f;
        backwardThrusterSpeed = Mathf.Min(backwardThrusterSpeed + acceleration, MAX_THRUSTER_SPEED);

        forwardVelocity = Mathf.Max(forwardVelocity - backwardThrusterSpeed, BACKWARD_SPEED_LIMIT);
        rigidbody.velocity = transform.forward * forwardVelocity;
    }

    // X-Axis functions
    public void LeftRotation(float speed = DEFAULT_MANEUVER_SPEED) {
        transform.Rotate(Vector3.up * -speed);
    }

    public void RightRotation(float speed = DEFAULT_MANEUVER_SPEED) {
        transform.Rotate(Vector3.up * speed);
    }

    // Y-Axis functions
    public void UpRotation(float speed = DEFAULT_MANEUVER_SPEED) {
        transform.Rotate(Vector3.right * -speed);
    }

    public void DownRotation(float speed = DEFAULT_MANEUVER_SPEED) {
        transform.Rotate(Vector3.right * speed);
    }
}
