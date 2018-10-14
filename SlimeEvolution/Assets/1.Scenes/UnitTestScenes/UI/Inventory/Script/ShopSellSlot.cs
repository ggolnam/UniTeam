using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSellSlot : ItemSlot
{
    public ShopSlotCtrl ShopSlotCtrl;
    public int SlotNum;
    public int MaxQuantity;

    protected override Item observedItem
    {
        get
        {
            return (ShopSlotCtrl != null) ? ShopSlotCtrl.GetItem(SlotNum) : null;
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
                ShopSlotCtrl.CancelSell(SlotNum,Quantity,mItem);
            }
            
        }
        else
        {
            ShopSlotCtrl.SendItem(SlotNum, Quantity, mItem);

            mDraggedItem = null;
            BackPack.isInvClicked = false;
            UpdateCursor();
        }
    }
}
