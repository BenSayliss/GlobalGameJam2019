using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerClickToMove: MonoBehaviour
{

    public float speed = 1.5f; // Adjustable speed variable
    private Vector3 target; // Holder for Vector 3.

    void Start()
    {
        target = transform.position; // Sets the Vector 3 equal to the player's transform positon.
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) // If the Left mouse button is clicked....
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Transforms position from screen space into world space.
            target.z = transform.position.z; // target's z axis equals player's position's z.
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); // Move the charracter towards the target (mouse position) which is influenced by the speed variable and time.

    }

}