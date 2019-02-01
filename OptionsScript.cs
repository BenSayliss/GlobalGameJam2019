using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    public Slider slider;
    public Dropdown dropdown;

    private bool firstTime = true;


    private void Start()
    {
        //slider.value = PlayerData.AudioValue;
        dropdown.value = PlayerData.Difficulty;
        
    }

    // activates when we change the slider value
    public void AdjustSlider()
    {
        PlayerData.AudioValue = slider.value;
    }

    public void GoToMenuScene()
    {
        PlayerData.Difficulty = dropdown.value;
        if (dropdown.value == 0)
        {
            PlayerData.DayLoss = 1;
        }
        else if (dropdown.value == 1)
        {
            PlayerData.DayLoss = 3;
        }
        else if (dropdown.value == 2)
        {
            PlayerData.DayLoss = 5;
        }
        SceneManager.LoadScene("MainMenu");
    }

    // activates when we change the dropdown menu value
    public void DropdownMenu()
    {
        PlayerData.Difficulty = dropdown.value;

    }
}
