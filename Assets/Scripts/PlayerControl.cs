using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float mainThrust;
    

    public float emergencyThrust=2;
    //public float sideThrust;
    public float initialFuel;
    public float fuelSpeed;
    public float turnSpeed;

    public GameObject[] shipParts;

    public static int weight;

    [SerializeField]
    private GameObject[] thrusters; //0 is main, 1 is left, 2 right thruster

    [SerializeField]
    private int startWeight=5;

    public static float fuelLevel;
    public static float height;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuelLevel = initialFuel;
        weight = startWeight;
        setWeight();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        
        height = transform.position.y;
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Collision detected with " +  col.name);
    }

    void Movement()
    {
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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
            thrusters[1].SetActive(true);
        }
        else { thrusters[1].SetActive(false); }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);
            thrusters[2].SetActive(true);
        }
        else { thrusters[2].SetActive(false); }
    }

    public void DropShielding()
    {
        weight-=2;
        setWeight();
        shipParts[0].SetActive(false);
    }

    public void DropWeapon()
    {
        DisableWeapons();
        weight-=2;
        setWeight();
        shipParts[1].SetActive(false);
    }

    void DisableWeapons()
    {
        //to do 
    }

    public void DropMainThruster()
    {
        mainThrust = 5;
        weight--;
        setWeight();

    }

    public void DropSteeringThrusters()
    {
        
        weight--;
        setWeight();
        turnSpeed = turnSpeed / 2;
    }

   

    void setWeight()
    {
        if (weight == 1){
            rb.mass = 1;
            turnSpeed = 100;
            fuelSpeed = 1;
        }
        if (weight == 2)
        {
            rb.mass = 2;
            turnSpeed = 80;
            fuelSpeed = 3;
        }
        if (weight == 3)
        {
            rb.mass = 3;
            turnSpeed = 60;
            fuelSpeed = 5;
        }
        if (weight == 4)
        {
            rb.mass = 4;
            turnSpeed = 40;
            fuelSpeed = 7;
        }
        if (weight == 5)
        {
            rb.mass = 5;
            turnSpeed = 20;
            fuelSpeed = 9;
        }
    }
    
}
