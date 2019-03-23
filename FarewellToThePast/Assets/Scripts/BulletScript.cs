using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    const float BULLET_SPEED_DEFAULT = 1.5f;
    const float BULLET_TTL = 5f;
    bool shooting;
    Vector3 target;
    float bulletSpeed;

    Transform mTransform;
    void Awake()
    {
        shooting = false;
        target = Vector3.zero;
        mTransform = GetComponent<Transform>();
        bulletSpeed = BULLET_SPEED_DEFAULT;
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting) {
            mTransform.position = Vector3.MoveTowards(mTransform.position, target, bulletSpeed);
            if (Vector3.Distance(mTransform.position, target) < BULLET_SPEED_DEFAULT) {
                EndShot();
            }
        }
    }

    public void Shot(Vector3 origin, Vector3 destination, float speed=BULLET_SPEED_DEFAULT) {
        Debug.Log("Shot");
        if (!shooting) {
            Debug.Log("Shot 2");
            mTransform.position = origin;
            target = destination;
            bulletSpeed = speed;
            shooting = true;
            Invoke("EndShot", BULLET_TTL);
        }
    }

    void EndShot() {
        Destroy(gameObject);
    }
}
