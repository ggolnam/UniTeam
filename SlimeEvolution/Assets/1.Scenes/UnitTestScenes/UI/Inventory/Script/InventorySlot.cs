using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ItemSlot
{

    public BackPack storage;
    public int SlotNum;
    public bool isEmpty;
    public Stack<Item> Quatity;


    override protected Item observedItem
    {
        get
        {
            return (storage != null) ? storage.GetItem(SlotNum) : null;
        }
    }

    /// <summary>
    /// Replace the observed item with the specified value. Should return the item that was replaced.
    /// </summary>

    override protected Item Replace(Item item)
    {
        return (storage != null) ? storage.Replace(SlotNum, item) : item;
    }



    ////////////////////////////////////////////////////////////////////
    //public void AddItem(Item newItem)
    //{
    //    item = newItem;

    //    icon.spriteName = item.SpriteName;

    //    icon.enabled = true;

    //    Debug.Log(icon.enabled);

    //}

    //public void ClearSlot()
    //{
    //    item = null;

    //    icon.spriteName = null;
    //    icon.enabled = false;
    //}
    //public void UseItem()
    //{
    //    if (item != null)
    //    {
    //        item.Use(SlotNum);
    //    }
    //}


}
