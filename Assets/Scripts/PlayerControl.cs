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
    public static int weight;
    public int totalHealth;

    public AudioSource JetStart;
    public AudioSource JetLoop;
    private bool startedLoop;

    [SerializeField]
    private GameObject[] thrusters; //0 is main, 1 is left, 2 right thruster

    [SerializeField]
    private int startWeight=5;

    public static float fuelLevel;
    public static float height;
    private Rigidbody2D rb;

    private bool shield_active;
    private int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuelLevel = initialFuel;
        weight = startWeight;
        setWeight();

        shield_active = true;
        health = totalHealth;
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fuelLevel > 0)
        {
            EngineSound();
        }
        if (Input.GetKeyUp(KeyCode.Space) && fuelLevel > 0)
        {
            EngineSoundEnd();
        }

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

        if (fuelLevel < 0) {
            fuelLevel = 0;
            Debug.Log("Fuel Over, Keep less stuff to fly more");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(turnSpeed);
            thrusters[1].SetActive(true);
        }
        else { thrusters[1].SetActive(false); }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-turnSpeed);
            thrusters[2].SetActive(true);
        }
        else { thrusters[2].SetActive(false); }
    }

    public void DropShielding()
    {
        AudioManager.Instance.Play("drop");
        if (weight > 0)
        {
            weight -= 2;
        }
        setWeight();
    }

    public void DropWeapon()
    {
        AudioManager.Instance.Play("drop");
        DisableWeapons();
        if (weight > 0)
        {
            weight -= 2;
        }
        setWeight();
    }

    public void DropRadar()
    {
        AudioManager.Instance.Play("drop");
        if (weight > 0)
        {
            weight -= 2;
        }
        setWeight();
    }

    void DisableWeapons()
    {
        //to do 
    }

    public void DropMainThruster()
    {
        AudioManager.Instance.Play("drop");
        mainThrust = 5;
        if (weight > 0)
        {
            weight--;
        }
        setWeight();

    }

    public void DropSteeringThrusters()
    {
        AudioManager.Instance.Play("drop");
        if (weight > 0)
        {
            weight--;
        }
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
            turnSpeed = 35;
            fuelSpeed = 9;
        }
    }

    void EngineSound()
    {
        JetStart.PlayOneShot(JetStart.clip, 1f);
        JetLoop.PlayDelayed(JetStart.clip.length);
    }

    void EngineSoundEnd()
    {
        JetLoop.Stop();
        AudioManager.Instance.Play("JetEnd");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ItemWithDamage"))
        {
            if (!shield_active) {
                print("Rocket was hit!");
                Destroy(collision.gameObject);
                health -= 1;
            } else {
                print("Shield saved from hit!");
            }
        }

        if (health == 0) {
            Destroy(this);
        }
    }    
}
