using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour {

    #region Singleton
    public static BackPack instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        MakeInventorySlot();

    }
    #endregion

    public GameObject inventroySlotPrefab;
    public List<InventorySlot> InvSlot;
    public int InvSlotCol;
    int InvSlotRow;

    public int preslot;

    public int MaxQuatityNum;

    public List<Item> mItems = new List<Item>();

    public List<Item> items
    {
        get { while (mItems.Count < InvSlotCol) mItems.Add(null); return mItems; }
    }

    public Item GetItem(int slot)
    {
        return (slot < items.Count) ? mItems[slot] : null;
    }
    public void Replace(int slot)
    {
        if (slot < InvSlotCol)
        {
            int prevQuan = InvSlot[preslot].Quantity;
            InvSlot[preslot].Quantity = InvSlot[slot].Quantity;
            InvSlot[slot].Quantity = prevQuan;

            Item previtem = mItems[preslot];
            mItems[preslot] = mItems[slot];
            mItems[slot] = previtem;

            InvSlot[slot].UpdateText();
            InvSlot[preslot].UpdateText();

            InvSlot[slot].Quantity = prevQuan;

        }

    }

    void MakeInventorySlot()
    {
        InvSlotRow = 4;
        InvSlotCol *= InvSlotRow;
        for (int x = 0; x < InvSlotCol; x++)
        {
            GameObject go = NGUITools.AddChild(gameObject, inventroySlotPrefab);

            InventorySlot slot = go.GetComponent<InventorySlot>();
            if(slot != null)
            {
                slot.storage = this;
                slot.SlotNum = x;
                slot.isEmpty = true;
                slot.name = "Slot [ " + x + " ]";
                slot.label.text = "";
                slot.Quantity = 0;
                slot.MaxQuantity = MaxQuatityNum;
                InvSlot.Add(slot);
            }

        }
    }

    public void AddItemToSlot(Item item)
    {
        for (int i = 0; i < InvSlot.Count; i++)
        {
            if (CheckSameItem(item))
                return;
            else
            {
                if (InvSlot[i].isEmpty)
                {
                    mItems[i] = item;
                    InvSlot[i].Quantity++;
                    InvSlot[i].UpdateText();
                    return;
                }
            }
        }
    }
    bool CheckSameItem(Item item)
    {
        bool isbool = false;
        for (int i = 0; i < InvSlot.Count; i++)
        {
            if (mItems[i] != null && item.ID == mItems[i].ID && item.Type == ItemType.Disposable && InvSlot[i].Quantity < MaxQuatityNum)
            {
                InvSlot[i].Quantity++;
                InvSlot[i].UpdateText();
                isbool = true;
                break;
            }
        }      
        return isbool;
    }

    //아이템먹을때 어느슬랏에 넣을지 
    //Equipment , Disposable


}
