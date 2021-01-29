using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidMovement : MonoBehaviour
{
    public float asteroidSpeed;
    public float asteroidAngle;
    public float totalHealth;
    public Image healthBar;     

    private Vector2 movement;
    private Rigidbody2D rb;
    private GameObject rocket;
    private float yLocation;
    private float playerHeight;
    private float health ;
    public GameObject particleDestruction;

    void Start()
    {
        rocket = GameObject.Find("Rocket");
        rb = GetComponent<Rigidbody2D>();

        float x = Random.Range(-asteroidAngle, asteroidAngle);
        movement = new Vector2(x, -asteroidSpeed);

        health = totalHealth;
        Invoke("CheckDestroy", 5);
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("missile"))
        {
            Object.Destroy(collision.gameObject, 0.0f);
            health -= GameController.Instance.missileDamage;
            if (health <= 0) {
                Instantiate(particleDestruction, gameObject.transform.position, Quaternion.identity);
                Object.Destroy(gameObject, 0.0f);
            } else {
                healthBar.fillAmount = health / totalHealth;
            }
        }
    }

    void CheckDestroy() {
        float dist = Vector3.Distance(rocket.transform.position, transform.position);
        if (dist > 1000) {
            Destroy(gameObject, 0);
        } else {
            Invoke("CheckDestroy", 5);
        }
    }
}
