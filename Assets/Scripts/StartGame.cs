using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Text scoreText;

    public int timeSurvived = 0;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Victory")
        {
            scoreText.text = "Score: " + playermovment.playerScore.ToString();
        }
        if(currentScene.name == "Game Over")
        {
            if(camelMovement.gameMode == 2)
            {
                timeSurvived = 300 - Mathf.FloorToInt(HungerLevel.timeRemaining);
                scoreText.text = "Time Survived: " + timeSurvived.ToString() + " seconds";
            }
            else if(camelMovement.gameMode == 1)
            {
                scoreText.text = "Score: " + playermovment.playerScore.ToString();
            }
            
        }
    }

    public void PlayNormalMode()
    {
        camelMovement.gameMode = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayHardMode()
    {
        camelMovement.gameMode = 2;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        Reset();
        SceneManager.LoadScene("Menu");
    }

    public void TryAgain()
    {
        Reset();
        camelMovement.hasBaby = false;
        if (camelMovement.gameMode == 1)
        {
            PlayNormalMode();
        }
        else if(camelMovement.gameMode == 2)
        {
            PlayHardMode();
        }
    }

    public void Reset()
    {
        RandomCamelSpawner.CurrentCamelAmount = 0;
        RandomFoodSpawner.CurrentFoodAmount = 0;
        camelMovement.hasBaby = false;
        HungerLevel.hunger = 100f;
        FoodGatherWolf.foodInventory = 0;
        playermovment.playerScore = 0;
    }
}
