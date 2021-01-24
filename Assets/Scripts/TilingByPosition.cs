using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingByPosition : MonoBehaviour
{

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
        mat.mainTextureOffset = new Vector2(0, PlayerControl.height *  scale);
    }
}
