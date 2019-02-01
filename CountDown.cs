using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour {

    [SerializeField] private Text Counter;
    [SerializeField] private Text Harvest;
    [SerializeField] private float mainTimer;

    GameObject animal;

    //Timer
    public static float timer;
    private bool Count;
    private bool Once;

    //Harvest
    private float harvested;

	// Use this for initialization
	void Start () {
        animal = GameObject.Find("Animal");

        //Bools for texts
        Once = false;
        Count = true;

        //Floats for text
        harvested = 0.0f;
        mainTimer = 30f;
        timer = mainTimer;
        Harvest.text = harvested.ToString("F");
	}
	
	// Update is called once per frame
	void Update () { 
        {
            harvested = GameObject.Find("Player").GetComponent<PlayerController>().food;
            Harvest.text = harvested.ToString("F");
        }

        if (timer > 0 && Count)
        {
            timer -= Time.deltaTime;
            Counter.text = timer.ToString("F");
        } 
        else if(timer <= 0 && !Once)
        {
            Once = true;
            Count = false;
            Counter.text = "0";
            timer = 0.0f;
            WinScreen();
        }
	}

    void WinScreen()
    {
        //Changes scenes
        PlayerData.Food += GameObject.Find("Player").GetComponent<PlayerController>().food;
        SceneManager.LoadScene("Overworld_Main");
        Debug.Log("Minigame Ended!");

        
    }
}