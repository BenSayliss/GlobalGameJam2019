using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 movement;
    private Vector2 velocity;
    private Rigidbody2D rb2;

    public ItemDatabase itemDatabase;

    private Item itemPickup;

    public List<Item> playerItemList = new List<Item>();

    public bool pickupedObject;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        pickupedObject = false;
       
        
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb2.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pickup"))
        {
            itemPickup = itemDatabase.GetItem(collision.gameObject.GetComponent<SpriteRenderer>().sprite.name);
            PlayerData.GlobalList.Add(itemPickup);
            Debug.Log("itemPickup: " + itemPickup.title);
            // Add to inventory (other scene)
            


            pickupedObject = true;

            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }

        }
        

        

    }

    



}
