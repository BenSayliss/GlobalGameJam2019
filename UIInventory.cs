using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    public SlotPanel[] slotPanels;

    public void AddItemToUI(Item item)
    {
        foreach(SlotPanel sp in slotPanels)
        {
            if(sp.ContainsEmptySlot())
            {
                sp.AddNewItem(item);
                
                break;
            }
        }
    }

    public void RemoveItemFromUI(Item item)
    {
        foreach (SlotPanel sp in slotPanels)
        {
            if (sp.ContainsSlotToRemove(item))
            {
                sp.RemoveItem(item);
            }
        }
    }
}
