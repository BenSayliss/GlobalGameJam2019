using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingRodMovBehavior : MonoBehaviour
{
    public float MaxHeight;
    public float MinHeight;
    public float CurrHeight;
    public float RealCurrHeight;

    public Slider FishingRod;
    // Start is called before the first frame update
    void Start()
    {
        MaxHeight = 10;
        MinHeight = 0;
        CurrHeight = 0.01f;
        RealCurrHeight = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            //when the condition is met, what do we do with the information
            moveUp(0.09f);
        }
        if (CurrHeight>=MinHeight)
        {
            moveDown(-0.07f);
        }
        else if (CurrHeight<=MinHeight)
        {
            CurrHeight = MinHeight;
        }
        RealCurrHeight = FishingRod.value;
    }

    private void moveUp(float increment)
    {
        if (CurrHeight<=MaxHeight)
        {

            CurrHeight += increment;
        }
        else if (CurrHeight>=MaxHeight)
        {
            CurrHeight = MaxHeight;
        }
        
        FishingRod.value += CalcMov();
    }
    private void moveDown(float increment)
    {
        CurrHeight += increment;
        FishingRod.value += CalcMov();
    }
    //create a method to calculate the currentprogress percent
    private float CalcMov()
    {
        return CurrHeight / MaxHeight;
    }

}
