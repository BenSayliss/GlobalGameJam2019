using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private GameObject player;
    public GameObject harvest;

    public bool Destroyed = false;

    //Will get weapon used from overworld later
    public float damage = 2.0f;
    private float resourceTotal;

    // Use this for initialization
    void Start()
    {
        //Will be changed to whatever damage is used by weapon from overworld
        damage = 2.0f;
    }

    //As soon as character overlaps with animal prevents movement of character
    void OnTriggerEnter2D(Collider2D collision)
    {

        //Checks to see if the tag of gameobject is Hitbox
        if (collision.gameObject.CompareTag("HitBox"))
        {
            resourceTotal = collision.gameObject.GetComponent<Animals>().resource;

            player = gameObject;
            PlayerController script = player.GetComponent<PlayerController>();
            //Changes character movement to false
            script.move = false;
        }
    }

    //While character is in contact with gameobject with Hitbox tag. These statements happen.
    void OnTriggerStay2D(Collider2D collision)
    {
        //Creates a gameobject for to make a script to handle variables in PlayerController script
        player = gameObject;
        PlayerController script = player.GetComponent<PlayerController>();
        script._anim.SetBool("IsMoving", false);

        if (collision.gameObject.CompareTag("HitBox"))
        {
            //Checks to see if left mouse button clicked
            if (Input.GetMouseButtonDown(0))
            {
                GameObject.Find("Punch").GetComponent<AudioSource>().Play();
                Debug.Log("You are pressing the left mouse button.");

                //Everytime the left mouse button is clicked a certain amount of "health" is decreased from the animal
                collision.GetComponent<Animals>().resource -= damage;

                //Checks to see if animal has 0 "health". If so deletes gameobject Animal
                if (collision.GetComponent<Animals>().resource == 0)
                {
                    Debug.Log("You collected " + resourceTotal);

                    //Destroy!!!!!!!!!!!!
                    Destroy(collision.gameObject);
                    
                    //Allows movement again
                    script.move = true;

                    //Adds the resource from the animals to the food in the overworld
                    script.food += resourceTotal;
                }
            }
        }
    }
}
