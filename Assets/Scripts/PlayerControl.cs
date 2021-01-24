using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float mainThrust;
    public float sideThrust;
    public float initialFuel;
    public float fuelSpeed;

    public static float fuelLevel;
    public static float height;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuelLevel = initialFuel;
    }

    void FixedUpdate() {

        if (Input.GetKey(KeyCode.Space) && fuelLevel > 0) {
            rb.AddRelativeForce(new Vector2(0, mainThrust));
            fuelLevel -= fuelSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            rb.AddRelativeForce(new Vector2(-sideThrust, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            rb.AddRelativeForce(new Vector2(sideThrust, 0));
        }
    }

    void Update()
    {
        height = transform.position.y;        
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Collision detected with " +  col.name);
    }
}
