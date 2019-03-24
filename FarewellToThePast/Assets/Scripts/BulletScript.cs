using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private const float BULLET_SPEED_DEFAULT = 50f;
    private const float BULLET_TTL = 5f;

    private new Transform transform;
    private new Rigidbody rigidbody;

    private bool shooting;
    private Vector3 target;
    private Ship shooter;

    private void Awake() {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        shooting = false;
        target = Vector3.zero;
    }

    public void Shot(Ship ship, Vector3 origin, Vector3 destination, float speed = BULLET_SPEED_DEFAULT) {
        if (!shooting) {
            transform.position = origin;
            rigidbody.velocity = destination.normalized * speed;
            shooting = true;
            shooter = ship;
            Invoke("EndShot", BULLET_TTL);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Bullet hit");

            Ship shot = other.GetComponent<Ship>();
            shot.setDamage(shot.getDamage() + shooter.getShotDamage());

            EndShot();
        }
    }

    void EndShot() {
        Destroy(gameObject);
    }
}
