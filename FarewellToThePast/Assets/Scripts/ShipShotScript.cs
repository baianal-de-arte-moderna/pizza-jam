using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShotScript : MonoBehaviour
{
    private const int DEFAULT_COOL_DOWN = 100;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform weapon;

    private Ship ship;

    private bool shooting;
    private int cooldown;

    private void Awake() {
        ship = GetComponent<Ship>();
        shooting = false;
        cooldown = 0;
    }

    private void FixedUpdate() {
        if (shooting) {
            cooldown--;
            shooting = cooldown > 0;
        }
    }

    public void Shot() {
        if (!shooting) {
            shooting = true;
            cooldown = DEFAULT_COOL_DOWN / ship.getRateOfFire();
            Vector3 destination = transform.parent.forward * Camera.main.farClipPlane;
            Shot(destination);
        }
    }

    public void Shot(Vector3 destination) {
        var newBullet = Instantiate<GameObject>(bulletPrefab);
        newBullet.GetComponent<BulletScript>().Shot(ship, weapon.position, destination);
    }
}
