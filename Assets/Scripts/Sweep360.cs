using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweep360 : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
