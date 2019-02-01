using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FMG_FishingRod : MonoBehaviour
{
    public float startpos;
    public float currpos;
    public Slider Reel;
    // Start is called before the first frame update
    void Start()
    {
        startpos = 0.01f;
        currpos = startpos;
        Reel.value = CalculateReelpos();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Reel.value += 0.04f;
        }
        else
        {
            Reel.value -= 0.02f;
        }
    }

    public void moveReel(float moveInterval)
    {
        currpos+=moveInterval;
        Reel.value = CalculateReelpos();
        //progression condition is defined here
        //fish collision

    }
    float CalculateReelpos()
    {
        return currpos / startpos;
    }
}
