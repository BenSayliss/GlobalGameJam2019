using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
    }

    public void GoToPlayScene()
    {
        if(PlayerData.Difficulty == 0)
        {
            PlayerData.DayLoss = 1;
        }
        PlayerData.Population = 500;
        PlayerData.DayCounter = 100 + PlayerData.DayLoss;
        //SceneManager.LoadScene("Overworld_Main");
        SceneManager.LoadScene("AsteroidGame"); // CHANGE TO FIRST SCENE
    }

    public void GoToOptionsScene() {
        SceneManager.LoadScene("Options");
    }

    public void GoToInstructionsScene()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ExitGame()
    {
        // not sure why it's not working
        Application.Quit();
    }

    void Update()
    {
        // Tests
        Debug.Log("AudioValue: " + PlayerData.AudioValue);
        Debug.Log("DifficultyNum: " + PlayerData.Difficulty);
    }

}
