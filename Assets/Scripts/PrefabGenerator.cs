using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    // Spawns copies of a prefab as the player gets higher in the level
    public GameObject originalObject;
    public GameObject player;
    public float spawnRange;
    public float interval;

    private List<GameObject> clones = new List<GameObject>();
    private Vector2 vector;
    private float lastCloneHeight = 0;

    void FixedUpdate()
    {
        if (PlayerControl.height > lastCloneHeight + spawnRange) {

            float randX = player.transform.position.x  + Random.Range(-spawnRange, spawnRange);
            float randY = PlayerControl.height + spawnRange + Random.Range(0, spawnRange);

            vector = new Vector2(randX, randY);
            GameObject clone = Instantiate(originalObject, vector, Quaternion.identity) as GameObject;
            clones.Add(clone);
            lastCloneHeight = randY;
        }
    }
}

