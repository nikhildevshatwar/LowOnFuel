using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face_towards_object : MonoBehaviour
{
    private Transform goal;
    private Transform rocket;

    void Start()
    {
        rocket = GameObject.Find("Rocket").transform;
        goal = GameObject.Find("Goal").transform;
    }

    void Update()
    {
        Vector3 target =  goal.position;
        Vector3 pivot =  rocket.position;

        float angle = Mathf.Atan2(target.y - pivot.y, target.x - pivot.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
