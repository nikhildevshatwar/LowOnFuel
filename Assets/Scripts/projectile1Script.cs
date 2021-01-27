using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile1Script : MonoBehaviour
{
    public float m_Speed = 10f;   // this is the projectile's speed
    public float m_Lifespan; // this is the projectile's lifespan (in seconds)
    private Rigidbody2D m_Rigidbody;

    void Awake()
    {
        Destroy(gameObject, 5);
    }

    

    

}
