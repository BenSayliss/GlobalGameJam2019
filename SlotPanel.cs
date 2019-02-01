using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPanel : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public int numberOfSlots;
    public GameObject slotPrefab;
    
    // Initialization
    void Awake()
    {
        for(int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(transform);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
            uiItems[i].item = null;
        }
    }

    // Update is called once per frame
    public void UpdateSlot(int slot, Item item)
    {
        uiItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
    }

    // return a list of items that aren't null
    public void EmptyAllSlots()
    {
        // TESTING//
        /*List<Item> tempItems = new List<Item>();
        foreach(UIItem uiItem in uiItems)
        {
            if(uiItem.item != null)
            {
                tempItems.Add(uiItem.item);
            }
        }*/
        uiItems.ForEach(i => i.UpdateItem(null));
        //return tempItems;
    }

    public bool ContainsEmptySlot()
    {
        foreach(UIItem uii in uiItems)
        {
            if (uii.item == null) {
                return true;
            }
        }
        return false;
    }

    public bool ContainsSlotToRemove(Item item)
    {
        foreach(UIItem uii in uiItems)
        {
            if (uii.item != null)
            {
                if (uii.item.id == item.id)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
