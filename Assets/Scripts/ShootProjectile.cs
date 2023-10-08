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
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
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
