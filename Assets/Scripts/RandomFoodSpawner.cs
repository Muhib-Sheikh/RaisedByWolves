using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFoodSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] food;
    public int amountOfFoodDesired = 5;
    public static int CurrentFoodAmount = 0;
    public int foodRange = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(camelMovement.gameMode == 2)
        {
            foodRange = Random.Range(0, 200);
        }else if(camelMovement.gameMode == 1)
        {
            foodRange = Random.Range(0, 275);
        }
        if(CurrentFoodAmount < 5 && foodRange == 150 && spawnPoints.Length != 0){
            int updateRandFood = Random.Range(0,food.Length);
            int updateRandSpawnPoint = Random.Range(0,spawnPoints.Length);
            Vector2 position = new Vector3(spawnPoints[updateRandSpawnPoint].position.x, spawnPoints[updateRandSpawnPoint].position.y);
            Instantiate (food[updateRandFood], position, Quaternion.identity);
            CurrentFoodAmount++;
        }
    }
}
