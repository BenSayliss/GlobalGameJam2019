﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlots : MonoBehaviour
{
    public CraftRecipeDatabase recipeDatabase;
    public List<UIItem> uiItems = new List<UIItem>();
    public UIItem craftResultSlot;
    public int[] itemRecipe = new int[9];

  
    public void UpdateRecipe()
    {
        int[] itemTable = new int[uiItems.Count];
        for(int i = 0; i < uiItems.Count; i++)
        {
            if(uiItems[i].item != null)
            {
                itemTable[i] = uiItems[i].item.id;

            }
        }
        Item itemToCraft = recipeDatabase.CheckRecipe(itemTable);
        
        UpdateCraftingResultSlot(itemToCraft);
        
    }

    public int[] GetRecipe(int i)
    {
        return recipeDatabase.ReturnItemRecipe(i);
    }

    void UpdateCraftingResultSlot(Item itemToCraft)
    {
        craftResultSlot.UpdateItem(itemToCraft);
    }

    // Start is called before the first frame update
    private void Start()
    {
        uiItems = GetComponent<SlotPanel>().uiItems;
        uiItems.ForEach(i => i.craftingSlot = true);
    }

}
