using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float mainThrust;
    public float emergencyThrust=2;
    public float sideThrust;
    public float initialFuel;
    public float fuelSpeed;
    public float turnSpeed;

    [SerializeField]
    private GameObject[] thrusters; //0 is main, 1 is left, 2 right thruster

    public static float fuelLevel;
    public static float height;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuelLevel = initialFuel;
    }


    /// <summary>
    /// I would use a coroutine which runs every time a part is added or removed *instead of lowering thrust, raise the mass of the Rigidbody
    /// sluggishness level 1 - set main thrust and turnspeed excellent *
    /// sluggishness level 2 - set main thrust and turnspeed lower
    /// sluggishness level 3 - set main thrust and turnspeed quite low
    /// sluggishness level 4 - set main thrust and turnspeed very low
    /// sluggishness level 3 - set main thrust and turnspeed almost unplayably low
    /// </summary>




    void FixedUpdate() {

        if (Input.GetKey(KeyCode.Space) && fuelLevel > 0)
        { //main thrusters
            rb.AddRelativeForce(new Vector2(0, mainThrust));
            fuelLevel -= fuelSpeed;
            rb.drag = 0.5f;  //set flying drag
            //show main thruster sprite:
            thrusters[0].SetActive(true);
        } 
        else if (Input.GetKey(KeyCode.Space) && fuelLevel <= 0)
        { //emergency thrusters, if main thrusters are jettisoned or if out of fuel
            rb.AddRelativeForce(new Vector2(0, emergencyThrust));
            rb.drag = 0.5f;
            thrusters[0].SetActive(false);
        }
        else
        {
            rb.drag = .7f; //drifting drag
            thrusters[0].SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
            thrusters[1].SetActive(true);
        } else { thrusters[1].SetActive(false); }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);
            thrusters[2].SetActive(true);
        }
        else { thrusters[2].SetActive(false); }
    }

    void Update()
    {
        height = transform.position.y;        
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Collision detected with " +  col.name);
    }
}
