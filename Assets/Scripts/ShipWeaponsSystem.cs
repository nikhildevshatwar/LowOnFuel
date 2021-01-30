using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponsSystem : MonoBehaviour
{
  
    public Transform projectileSpawnPoint;
    public GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Start()
    {
        projectileSpawnPoint = GameObject.Find("BulletSpawnPoint").transform;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the projectile at the position and rotation of this transform
            GameObject clone;
            clone = Instantiate(projectile, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);

            // Give the cloned object an initial velocity along the current
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up * 40);

            AudioManager.Instance.Play("fire");
        }
    }

   
}

