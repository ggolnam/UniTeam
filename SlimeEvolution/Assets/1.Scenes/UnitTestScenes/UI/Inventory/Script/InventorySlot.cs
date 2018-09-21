using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ItemSlot
{

    public BackPack storage;
    public UILabel label;
    public int SlotNum;
    public int Quantity;
    public int MaxQuantity;
    
    

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
    public void UpdateText()
    {
        label.text = Quantity.ToString();
    }

    public void ClearSlot()
    {

    }


}
