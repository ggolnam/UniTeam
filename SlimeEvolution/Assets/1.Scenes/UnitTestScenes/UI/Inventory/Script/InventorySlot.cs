using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ItemSlot
{

    public BackPack storage;
    public int SlotNum;
    public Stack<Item> Quatity;


    override protected Item observedItem
    {
        get
        {
            return (storage != null) ? storage.GetItem(SlotNum) : null;
            
        }
    }

    override protected Item Replace(Item item)
    {
        return (storage != null) ? storage.Replace(SlotNum, item) : item;
    }



}
