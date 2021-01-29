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
    public int totalHealth;

    public GameObject trailParticle;
    private ParticleSystem trailPS;
    ParticleSystem.EmissionModule EM;

    public AudioSource JetStart;
    public AudioSource JetLoop;
    private bool startedLoop;

    [SerializeField]
    private GameObject[] thrusters; //0 is main, 1 is left, 2 right thruster

    public static float fuelLevel;
    public static float height;
    private Rigidbody2D rb;

    private bool shield_active;
    private int health;
    public float thrustScale = 0.1f;
    public static int weight = 10;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuelLevel = initialFuel;
        EM = trailParticle.GetComponent<ParticleSystem>().emission;


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
            EM.rateOverTime = 8;
            EngineSound();
        }
        if (Input.GetKeyUp(KeyCode.Space) && fuelLevel > 0)
        {
            EngineSoundEnd();
            EM.rateOverTime = 0;
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
            thrusters[0].SetActive(true);
        }
        else
        {
            rb.AddRelativeForce(new Vector2(0, mainThrust * thrustScale));
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
        else
        {
            thrusters[1].SetActive(false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-turnSpeed);
            thrusters[2].SetActive(true);
        }
        else
        {
            thrusters[2].SetActive(false);
        }
    }

    public void DropShielding()
    {
        AudioManager.Instance.Play("drop");
        thrustScale += 0.05f;
    }

    public void DropWeapon()
    {
        AudioManager.Instance.Play("drop");
        DisableWeapons();
        thrustScale += 0.08f;
    }

    public void DropRadar()
    {
        AudioManager.Instance.Play("drop");
        thrustScale += 0.05f;
    }

    void DisableWeapons()
    {
        //to do 
    }

    public void DropPayload()
    {
        AudioManager.Instance.Play("drop");
        thrustScale += 0.03f;
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
