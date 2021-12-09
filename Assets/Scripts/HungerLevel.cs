using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HungerLevel : MonoBehaviour
{
    
    public Slider hungerSlider;

    public static float hunger;
    
    public float maxHunger = 100f;

    public bool starved = false;

    public static float hungerMod = 3f;

    public Text timeText;
    
    public static int kidnapID = 0;

    public static float timeRemaining = 120;

    public bool timerIsRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        hunger = maxHunger;
        if(camelMovement.gameMode == 2)
        {
            timeRemaining = 300;
        }
        else if(camelMovement.gameMode == 1)
        {
            timeRemaining = 120;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 1)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene("Victory");
            }
        }

    hungerSlider.value = hunger;

        if(camelMovement.gameMode == 2)
        {
            hungerMod = 3f;
        }
        hunger -= hungerMod * Time.deltaTime * camelMovement.gameMode;
        if (hunger <= 0){
            SceneManager.LoadScene("Game Over");
        }
    }

    void OnCollisionEnter2D(Collision2D collider){
     
        if (collider.gameObject.name == "Wolf" ){
            if(hunger + FoodGatherWolf.foodInventory  > 100){
                hunger = 100;
            }
            else{
            hunger += FoodGatherWolf.foodInventory;
            }
     }
         FoodGatherWolf.foodInventory = 0;
         
     }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
