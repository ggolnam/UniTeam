using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSellSlot : ItemSlot
{
    public ShopSlotCtrl ShopSlotCtrl;
    public int SlotNum;
    public int MaxQuantity;

    protected override Item ObservedItem
    {
        get
        {
            return (ShopSlotCtrl != null) ? ShopSlotCtrl.GetItem(SlotNum) : null;
        }
    }

    void OnClick()
    {
        if(DraggedItem == null)
        {
            if(Item!=null)
            {
                //인벤토리에 아이템추가
                //아이템 제거
                ShopSlotCtrl.CancelSell(SlotNum,Quantity,Item);
            }
            
        }
        else
        {
            ShopSlotCtrl.SendItem(SlotNum, Quantity, Item);

            DraggedItem = null;
            BackPack.isInvClicked = false;
            UpdateCursor();
        }
    }
}
