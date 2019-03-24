using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShotScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform weapon;

    private Ship ship;

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }

    public void Shot() {
        Vector3 destination = transform.parent.forward * Camera.main.farClipPlane;
        Shot(destination);
    }

    public void Shot(Vector3 destination) {
        var newBullet = Instantiate<GameObject>(bulletPrefab);
        newBullet.GetComponent<BulletScript>().Shot(ship, weapon.position, destination);
    }
}
