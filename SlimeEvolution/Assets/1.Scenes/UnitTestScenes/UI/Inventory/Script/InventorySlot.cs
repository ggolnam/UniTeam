using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ItemSlot
{
    public BackPack storage;
    public int SlotNum;
    public int MaxQuantity;



    override protected Item ObservedItem
    {
        get
        {
            return (storage != null) ? storage.GetItem(SlotNum) : null;
            
        }
    }

    void OnClick()
    {
        if (!BackPack.isInvClicked && DraggedItem == null) 
        {

            if (Item != null)
            {
                storage.preslot = SlotNum;
                DraggedItem = Item;

                BackPack.isInvClicked = true;
                UpdateCursor();

                Vector3 pos = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
                storage.itemToolTip.ShowToolTip(storage.EquipItems, Item, pos);
                storage.ResetSortButton();
                
                Debug.Log("INVEN");
            }
            Debug.Log("NullItem");

        }
        else if (BackPack.isInvClicked && !BackPack.isEquipClicked) 
        {
            storage.Replace(SlotNum);
            DraggedItem = null;
            BackPack.isInvClicked = false;
            BackPack.isEquipClicked = false;
            UpdateCursor();
            Debug.Log("INVEN1");

            storage.itemToolTip.HideToolTip();
            storage.ResetSortButton();

        }
        else
        {
            storage.UnEquip(SlotNum);
            DraggedItem = null;
            BackPack.isEquipClicked = false;
            UpdateCursor();
            Debug.Log("INVEN2");

            storage.ResetSortButton();
        }

    }
}
