using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSellSlot : ItemSlot
{
    public ShopSlotCtrl ShopSlotCtrl;
    public UILabel label;
    public int SlotNum;
    public int Quantity;
    public int MaxQuantity;

    protected override Item observedItem
    {
        get
        {
            return (ShopSlotCtrl != null) ? ShopSlotCtrl.GetItem(SlotNum) : null;
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
        if(mDraggedItem == null)
        {
            if(mItem!=null)
            {
                //인벤토리에 아이템추가
                //아이템 제거
                ShopSlotCtrl.Undo(SlotNum);
            }
            
        }
        else
        {
            ShopSlotCtrl.PutItem(SlotNum);
            mDraggedItem = null;
            BackPack.isInvClicked = false;
            UpdateCursor();
            Debug.Log("ShopSell1");
            BackPack.instance.itemToolTip.HideToolTip();


        }
    }

    void Update()
    {
        Item i = observedItem;

        if (mItem != null)
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
