using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Progress_Bar : MonoBehaviour
{
    public float Currprogress;
    public float Maxprogress;
    public float Minprogress;
    public Slider Progressbar;
    public HandleCollider Points;
    public float food;
    // Start is called before the first frame update
    void Start()
    {
        Maxprogress = 10;
        Minprogress = 0;
        Currprogress = 0.01f;
        Progressbar.value = Calcprogress();
        food = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Currprogress = Points.points;
        Progressbar.value = Calcprogress();
        //create a if statement that checks if the progress condition is met
        if (Currprogress >= Maxprogress)
        {
            Win();
        }
        else if(Currprogress <= Minprogress)
        {
            Lose();
        }
        //moveprogress(0.1F);

    }

    //moveprogress updates the bar depending on what is happening
    private void moveprogress(float increment)
    {
        Currprogress += increment;
        Progressbar.value = Calcprogress();
        //check if your winning or losing
        if (Progressbar.value >= Maxprogress)
        {
            Win();
        }
        else if (Progressbar.value <= Minprogress)
        {
            Lose();
        }
    }
    //create a method to calculate the currentprogress percent
    private float Calcprogress()
    {
        return Points.points / Maxprogress;
    }
    //what do you do when you win
    private void Win()
    {
        Currprogress = Maxprogress;
        Debug.Log("you Win");
        food = 50;
        PlayerData.Food += food;
        SceneManager.LoadScene("OverWorld_Main");
    }
    //what do you do when you lose
    private void Lose()
    {
        Currprogress = Minprogress;
        Debug.Log("you lose");
        SceneManager.LoadScene("OverWorld_Main");
    }
}

