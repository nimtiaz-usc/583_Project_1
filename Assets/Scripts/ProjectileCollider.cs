using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modified from https://www.youtube.com/watch?v=T5y7L1siFSY
public class ProjectileCollider : MonoBehaviour
{
    private bool collided = false;
    void OnCollisionEnter(Collision collision) {
        if (!collided && collision.gameObject.tag == "Wall") {
            collided = true;
            Destroy(gameObject);
        }

        if (!collided && collision.gameObject.tag == "Enemy") {
            collided = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
