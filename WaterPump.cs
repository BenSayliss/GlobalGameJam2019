using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterPump : MonoBehaviour
{
    //slider related values//
    public Slider Slider;
    public Slider WaterAmount;
    public GameObject HoldOn;
    public GameObject GotIt;
    public GameObject PERFECT;
    //////////////////////////

    //timer related variables//
    public float Timer;
    bool timerStart = false;
    public Text timerGUI;
    bool countdown = false;
    //////////////////////////

    //variables that show how much water your getting//
    public Text waterCount;
    float WaterForThePeople;
    public float AmountOfWater;
    //////////////////////////

    // audio related things//
    public AudioSource pump;
    public AudioClip fanfare;
    public AudioSource perfectSound;
    /////////////////////////

    //min max value//
    float minVal;
    float maxVal;
    //////////////////////////

    //Transfer data//
    public GetWaterFromGame WaterData;
    //////////////////////////

    //public GetWater FunWater;
    public GameObject ContTxt;
    public float WaterValue = 100f;
    bool PerfectBool = true;
    bool STOPEVERYTHING; //emergancy stop
    bool safeVal; // if this returns true it means the safe zone values are good
    // Start is called before the first frame update
    void Start()
    {
        minVal = Random.Range(Slider.minValue + 1, Slider.maxValue);
        maxVal = Random.Range(Slider.minValue + 1, Slider.maxValue);

        WaterAmount.maxValue = Random.Range(10, 50);

        timerGUI.text = Timer.ToString();

        WaterAmount.value = 0f;
        waterCount.text = (WaterAmount.value * WaterValue).ToString();
        safeVal = false;
        ContTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //print("Min: " + minVal + ", Max: " + maxVal +", SafeVal: " + safeVal); // remove this eventually
        

        if(timerStart)
        {
            if (countdown) Timer -= Time.deltaTime; // tis' but a timer
            timerGUI.text = Mathf.RoundToInt(Timer).ToString();
            waterCount.text = Mathf.RoundToInt((WaterAmount.value * WaterValue)).ToString(); // turns float into a string
        }
        if(Timer <= 0)
        {
            Timer = 0f;
            safeVal = false;
            countdown = false;
            STOPEVERYTHING = true;
            if (STOPEVERYTHING) AmountOfWater = Mathf.RoundToInt((WaterAmount.value * WaterValue)); // if emergancy stop is pressed then set the water for the people to its respective value
            waterCount.text = Mathf.RoundToInt(AmountOfWater).ToString();

            ContTxt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                SceneManager.LoadScene("Overworld_Main");
            }
            
            //WaterData.resource_Water = WaterAmount.value * WaterValue; // this value should be global
            //FunWater.DontMove = false;
            //PlayerData.WaterResource_ = WaterAmount.value * WaterValue;

        }

        /*if the minVal for sweet spot is higher than maxVal, redo until min is smaller*/
        if(minVal >= maxVal)
        {
            minVal = Random.Range(Slider.minValue, Slider.maxValue);
            HoldOn.SetActive(true); // a timple text GUI telling the player to wait
        }
        else if(minVal < maxVal)
        {
            safeVal = true;
        }

        if(safeVal) HoldOn.SetActive(false);

        // working on a way to change this up, but for now these will work
        if ((maxVal - minVal) < 0.5f && safeVal)
        {
            maxVal = Random.Range(Slider.minValue, Slider.maxValue);
            minVal = maxVal - 1f;
        }
       else if ((maxVal - minVal) > 2f && safeVal)
        {
            maxVal = Random.Range(Slider.minValue, Slider.maxValue);
            minVal = maxVal - 1f;
        }

        /*slider increase and decrease*/
        if (Input.GetKeyDown(KeyCode.Space) && safeVal)
        {
            if (!STOPEVERYTHING)
            {
                Slider.value += 1; // only increase slider if emergacy stop isnt pressed
                pump.Play();
            }
            if(!timerStart) // starts timer on space press
            {
                timerStart = true;
                countdown = true;
            }
            
        }

        // if slider val is more than zero, decrease until
        if(Slider.value > 0)
        {
            Slider.value -= 0.07f;
        }

        // code to check sweet spot
        if(Slider.value > minVal && Slider.value < maxVal && timerStart)
        {
            print("yessssssss");
            if (!STOPEVERYTHING) WaterAmount.value += 0.07f; //this is where you get more water if in sweet spot
            GotIt.SetActive(true); // indicator for being in sweetspot
        }
        else
        {
            GotIt.SetActive(false);
        }

        if(WaterAmount.value >= WaterAmount.maxValue)
        {
            PERFECT.SetActive(true);
            Timer = 0f;
            if(PerfectBool)
            {
                perfectSound.PlayOneShot(fanfare, 1f);
                PerfectBool = false;
            }
        }
        else
        {
            PERFECT.SetActive(false);
        }
    }

    void OnEnable()
    {
        minVal = Random.Range(Slider.minValue + 1, Slider.maxValue);
        maxVal = Random.Range(Slider.minValue + 1, Slider.maxValue);

        WaterAmount.maxValue = Random.Range(10, 50);

        timerGUI.text = Timer.ToString();

        Timer = 10f;

        WaterAmount.value = 0f;
        waterCount.text = (WaterAmount.value * WaterValue).ToString();
        safeVal = false;
        STOPEVERYTHING = false;
        countdown = true;
        //ContTxt.SetActive(false);



        /*if the minVal for sweet spot is higher than maxVal, redo until min is smaller*/
        if (minVal >= maxVal)
        {
            minVal = Random.Range(Slider.minValue, Slider.maxValue);
            HoldOn.SetActive(true); // a timple text GUI telling the player to wait
        }
        else if (minVal < maxVal)
        {
            safeVal = true;
        }

        if (safeVal) HoldOn.SetActive(false);

        // working on a way to change this up, but for now these will work
        if ((maxVal - minVal) < 0.5f && safeVal)
        {
            maxVal = Random.Range(Slider.minValue, Slider.maxValue);
            minVal = maxVal - 1f;
        }
        else if ((maxVal - minVal) > 2f && safeVal)
        {
            maxVal = Random.Range(Slider.minValue, Slider.maxValue);
            minVal = maxVal - 1f;
        }
    }

    void OnDisable()
    {
        PlayerData.WaterResource_ += (WaterAmount.value * WaterValue);
    }
}
