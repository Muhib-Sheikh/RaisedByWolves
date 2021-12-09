using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCamelSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] camels;
    public static int randomCamelStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        int generateCamel = Random.Range(0, 150);
        if (generateCamel == 5)
        {
            int randCamel = Random.Range(0, camels.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            Vector2 position = new Vector3(spawnPoints[randSpawnPoint].position.x, spawnPoints[randSpawnPoint].position.y);

            randomCamelStart = randSpawnPoint;
            // 0 = top
            // 1 = right
            // 2 = bottom
            // 3 = left

            Instantiate(camels[randCamel], position, Quaternion.identity);

        }
    }
}
