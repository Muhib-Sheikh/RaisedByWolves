using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCamelSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] camels;
    public int amountOfCamelDesired = 4;
    public static int CurrentCamelAmount = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentCamelAmount < amountOfCamelDesired && Random.Range(0,600) == 150 && spawnPoints.Length != 0 && !camelMovement.hasBaby){
            int updateRandCamels = Random.Range(0,camels.Length);
            int updateRandSpawnPoint = Random.Range(0,spawnPoints.Length);
            Vector2 position = new Vector3(spawnPoints[updateRandSpawnPoint].position.x, spawnPoints[updateRandSpawnPoint].position.y);
            Instantiate (camels[updateRandCamels], position, Quaternion.identity);
            CurrentCamelAmount++;
        }
    }
}
