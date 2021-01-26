using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingByPosition : MonoBehaviour
{
    public GameObject player;
    public float scale;

    private MeshRenderer mr;
    private Material mat;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    void Update()
    {
        mat.mainTextureOffset = player.transform.position * scale;
    }
}
