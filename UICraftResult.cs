using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICraftResult : MonoBehaviour, IPointerDownHandler
{
    public SlotPanel slotPanel;
    public Inventory inventory;
    public List<Item> recipeItems = new List<Item>();
    private List<Item> tempItems = new List<Item>();
    public CraftingSlots craftingSlots;

   // public List<Item> craftedItems = new List<Item>();
    public List<Item> leftoverItems = new List<Item>();
    //public List<Item> removeItems = new List<Item>();


    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("xPos:" + eventData.position.x);
        //Debug.Log("yPos: " + eventData.position.y);
        UIItem craftingResultItem = craftingSlots.craftResultSlot;
        if (eventData.position.x > 520 && eventData.position.x < 590 && eventData.position.y < 170 && eventData.position.y > 100 )
        {
            
        } else
        {
            Item testUIItem = GetComponent<UIItem>().item;
            slotPanel.EmptyAllSlots();
            PlayerData.GlobalList.Add(testUIItem);
            //inventory.playerItems.Add(GetComponent<UIItem>().item);
            Debug.Log("This");
            Debug.Log("Inventory STUFF: " + testUIItem.ToString());
        }
        
    }

    public void CraftItem()
    {


        // WORKING?!?!?
        Item craftingResultItem = craftingSlots.craftResultSlot.item;
        if (craftingResultItem != null)
        {
            Debug.Log("CRAFTED ITEM NAME: " + craftingResultItem.title);

            int[] itemRecipe = new int[9];
            itemRecipe = craftingSlots.GetRecipe(craftingResultItem.id);

            leftoverItems.Clear();
            
            // Add recipeItems back to inventory
            //PlayerData.GlobalList.Add(craftingResultItem);
            foreach (UIItem uIitem in inventory.inventoryUI.slotPanels[0].uiItems)
            {
                if (uIitem.item != null)
                {
                    leftoverItems.Add(uIitem.item);
                }
            }

            //craftedItems.Clear();
            inventory.playerItems.Add(craftingResultItem);
            inventory.inventoryUI.AddItemToUI(craftingResultItem);
            
            slotPanel.EmptyAllSlots();

            // craftedItems.Add(craftingResultItem);
            leftoverItems.Add(craftingResultItem);

            Debug.Log("LEFTOVER ITEMS COUNT: " + leftoverItems.Count);
            //Debug.Log("CRAFTED ITEMS COUNT: " + craftedItems.Count);
        }

    }
     
        /*for (int i = 0; i < craftingSlots.uiItems.Count; i++)
        {
            if(craftingSlots.uiItems[i].item != null)
            {
                Debug.Log("REMOVEDITEM");
                PlayerData.GlobalList.Remove(craftingSlots.uiItems[i].item);
                inventory.inventoryUI.RemoveItemFromUI(craftingSlots.uiItems[i].item);

                

            }
            break;
        }*/
    
}

