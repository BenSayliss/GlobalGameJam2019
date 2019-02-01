using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public List<Item> playerItems = new List<Item>();
    [SerializeField]
    public UIInventory inventoryUI;
    ItemDatabase itemDatabase;
    public UICraftResult uiCraftResult;

    // Test things ******
    public List<Item> tempItems = new List<Item>();

    public List<Item> craftingItems = new List<Item>();



    
    // *******************


    private void Awake()
    {
        itemDatabase = FindObjectOfType<ItemDatabase>();
        DontDestroyOnLoad(this.gameObject);
        
    }

    private void Start()
    {
        
        Debug.Log("START LEFTOVER COUNT: " + uiCraftResult.leftoverItems.Count);
        Debug.Log("START GLOBAL COUNT: " + PlayerData.GlobalList.Count);

        foreach (Item item in PlayerData.GlobalList)
        {
            GiveItem(item.id);
        }
        uiCraftResult.leftoverItems.Clear();
        

       

    }

    private void Update()
    {
        Debug.Log("Length of Global Database: " + PlayerData.GlobalList.Count);
        foreach(Item i in PlayerData.GlobalList)
        {
            Debug.Log("ItemInGlobal: " + i.title);
        }

        Debug.Log("Length of inventory list: " + playerItems.Count);

    }

    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        inventoryUI.AddItemToUI(itemToAdd);
        playerItems.Add(itemToAdd);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        inventoryUI.AddItemToUI(itemToAdd);
        playerItems.Add(itemToAdd);
    }
    
    public Item CheckForItem(int id)
    {
        return playerItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);

        if(itemToRemove != null)
        {
            playerItems.Remove(itemToRemove);
        }
    }

    public void GatheringScene()
    {
        
        // Remove the elements from the list

        Debug.Log("DatabaseItems: " + PlayerData.GlobalList.Count);
        Debug.Log("PlayerItems: " + playerItems.Count);
        // try this out         
        if (uiCraftResult.leftoverItems.Count > 0)
        {
            PlayerData.GlobalList.Clear();
        }
        foreach (Item i in uiCraftResult.leftoverItems)
        {
            PlayerData.GlobalList.Add(i);
        }
        Debug.Log("FINALDATABASE COUNT: " + PlayerData.GlobalList.Count);


        // NEW STUFF
        float woodCounter = 0;
        float stoneCounter = 0;


        foreach(Item i in PlayerData.GlobalList)
        {
            if(i.title == "Wood")
            {
                woodCounter++;
            }
            if(i.title == "Stone")
            {
                stoneCounter++;
            }
        }

        PlayerData.Wood += woodCounter * 10;
        PlayerData.Stone += stoneCounter * 10;

        // GET RID OF THIS LATER
        PlayerData.GlobalList.Clear();

        SceneManager.LoadScene("Overworld_Main");
    }

   
}
