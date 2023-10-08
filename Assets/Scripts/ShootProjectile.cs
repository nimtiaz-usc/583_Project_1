using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modified from https://www.youtube.com/watch?v=T5y7L1siFSY
public class ShootProjectile : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject projectile;
    public Transform FirePoint;
    public float projectileSpeed = 30f;
    public float fireRate = 4;
    private Vector3 destination;
    private float timeToFire;

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire1") && Time.time >= timeToFire) {
            timeToFire = Time.time + 1/fireRate;
            Shoot();
        }
    }
    void Shoot() {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            destination = hit.point;
        } else {
            destination = ray.GetPoint(1000);
        }
        InstantiateProjectile();
    }
    void InstantiateProjectile() {
        var projectileObject = Instantiate(projectile, FirePoint.position, Quaternion.identity) as GameObject;
        projectileObject.GetComponent<Rigidbody>().velocity = (destination - FirePoint.position).normalized * projectileSpeed;
    }
}
