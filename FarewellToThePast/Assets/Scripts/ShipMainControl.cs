using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMainControl : MonoBehaviour
{
    const float DEFAULT_ACCELERATION = 0.01f;
    const float MAX_THRUSTER_SPEED = 0.50f;
    const float FORWARD_SPEED_LIMIT = 100f;
    const float BACKWARD_SPEED_LIMIT = -FORWARD_SPEED_LIMIT;
    const float THRUSTER_ON_THRESHOLD = MAX_THRUSTER_SPEED * 0.1f;

    const float DEFAULT_MANEUVER_SPEED = 1f;

    new Transform transform;
    new Rigidbody rigidbody;
    ParticleSystem[] particles;

    float forwardVelocity;
    float forwardThrusterSpeed;
    float backwardThrusterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        particles = GetComponentsInChildren<ParticleSystem>();
        forwardVelocity = 0f;
        forwardThrusterSpeed = 0f;
        backwardThrusterSpeed = 0f;
    }

    // Z-Axis functions
    public void Accel(float acceleration = DEFAULT_ACCELERATION) {
        ChangeSpeedHandlingParticles(() => {
            forwardThrusterSpeed = Mathf.Min(forwardThrusterSpeed + acceleration, MAX_THRUSTER_SPEED);
            backwardThrusterSpeed = 0f;

            forwardVelocity = Mathf.Min(forwardVelocity + forwardThrusterSpeed, FORWARD_SPEED_LIMIT);
            rigidbody.velocity = transform.forward * forwardVelocity;
        });
    }

    public void Reverse(float acceleration = DEFAULT_ACCELERATION) {
        ChangeSpeedHandlingParticles(() => {
            forwardThrusterSpeed = 0f;
            backwardThrusterSpeed = Mathf.Min(backwardThrusterSpeed + acceleration, MAX_THRUSTER_SPEED);

            forwardVelocity = Mathf.Max(forwardVelocity - backwardThrusterSpeed, BACKWARD_SPEED_LIMIT);
            rigidbody.velocity = transform.forward * forwardVelocity;
        });
    }

    private void ChangeSpeedHandlingParticles(Action changeSpeed) {
        bool wasThrusterOn = IsThrusterOn();

        changeSpeed();

        bool isThrusterOn = IsThrusterOn();

        if (wasThrusterOn != isThrusterOn) {
            ToggleParticles(isThrusterOn);
        }
    }

    private bool IsThrusterOn() {
        bool isForwardThrusterOn = forwardThrusterSpeed > THRUSTER_ON_THRESHOLD;
        bool isBackwardThrusterOn = backwardThrusterSpeed > THRUSTER_ON_THRESHOLD;
        return isForwardThrusterOn || isBackwardThrusterOn;
    }

    private void ToggleParticles(bool enable) {
        foreach (ParticleSystem particle in particles) {
            if (enable) {
                particle.Play();
            } else {
                particle.Pause();
            }
        }
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
