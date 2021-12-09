using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.name == "Wolf" && FoodGatherWolf.foodInventory < FoodGatherWolf.foodLimit) {
            FoodGatherWolf.foodInventory += 5;
            RandomFoodSpawner.CurrentFoodAmount--;
            playermovment.playerScore += 2;
            Destroy (this.gameObject);
        }
    }
}
