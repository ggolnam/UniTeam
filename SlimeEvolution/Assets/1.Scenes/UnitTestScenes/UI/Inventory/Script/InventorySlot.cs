using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ItemSlot
{

    public BackPack storage;
    public UILabel label;
    public int SlotNum;
    static bool isClicked;

    
    

    override protected Item observedItem
    {
        get
        {
            return (storage != null) ? storage.GetItem(SlotNum) : null;
            
        }
    }


    public void UpdateText()
    {
        if (Quantity == 0)
        {
            label.text = "";
        }
        else
        {
            label.text = Quantity.ToString();
        }
    }

    void OnClick()
    {

        if (mItem != null && isClicked == false) 
        {
            //원래자리에 있던 아이템을 든다//
            //mDraggedItem을 mitem으로 설정
            storage.preslot = SlotNum;
            mDraggedItem = mItem;

            isClicked = true;
            UpdateCursor();
        }
        else
        {
            storage.Replace(SlotNum);
            mDraggedItem = null;
            isClicked = false;
            Debug.Log("REPLACE");
            UpdateCursor();
        }

        Debug.Log("OnClick");
    }
   
    void UpdateCursor()
    {
        if (mDraggedItem != null && mItem != null)
        {
            UICursor.Set(mDraggedItem.iconAtlas, mDraggedItem.SpriteName);
        }
        else
        {
            UICursor.Clear();
        }
    }


}
