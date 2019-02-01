using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FMG_FishingRodMov : MonoBehaviour
{
    public Slider Reel;
    public Slider Fish;
    public float startpos;
    public float minRange;
    public float maxRange;
    public float points;
  

    private FishDirection CurrentFishDirection;
    // Start is called before the first frame update
    void Start()
    {
        startpos = 0f;
        points = 0.01f;
        Reel.value = startpos;
        Fish.value = startpos;
        CurrentFishDirection = FishDirection.MovingUp;
    }

    // Update is called once per frame
    void Update()
    {
        minRange = Reel.value - 0.0f;
        maxRange = Reel.value + 0.5f;
        //Detect when the down arrow key has been released
        if (Input.GetKey(KeyCode.UpArrow))
        {

            
            increaseReel(0.05f);
            //Reel.value -= 0.02f;
        }
        decreaseReel(0.01f);
        MoveFish();
        if (Fish.value >= minRange && Fish.value <= maxRange)
        {
            if (points<=1)
            {
                points += 0.01f;
            }
            else if (points>=1)
            {
                points = 1;
            }
            
        }
        else
        {
            if (points>=0)
            {
                points -= 0.001f;
            }
            else if (points<=0)
            {
                points = 0;
            }
            
        }

    }

    private void decreaseReel(float movement)
    {
        Reel.value -= movement;
        if (Reel.value <=0)
        {
            Reel.value = startpos;
        }
    }

    private void increaseReel(float movement)
    {
        Reel.value += movement;
        if (Reel.value>=1)
        {
            Reel.value = 1;
        }

    }

    private void MoveFish()
    {

        if(CurrentFishDirection == FishDirection.MovingUp)
        {
            Fish.value += 0.01f;
            if(Fish.value == 1.0f)
            {
                CurrentFishDirection = FishDirection.MovingDown;
            }
        }
        else if(CurrentFishDirection == FishDirection.MovingDown)
        {
            Fish.value -= 0.01f;
            if (Fish.value == 0.0f)
            {
                CurrentFishDirection = FishDirection.MovingUp;
            }
        }

    }

    private enum FishDirection
    {
        MovingUp,
        MovingDown
    }
}
