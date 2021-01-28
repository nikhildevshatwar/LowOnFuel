using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face_towards_object : MonoBehaviour
{

    public GameObject lookFrom;
    public GameObject lookTo;

    void Update()
    {
        Vector3 target =  lookTo.transform.position;
        Vector3 pivot =  lookFrom.transform.position;

        float angle = Mathf.Atan2(target.y - pivot.y, target.x - pivot.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
