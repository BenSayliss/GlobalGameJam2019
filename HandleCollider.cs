using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollider : MonoBehaviour
{
    public float MaxRange;
    public float MinRange;
    public bool colliding;
    public float points;

    public float difference;

    public FishingRodMovBehavior Reel;
    public FishMovementBehaviour fish;
    // Start is called before the first frame update
    void Start()
    {
        MaxRange = Reel.FishingRod.value + 0.5f;
        MinRange = Reel.FishingRod.value - 0.5f;
        points = 0.1f;
        colliding = false;
        difference = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(fish.RealCurrHeight - Reel.RealCurrHeight) < difference) 
        { 
            colliding = true;
            points += 0.05f; // to change point value
        }
        else
        {
            colliding = false;
            points -= 0.05f;
        }
    }
}
