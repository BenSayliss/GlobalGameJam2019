using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Creates a variable for speed and a bool for movement
    public float speed;
    public bool move;
    public Animator _anim;
    private float horizontalMove = 0.0f;

    //Will go to overworld later
    public float food;

    // Use this for initialization
    void Start()
    {
        //Used in collect to prevent movement in front of animal
        move = true;
        food = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checks to see if move equals true. If false prevents movement
        if (move == true)
        {
            //Horizontal movement only in positive direction
            if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal");
                _anim.SetFloat("Move", Mathf.Abs(horizontalMove));
                _anim.SetBool("IsMoving", true);
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0.0f, 0.0f));
            }
            else if (Input.GetAxisRaw("Horizontal") < 0.5f)
            {        
                _anim.SetBool("IsMoving", false);
            }
        }

    }

    }