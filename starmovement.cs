using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starmovement : MonoBehaviour {

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-200f, 0));
    }
}
