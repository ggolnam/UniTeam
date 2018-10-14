﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlotCtrl : MonoBehaviour {

    int InvSlotCol;
    int InvSlotRow;
    public ShopMediator shopMediator;
    public ShopConfirm shopConfirm;
    public UILabel ResultPrice;

    [Header("ShopSlot")]
    public List<Item> itemList;
    public List<ShopSlot> ShopSlot;
    public GameObject shopSlotPrefab;
    [Header("SellSlot")]
    public Item[] SellListItems = new Item[10];
    public ShopSellSlot[] SellListSlot;
    public Item GetItem(int slot)
    {
        return (slot < SellListSlot.Length) ? SellListItems[slot] : null;
    }

    private void Awake()
    {
        MakeInventorySlot();
    }
    //판매취소//
    public void CancelSell(int slot, int quantity, Item item)
    {
        shopMediator.CancelSell(quantity, item);
        SellListItems[slot] = null;
        SellListSlot[slot].Quantity = 0;
    }
    //아이템보내기//
    public void SendItem(int slot, int quantity, Item item)
    {
        shopMediator.SendItemToInv(slot, quantity, item);
    }
    //아이템 받기//
    public void ReceiveItem(int slot, int quantity, Item item)
    {
        SellListSlot[slot].Quantity = quantity;
        SellListItems[slot] = item;
    }
    //물건값 계산하기//
    public int CalculateSum()
    {
        int sum = 0;
        for (int slot = 0; slot < SellListSlot.Length; slot++)
        {
            if (SellListItems[slot] != null) 
                sum = sum + (int)(SellListItems[slot].Price *SellListSlot[slot].Quantity* 0.8);
        }
        return sum;
    } 
    //아이템 판매하기//
    public void SellmyItem()
    {
        int sum = CalculateSum();
        for (int slot = 0; slot < SellListSlot.Length; slot++)
        {
            SellListItems[slot] = null;
            SellListSlot[slot].Quantity = 0;
        }

        shopMediator.SetMnoey(shopMediator.GetMoney() + sum);
        CalculateSum();
    }
    void Update()
    {
        ResultPrice.text = CalculateSum().ToString();
    }
    //SellSlot만들기//
    void MakeInventorySlot()
    {
        InvSlotCol = 3;
        InvSlotRow = 4;
        InvSlotCol *= InvSlotRow;
        for (int x = 0; x < InvSlotCol; x++)
        {
            GameObject go = NGUITools.AddChild(gameObject, shopSlotPrefab);

            ShopSlot slot = go.GetComponent<ShopSlot>();
            if (slot != null)
            {
                slot.storage = this;
                slot.SlotNum = x;
                slot.name = "ShopSlot [ " + x + " ]";
                slot.item = itemList[x];

                ShopSlot.Add(slot);
            }

        }
    }

}



//public void PutItem(int slot)
//{
//    int prevQuan = BackPack.instance.InvSlot[BackPack.instance.preslot].Quantity;
//    BackPack.instance.InvSlot[BackPack.instance.preslot].Quantity =SellListSlot[slot].Quantity;
//    SellListSlot[slot].Quantity = prevQuan;

//    Item previtem = BackPack.instance.InvItems[BackPack.instance.preslot];
//    BackPack.instance.InvItems[BackPack.instance.preslot] = SellListItems[slot];
//    SellListItems[slot] = previtem;


//}
//public void Undo(int slot)
//{
//    BackPack.instance.AddItemToSlot(SellListItems[slot]);
//    SellListItems[slot] = null;

//    BackPack.instance.InvSlot[BackPack.instance.preslot].Quantity = SellListSlot[slot].Quantity;
//    SellListSlot[slot].Quantity = 0;


//}