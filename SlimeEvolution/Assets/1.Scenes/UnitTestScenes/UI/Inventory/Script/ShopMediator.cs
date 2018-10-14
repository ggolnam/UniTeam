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
    public void AddItemToInv(Item item)
    {
        backPack.AddItemToSlot(item);
    }
    //돈 받아오기//
    public int GetMoney()
    {
        int money = 0;
        money = backPack.MyMoney;
        return money; 
    }
    //돈 셋팅//
    public void SetMnoey(int money)
    {
        backPack.SetMoney(money);
    }
}
