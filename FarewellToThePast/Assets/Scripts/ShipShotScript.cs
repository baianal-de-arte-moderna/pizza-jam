using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShotScript : MonoBehaviour
{
    public GameObject BulletPrefab;

    [SerializeField]
    Transform Weapon;
    // Start is called before the first frame update
    void Start() {}

    public void Shot() {
        Vector3 destination = transform.forward * Camera.main.farClipPlane;
        Shot(destination);
    }
    public void Shot(Vector3 destination) {
        var newBullet = Instantiate<GameObject>(BulletPrefab);
        newBullet.GetComponent<BulletScript>().Shot(Weapon.position, destination);
    }
}
