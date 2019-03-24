using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMainControl : MonoBehaviour
{
    const float SPEED_LIMIT = 100f;
    const float LERP_SPEED = 0.1f;
    const float DEFAULT_MOVE_SPEED = 10f;
    const float DEFAULT_MANEUVER_SPEED = 1f;
    Transform m_transform;
    new Rigidbody rigidbody;
    public Vector3 target_location;

    float forwardVelocity;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        target_location = m_transform.position;
        forwardVelocity = 0f;
    }
    
    // Z-Axis functions
    public void Accel(float speed=DEFAULT_MOVE_SPEED) {
        forwardVelocity = Mathf.Min(forwardVelocity + speed, SPEED_LIMIT);
        rigidbody.velocity = transform.forward * forwardVelocity;
    }

    public void Reverse(float speed=DEFAULT_MOVE_SPEED) {
        forwardVelocity = Mathf.Max(forwardVelocity - speed, SPEED_LIMIT);
        rigidbody.velocity = transform.forward * forwardVelocity;
    }

    // X-Axis functions
    public void LeftRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        m_transform.Rotate(Vector3.up * -speed);
    }

    public void RightRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        m_transform.Rotate(Vector3.up * speed);
    }

    // Y-Axis functions
    public void UpRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        m_transform.Rotate(Vector3.right * -speed);
    }

    public void DownRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        m_transform.Rotate(Vector3.right * speed);
    }
}
