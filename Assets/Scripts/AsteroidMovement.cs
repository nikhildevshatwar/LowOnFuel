﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float asteroidSpeed;
    private Vector2 movement;
    public float asteroidAngle;
    private float yLocation;
    private float playerHeight;
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

    private void Update()
    { /* BROKEN CODE BROKEN CODE BROKEN CODE
        playerHeight = PlayerControl.height;
        yLocation = gameObject.transform.position.y;

        if(yLocation < (playerHeight - 20))
        {
            Destroy(gameObject);
        } */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("missile"))
        {
            print("missile hit asteroid");
            Destroy(collision.gameObject);
        }
    }

}
