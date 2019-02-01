using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();
    public Item[] itemArray = new Item[24];

    void Awake()
    {
        BuildItemDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id); // goes through every item and compares the item
                                                  // id to the id being passed in
    }

    public Item GetItem(string title)
    {
        return items.Find(item => item.title == title); // goes through every item and compares the item
                                                        // title to the title being passed in
    }

    // creating a database for all items in the game
    void BuildItemDatabase()
    {


        items = new List<Item>()
        {
            new Item(1, "Wood", "A fascinating piece of wood.", 
            new Dictionary<string, int> {
                { "Value", 15 }
            }),

            new Item(2, "Stone", "A rock.",
            new Dictionary<string, int> {
                { "Value", 20 },
            }),

            new Item(3, "Rope", "A rope.",
            new Dictionary<string, int> {
                { "Value", 5 }
            }),

            new Item(4, "Knife", "A knife",
            new Dictionary<string, int> {
                { "Power", 4 },
                { "Value", 20 }
            }),


            new Item(5, "Bow", "A wood bow.",
            new Dictionary<string, int> {
                { "Power", 5 },
                { "Value", 25 }
            }), 

            new Item(6, "Spear", "A spear.", 
            new Dictionary<string, int>
            {
                { "Power", 10},
                { "Value", 20}
            }), 

            new Item(7, "Sword", "A sword.",
            new Dictionary<string, int>
            {
                { "Power", 15 },
                { "Value", 10}
            }),

            new Item(8, "Fishing Pole", "A fishing pole.",
            new Dictionary<string, int>
            {
                { "Value", 10}
            })
        };
    }
    
}
