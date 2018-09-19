using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public UISprite icon;
    public Item item;
    public int SlotNum;
    public bool isEmpty;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.spriteName = item.SpriteName;

        icon.enabled = true;

        Debug.Log(icon.enabled);

    }

    public void ClearSlot()
    {
        item = null;

        icon.spriteName = null;
        icon.enabled = false;
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.Use(SlotNum);
        }
    }
}
