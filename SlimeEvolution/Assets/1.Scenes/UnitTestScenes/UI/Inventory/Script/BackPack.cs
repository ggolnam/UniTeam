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
    public static bool isInvClicked;
    public static bool isEquipClicked;

    public GameObject inventroySlotPrefab;
    public List<InventorySlot> InvSlot;
    public EquipmentSlot[] EquipSlots;
    public int InvSlotCol;
    int InvSlotRow;

    public int preslot;

    public int MaxQuatityNum;

    public List<Item> InvItems = new List<Item>();

    public List<Item> Invitems
    {
        get { while (InvItems.Count < InvSlotCol) InvItems.Add(null); return InvItems; }
    }

    public Item GetItem(int slot)
    {
        return (slot < Invitems.Count) ? InvItems[slot] : null;
    }
    public Item[] EquipItems = new Item[2];


    public Item GetEquip(EquipmentSlotType type)
    {
        return ((int)type < EquipSlots.Length) ? EquipItems[(int)type] : null;

    }
    public void Replace(int slot)
    {
        if (slot < InvSlotCol)
        {
            int prevQuan = InvSlot[preslot].Quantity;
            InvSlot[preslot].Quantity = InvSlot[slot].Quantity;
            InvSlot[slot].Quantity = prevQuan;
            
            Item previtem = InvItems[preslot];
            InvItems[preslot] = InvItems[slot];
            InvItems[slot] = previtem;

        }

    }
    public void Equip(EquipmentSlotType type)
    {
        Item previtem = InvItems[preslot];

        if (previtem.Type == ItemType.Equipment)
        {
            if (previtem is TestEquipment)
            {
                TestEquipment Equip = (TestEquipment)previtem;

                if (Equip.equipSlot == type)
                {
                    InvItems[preslot] = EquipItems[(int)type];
                    EquipItems[(int)type] = previtem;
                    InvSlot[preslot].Quantity = 0;
                }
            }
        }
    }
    public void UnEquip(int slot)
    {
        Item previtem = EquipItems[preslot];
        if (InvItems[slot]!= null)
        {
            if (InvItems[slot].Type == ItemType.Equipment)
            {
                EquipItems[preslot] = InvItems[slot];
                InvItems[slot] = previtem;
            }
        }
        else
        {
            EquipItems[preslot] = InvItems[slot];
            InvItems[slot] = previtem;
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
                    InvItems[i] = item;
                    InvSlot[i].Quantity++;
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
            if (InvItems[i] != null && item.ID == InvItems[i].ID && item.Type == ItemType.Disposable && InvSlot[i].Quantity < MaxQuatityNum)
            {
                InvSlot[i].Quantity++;
                isbool = true;
                break;
            }
        }      
        return isbool;
    }
}
