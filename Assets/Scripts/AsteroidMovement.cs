using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float asteroidSpeed;
    private Vector2 movement;
    public float asteroidAngle;
    

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float x = Random.Range(-asteroidAngle, asteroidAngle);
        movement = new Vector2(x, -asteroidSpeed);

    }

    private void FixedUpdate()
    {
        rb.AddForce(movement);
    }

}
