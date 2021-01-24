using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{

    public GameObject originalObject;
    public float spawnRange;
    public float interval;

    private List<GameObject> clones = new List<GameObject>();
    private Vector2 vector;
    private int count;

    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count % interval == 0) {
            float randX = Random.Range(-spawnRange, spawnRange);
            float randY = Random.Range(-spawnRange, spawnRange);
            vector = new Vector2(randX, randY);
            GameObject clone = Instantiate(originalObject, vector, Quaternion.identity) as GameObject;
            clones.Add(clone);
        }
    }
}
