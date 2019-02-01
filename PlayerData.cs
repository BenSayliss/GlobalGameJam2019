using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static float audioValue;

    public static int difficultyNum; // 0-2
    
    public static List<Item> globalInventoryList = new List<Item>();

    public static float food;

    public static float wood;

    public static float stone;

    public static int dayCounter;

    public static int dayLoss;

    public static int population;

    public static float WaterResource;


    /// <summary>
    /// /////////////////
    /// </summary>
    /// 

    public static float Wood
    {
        get
        {
            return wood;
        }

        set
        {
            wood = value;
        }
    }


    public static float Stone
    {
        get
        {
            return stone;
        }

        set
        {
            stone = value;
        }
    }



    public static int DayCounter
    {
        get
        {
            return dayCounter;
        }

        set
        {
            dayCounter = value;
        }
    }

    public static int DayLoss
    {
        get
        {
            return dayLoss;
        }

        set
        {
            dayLoss = value;
        }
    }

    public static int Population
    {
        get
        {
            return population;
        }

        set
        {
            population = value;
        }
    }

    public static float Food
    {
        get
        {
            return food;
        }
        set
        {
            food = value;
        }
    }

    public static float WaterResource_
    {
        get
        {
            return WaterResource;
        }
        set
        {
            WaterResource = value;
        }
    }

    public static float AudioValue
    {
        get
        {
            return audioValue;
        }
        set
        {
            audioValue = value;
        }
    }

    public static int Difficulty
    {
        get
        {
            return difficultyNum;
        }
        set
        {
            difficultyNum = value;
        }
    }

    public static List<Item> GlobalList
    {
        get
        {
            return globalInventoryList;
        }

        set
        {
            globalInventoryList = value;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
    }
}