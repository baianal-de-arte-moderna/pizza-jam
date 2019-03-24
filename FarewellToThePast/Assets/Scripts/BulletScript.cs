using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    const float BULLET_SPEED_DEFAULT = 50f;
    const float BULLET_TTL = 5f;
    bool shooting;
    Vector3 target;
    float bulletSpeed;

    new Rigidbody rigidbody;

    Transform mTransform;
    void Awake()
    {
        shooting = false;
        target = Vector3.zero;
        mTransform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        bulletSpeed = BULLET_SPEED_DEFAULT;
    }

    public void Shot(Vector3 origin, Vector3 destination, float speed=BULLET_SPEED_DEFAULT) {
        if (!shooting) {
            mTransform.position = origin;
            rigidbody.velocity = destination.normalized * speed;
            shooting = true;
            Invoke("EndShot", BULLET_TTL);
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) {
            Debug.Log("Bullet hit");
            EndShot();
        }
    }

    void EndShot() {
        Destroy(gameObject);
    }
}
