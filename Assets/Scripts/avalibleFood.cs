using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avalibleFood : MonoBehaviour
{
    public static int foodCount = 3;
    
    public GameObject food;

    // Update is called once per frame
    void Update()
    {
       if(foodCount < 3 && Random.Range(0,10) > 8){
            Vector2 position = new Vector3(Random.Range(-5F, 5F), Random.Range(-4F, 4F));
            Instantiate (food, position, Quaternion.identity);
            foodCount++;
       }
    }
}
