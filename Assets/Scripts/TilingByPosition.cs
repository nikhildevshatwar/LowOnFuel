using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingByPosition : MonoBehaviour
{
    private Transform rocket;
    private float scale = 0.1f;

    private MeshRenderer mr;
    private Material mat;

    void Start()
    {
        rocket = GameObject.Find("Rocket").transform;
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    void Update()
    {
        mat.mainTextureOffset = rocket.position * scale;
    }
}
