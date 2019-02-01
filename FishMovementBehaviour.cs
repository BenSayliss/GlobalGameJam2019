using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishMovementBehaviour : MonoBehaviour
{
    public float MaxHeight;
    public float MinHeight;
    public float CurrHeight;
    public float RealCurrHeight;

    private FishDirection CurrentFishDirection;
    public Slider Fish;
    // Start is called before the first frame update
    void Start()
    {
        MaxHeight = 10;
        MinHeight = 0;
        CurrHeight = 0.01f;
        RealCurrHeight = 0.0f;
        CurrentFishDirection = FishDirection.MovingUp;
        Fish.value = CalcMov();
    }

    // Update is called once per frame
    void Update()
    {
        //check if the fish should be moving up or down
        if (CurrentFishDirection == FishDirection.MovingUp)
        {
            MoveUp(0.0003f);
        }
        else if (CurrentFishDirection == FishDirection.MovingDown)
        {
            MoveDown();
        }
    }
    private enum FishDirection
    {
        MovingUp,
        MovingDown
    }
    //what to do if the fish should be moving up
    private void MoveUp(float increment)
    {
        CurrHeight += increment;
        RealCurrHeight += CalcMov();
        Fish.value += CalcMov();
        if (Fish.value == 1.0f)
        {
            CurrentFishDirection = FishDirection.MovingDown;
        }
    }
    //what to do if the fish should be moving down
    private void MoveDown()
    {
        RealCurrHeight -= CalcMov();
        Fish.value -= CalcMov();
        if (Fish.value == 0.0f)
        {
            CurrentFishDirection = FishDirection.MovingUp;
        }
    }
    //create a method to calculate the currentprogress percent
    private float CalcMov()
    {
        return CurrHeight / MaxHeight;
    }
}
