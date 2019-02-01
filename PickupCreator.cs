using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickupCreator : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    Item thisItem;
    private List<Item> temporaryItemList = new List<Item>();
    public GameObject prefab;
    private Sprite[] spriteArray = new Sprite[3];
    public Sprite wood;
    public Sprite stone;
    public Sprite rope;

    public Text counterText;

    public int objectCounter;

    private float timer;

    public PlayerMovement player;

    public Text Instructions;

    private void Awake()
    {
        spriteArray[0] = wood;
        spriteArray[1] = stone;
        spriteArray[2] = rope;

        objectCounter = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 10.0f;
        // Create 5 materials with random locations
        for (int i = 0; i < 5; i++)
        {
            CreatePrefabInstance();
        }
    }

    // Update is called once per frame
    void Update()
    {

        counterText.text = "" + timer;

        timer -= Time.deltaTime;
        if (player.pickupedObject)
        {
            objectCounter--;
            player.pickupedObject = false;
        }     
        if (objectCounter < 5)
        {
            CreatePrefabInstance();
        }

        if(timer <= 0)
        {
            ChangeToCraftingScene();
        }
        
        
        //foreach (Item i in inventory.playerItems) {
        //    Debug.Log("Inventory Items: " + i.title);
        //}
    }

    float GetRandomNum(float min, float max)
    {
        return Random.Range(min, max);
    }
    int GetRandomNum(int min, int max)
    {
        return Random.Range(min, max);
    }

    private void CreatePrefabInstance()
    {
        
        Instantiate(prefab);

        float randomX = Random.Range(-7f, 7f);
        prefab.transform.position = new Vector2(randomX, 6f);

        if (prefab.transform.position.y < -5.0f)
        {
           prefab.transform.position = new Vector2(randomX, 6f);
        }

        // making sure the 
        /* if (player.transform.position.x < 0)
         {
             prefab.transform.position = new Vector2(GetRandomNum(0, 9), GetRandomNum(-4, 5));
         }
         else
         {
             prefab.transform.position = new Vector2(GetRandomNum(-8, 0), GetRandomNum(-4, 5));

         }
         prefab.GetComponent<SpriteRenderer>().sprite = spriteArray[GetRandomNum(0, 3)];
         objectCounter++;*/


        /* if (player.transform.position.x < 0)
         {
             float randomX = Random.Range(-7f, 7f);
             prefab.transform.position = new Vector2(randomX, 7f);
             prefab.transform.Translate(Vector3.down * Time.deltaTime * speed);
         }*/

        /* if (prefab.transform.position.y < -6.0f)
         {
             float randomX = Random.Range(-9f, 9f);
             transform.position = new Vector3(randomX, 6f, 0f);
         }*/

        prefab.GetComponent<SpriteRenderer>().sprite = spriteArray[GetRandomNum(0, 3)];
        objectCounter++; 
        /*transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -4.1f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 6f, 0f);
        } */
    }

    public void ChangeToCraftingScene()
    {

        SceneManager.LoadScene("Crafting");
    }


}
