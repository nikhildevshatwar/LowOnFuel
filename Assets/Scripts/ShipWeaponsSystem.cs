using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponsSystem : MonoBehaviour
{
  
    public Transform projectileSpawnPoint;
    public Rigidbody2D projectile1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody2D clone;
            clone = Instantiate(projectile1, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector2.up * 40);

            AudioManager.Instance.Play("fire");
        }
    }

   
}

