using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float mainThrust;
    public float sideThrust;
    public float initialFuel;
    public float fuelSpeed;
    public float turnSpeed;

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
            rb.drag = 0.8f;
        } else {
            rb.drag = 1.2f;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);
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
