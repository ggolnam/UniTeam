using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ItemSlot
{
    public BackPack storage;
    public int SlotNum;
    public int MaxQuantity;



    override protected Item observedItem
    {
        get
        {
            return (storage != null) ? storage.GetItem(SlotNum) : null;
            
        }
    }

    void OnClick()
    {
        if (!BackPack.isInvClicked && mDraggedItem == null) 
        {
            //원래자리에 있던 아이템을 든다//
            //mDraggedItem을 mitem으로 설정
            storage.preslot = SlotNum;
            mDraggedItem = mItem;

            BackPack.isInvClicked = true;
            UpdateCursor();
            ////////////
            Vector3 pos = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
            storage.itemToolTip.ShowToolTip(storage.EquipItems, mItem, pos);
            storage.ResetSortButton();
            ////////////

            Debug.Log("INVEN");
        }
        else if (BackPack.isInvClicked && !BackPack.isEquipClicked) 
        {
            storage.Replace(SlotNum);
            mDraggedItem = null;
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
            mDraggedItem = null;
            BackPack.isEquipClicked = false;
            UpdateCursor();
            Debug.Log("INVEN2");

            storage.ResetSortButton();
        }

    }
}
