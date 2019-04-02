using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeShipControl : MonoBehaviour
{
    new Rigidbody rigidbody;
    new Transform transform;
    Vector3 eulerAngleVelocity;
    float pitch;
    float yaw;
    Quaternion deltaRotation;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        eulerAngleVelocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidbody.drag > 1f) {
            rigidbody.drag = Mathf.Lerp(rigidbody.drag, 1f, 0.2f);
        }

        // Rotation
        eulerAngleVelocity.x = pitch;
        eulerAngleVelocity.y = yaw;
        eulerAngleVelocity.z = 0;
        deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);

        // Reset angles
        pitch = Mathf.Lerp(pitch, 0f, 0.1f);
        yaw = Mathf.Lerp(yaw, 0f, 0.1f);
    }

    public void Accel(float speed) {
        rigidbody.AddForce(transform.forward * speed);
    }

    public void Brake() {
        rigidbody.drag = 10f;
    }

    public void Up() {
        pitch = -100f;
    }
    public void Down() {
        pitch = 100f;
    }

    public void Left() {
        yaw = -100f;
    }

    public void Right() {
        yaw = 100f;
    }
}
