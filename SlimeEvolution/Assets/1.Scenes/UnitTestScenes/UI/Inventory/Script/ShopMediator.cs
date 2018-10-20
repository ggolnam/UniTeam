using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMediator : AbstractVillageMediator
{
    [SerializeField]
    ShopSlotCtrl shopSlotCtrl;
    [SerializeField]
    BackPack backPack;
    [SerializeField]
    ShopConfirm shopConfirm;
    [SerializeField]
    ItemToolTip ItemToolTip;


    //판매취소//
    public void CancelSell(int quantity, Item item)
    {
        backPack.CancelSell(quantity, item);
    }
    //샵으로 판매할 아이템보내기//
    public override void SendItemToShop(int slot,int quantity, Item item)
    {

        shopSlotCtrl.ReceiveItem(slot, quantity, item);
    }
    //인벤토리로 아이템 보내기//
    public void SendItemToInv(int slot ,int quantity,Item item)
    {
        backPack.ReceiveItemFromShop(slot, quantity, item);
        //backPack
    }
    //인벤토리에 아이템 추가//
    public void AddItemToInv(int quantity, Item item)
    {
        backPack.AddItemToSlot(quantity, item);
    }
    //돈 받아오기//
    public int GetMoney()
    {
        return backPack.MyMoney; 
    }
    //돈 셋팅//
    public void SetMnoey(int money)
    {
        backPack.SetMoney(money);
    }
    public bool IsInvEmpty()
    {
        return backPack.CheckEmptySlot();
    }
    public void HideShopUI()
    {
        shopConfirm.OnClickedBackButton();
        shopSlotCtrl.ReturnItemToInv();
        HideToolTip();
    }
    public void ShowConfirmPanel(Item item)
    {
        ItemToolTip.ShowShopToolTip(item);
        shopConfirm.SetPanel(item);
    }
    public void HideToolTip()
    {
        ItemToolTip.HideToolTip();

    }
}
