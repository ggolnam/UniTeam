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
    public Item Replace(int slot, Item item)
    {
        if (slot < InvSlotCol)
        {
            Item prev = items[slot];
            mItems[slot] = item;
            //if (item == null)
            //{
            //    prevQuantity = InvSlot[slot].Quantity;
            //    InvSlot[slot].Quantity = 1;
            //    InvSlot[slot].label.text ="";


            //}
            //else
            //{
            //    InvSlot[slot].Quantity = prevQuantity;
            //    InvSlot[slot].UpdateText();

            //}


            return prev;
        }
        return item;
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
                slot.Quantity = 1;
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
