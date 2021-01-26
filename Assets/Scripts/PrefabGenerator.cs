using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    // Spawns copies of a prefab as the player gets higher in the level
    public GameObject[] prefabList;
    public GameObject player;
    public float spawnRange;

    private List<GameObject> bag = new List<GameObject>();
    private Vector2 vector;
    private float lastCloneHeight = 0;

    public GameObject ChooseObstacle()
    {
        if (bag.Count == 0)
        {
            bag.AddRange(prefabList);
        }
        int index = Random.Range(0, bag.Count);
        GameObject p = bag[index];
        bag.RemoveAt(index);
        return p;
    }



    void FixedUpdate()
    {
        if (PlayerControl.height > lastCloneHeight) {

            float randX = player.transform.position.x  + Random.Range(-spawnRange, spawnRange);
            float randY = PlayerControl.height + spawnRange + Random.Range(0, spawnRange);


            int idx = Mathf.FloorToInt(Random.Range(0, prefabList.Length));
            //GameObject prefab = prefabList[idx];

            vector = new Vector2(randX, randY);
            GameObject clone = Instantiate(ChooseObstacle(), vector, Quaternion.identity) as GameObject;
            //bag.Add(clone);
            lastCloneHeight += Random.Range(0, spawnRange );
        }
    }
}

