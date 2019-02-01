using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshWater;
    public TextMeshProUGUI textMeshFood;
    public TextMeshProUGUI textMeshStone;
    public TextMeshProUGUI textMeshWood;

    public TextMeshProUGUI textMeshDayCounter;
    public TextMeshProUGUI textMeshPopCounter;

    private float waterCount;
    private float foodCount;
    private float stoneCount;
    private float woodCount;

    private int dayCounter;
    private int popCounter;

    // Events
    public Canvas dialogueCanvas;


    // Start is called before the first frame update
    void Start()
    {
        PlayerData.DayCounter -= PlayerData.DayLoss;
        waterCount = PlayerData.WaterResource_;
        foodCount = PlayerData.Food;
        stoneCount = PlayerData.Stone;
        woodCount = PlayerData.Wood;
        dayCounter = PlayerData.DayCounter;
        popCounter = PlayerData.Population;

        textMeshWater.text = waterCount.ToString();
        textMeshFood.text = foodCount.ToString();
        textMeshStone.text = stoneCount.ToString();
        textMeshWood.text = woodCount.ToString();
        textMeshDayCounter.text = dayCounter.ToString();
        textMeshPopCounter.text = popCounter.ToString();

        Debug.Log("" + dialogueCanvas.gameObject.name);
        dialogueCanvas.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.DayCounter <= 75) {
            dialogueCanvas.gameObject.SetActive(true);

        }
    }
}
