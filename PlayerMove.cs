using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{ 
    // © 2017 TheFlyingKeyboard and released under MIT License
    // theflyingkeyboard.net
    //Moves object between two points
    [SerializeField] private Transform objectToMove;
    [SerializeField] private bool moveThisObject = false;
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<Transform> points;
    private int counter;
    public bool goBack;

    public GetWater WaterFun;

    // Use this for initialization
    void Start()
    {
        counter = 0;
        goBack = false;
        if (moveThisObject)
        {
            objectToMove = transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (counter == (points.Count - 1))
        {
            goBack = true;
        }
        else if (counter == 0)
        {
            goBack = false;
        }
        if (objectToMove.position == points[counter].position)
        {
           if (Input.GetKeyDown(KeyCode.D) && !WaterFun.DontMove)
                {
                    counter++;
                }
                
            
            else
            {
                if (Input.GetKeyDown(KeyCode.A) && !WaterFun.DontMove)
                {
                    counter--;
                 
                } 
            }
        }

        objectToMove.position = Vector3.MoveTowards(objectToMove.position, points[counter].position, moveSpeed * Time.deltaTime);
        goBack = true;
    }
}