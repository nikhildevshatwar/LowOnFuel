using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    // Spawns copies of a prefab as the player gets higher in the level
    public GameObject[] prefabList;
    public float spawnRangeX;
    public float spawnRangeY;
    public float maxDistanceBetweenAsteroids;

    private List<GameObject> bag = new List<GameObject>();
    private Vector2 vector;
    private float lastCloneHeight = 0;
    private GameObject rocket;

    void Start()
    {
                rocket = GameObject.Find("Rocket");
    }
    
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
        if (rocket.transform.position.y > lastCloneHeight) {

            float randX = rocket.transform.position.x  + Random.Range(-spawnRangeX, spawnRangeX);
            float randY = rocket.transform.position.y + spawnRangeY + Random.Range(0, spawnRangeY);


            int idx = Mathf.FloorToInt(Random.Range(0, prefabList.Length));
            //GameObject prefab = prefabList[idx];

            vector = new Vector2(randX, randY);
            GameObject clone = Instantiate(ChooseObstacle(), vector, Quaternion.identity) as GameObject;
            //bag.Add(clone);
            lastCloneHeight += Random.Range(0, maxDistanceBetweenAsteroids) ;
        }
    }
}

