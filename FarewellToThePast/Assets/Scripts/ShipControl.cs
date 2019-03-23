using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    const float LERP_SPEED = 0.1f;
    const float DEFAULT_MOVE_SPEED = 0.2f;
    const float DEFAULT_MANEUVER_SPEED = 1f;
    Transform m_transform;
    Vector3 target_location;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        target_location = m_transform.position;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        m_transform.position = Vector3.Lerp(m_transform.position, target_location, LERP_SPEED);
    }
    
    // Z-Axis functions
    public void Accel(float speed=DEFAULT_MOVE_SPEED) {
        target_location += m_transform.forward * speed;
    }

    public void Reverse(float speed=DEFAULT_MOVE_SPEED) {
        target_location -= m_transform.forward * speed;
    }

    // X-Axis functions
    public void LeftPan(float speed=DEFAULT_MOVE_SPEED) {
        target_location -= m_transform.right * speed;
    }

    public void RightPan(float speed=DEFAULT_MOVE_SPEED) {
        target_location += m_transform.right * speed;
    }

    public void LeftRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        m_transform.Rotate(Vector3.up * -speed);
    }

    public void RightRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        m_transform.Rotate(Vector3.up * speed);
    }

    // Y-Axis functions
    public void UpPan(float speed=DEFAULT_MOVE_SPEED) {
        target_location += m_transform.up * speed;
    }

    public void DownPan(float speed=DEFAULT_MOVE_SPEED) {
        target_location -= m_transform.up * speed;
    }

    public void UpRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        m_transform.Rotate(Vector3.right * -speed);
    }

    public void DownRotation(float speed=DEFAULT_MANEUVER_SPEED) {
        m_transform.Rotate(Vector3.right * speed);
    }
}
