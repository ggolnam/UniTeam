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


    public void UpdateText()
    {
        if (mItem.ItemKind == Item.Kind.Equipment)
        {
            label.text = "";
        }
        else if (Quantity == 0)
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

            //storage.HideToolTip();



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
   
    void Update()
    {
        Item i = observedItem;

        if(mItem != null)
        {
            UpdateText();
        }


        if (mItem != i)
        {
            mItem = i;

            if (icon != null)
            {
                if (mItem == null || mItem.iconAtlas == null)
                {
                    icon.enabled = false;
                    isEmpty = true;
                }
                else
                {
                    icon.atlas = mItem.iconAtlas;
                    icon.spriteName = mItem.SpriteName;
                    icon.enabled = true;
                    isEmpty = false;

                    icon.MakePixelPerfect();
                }
            }
        }

    }

}
