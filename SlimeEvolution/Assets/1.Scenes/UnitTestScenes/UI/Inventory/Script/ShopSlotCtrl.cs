using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlotCtrl : MonoBehaviour {

    int InvSlotCol;
    int InvSlotRow;

    public ShopConfirm shopConfirm;

    public List<Item> itemList;
    public List<ShopSlot> ShopSlot;
    public GameObject shopSlotPrefab;

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

    public void Undo(int slot)
    {
        BackPack.instance.AddItemToSlot(SellListItems[slot]);
        SellListItems[slot] = null;

        BackPack.instance.InvSlot[BackPack.instance.preslot].Quantity = SellListSlot[slot].Quantity;
        SellListSlot[slot].Quantity = 0;


    }
    public void PutItem(int slot)
    {
        int prevQuan = BackPack.instance.InvSlot[BackPack.instance.preslot].Quantity;
        BackPack.instance.InvSlot[BackPack.instance.preslot].Quantity =SellListSlot[slot].Quantity;
        SellListSlot[slot].Quantity = prevQuan;

        Item previtem = BackPack.instance.InvItems[BackPack.instance.preslot];
        BackPack.instance.InvItems[BackPack.instance.preslot] = SellListItems[slot];
        SellListItems[slot] = previtem;


    }
    public int SellmyItem()
    {
        int sum = 0;
        for (int slot = 0; slot < SellListSlot.Length; slot++)
        {
            sum = sum +SellListSlot[slot].mItem.Price;
            SellListItems[slot] = null;

        }
        return sum;

    }

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
