using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodGatherWolf : MonoBehaviour
{
    public static int foodInventory = 0;

    public static int foodLimit = 20;

    public static bool foodReady = false;

    public Slider gatheredSlider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gatheredSlider.value = foodInventory;
    }
}
