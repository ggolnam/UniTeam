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
    public int InvSlotCol;
    int InvSlotRow;
    public int MaxQuatityNum;
    public int preslot;

    public int MyMoney;

    public GameObject SortItemButton;
    public GameObject FillItemButton;
    public ItemToolTip itemToolTip;

    [Header("Inventory")]
    public GameObject inventroySlotPrefab;
    public List<Item> InvItems = new List<Item>();
    public List<InventorySlot> InvSlot;
    [Header("Equipement")]
    public Item[] EquipItems = new Item[2];
    public EquipmentSlot[] EquipSlots;
    


    public List<Item> Invitems
    {
        get { while (InvItems.Count < InvSlotCol) InvItems.Add(null); return InvItems; }
    }
    public Item GetItem(int slot)
    {
        return (slot < Invitems.Count) ? InvItems[slot] : null;
    }
    public Item GetEquip(Item.EquipmentSlotKind type)
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
    public bool Equip(Item.EquipmentSlotKind equipmentSlotKind)
    {
        Item previtem = InvItems[preslot];

        if (previtem.ItemKind != Item.Kind.Equipment || previtem.EquipSlotKind != equipmentSlotKind)
        {
            Debug.Log("not a Equipment");
            return false;
        }

        InvItems[preslot] = EquipItems[(int)equipmentSlotKind];
        EquipItems[(int)equipmentSlotKind] = previtem;
        InvSlot[preslot].Quantity = 0;

        return true;

    }
    public bool UnEquip(int slot)
    {
        Item previtem = EquipItems[preslot];

        if (InvItems[slot] != null)
                return false;
         
        EquipItems[preslot] = InvItems[slot];
        InvItems[slot] = previtem;

        return true;
    }


    public void OnClickFillItem()
    {
        FillBlank();
        FillItemButton.SetActive(false);
        SortItemButton.SetActive(true);
    }
    public void OnClickSortItem()
    {
        SortItem();
        FillItemButton.SetActive(true);
        SortItemButton.SetActive(false);
    }
    public void ResetSortButton()
    {
        FillItemButton.SetActive(true);
        SortItemButton.SetActive(false);
    }

     void SortItem()
    {
        int i = 0, j = 0, min = 0;
        int prevQuan = 0;
        Item temp = null;

        for ( i = 0; i < InvItems.Count - 1; i++)
        {
            if (Invitems[i] != null)
            {
                temp = Invitems[i];
                prevQuan = InvSlot[i].Quantity;
                min = i;

                for ( j = i + 1; j < InvItems.Count; j++)
                {
                    if (Invitems[j] != null)
                    {
                        if (InvItems[j].ID < InvItems[min].ID)
                        {
                            min = j;
                        }
                    }
                }
                Invitems[i] = Invitems[min];
                Invitems[min] = temp;

                InvSlot[i].Quantity = InvSlot[min].Quantity;
                InvSlot[min].Quantity = prevQuan;
            }
        }
    }
     void FillBlank()
    {
        int prevQuan =0;
        Item temp =null;
        for (int i = 0; i < InvItems.Count-1; i++)
        {
            if (Invitems[i] == null)
            {
                temp = Invitems[i];
                prevQuan = InvSlot[i].Quantity;

                for (int j = i + 1; j < InvItems.Count; j++) 
                {
                    if (Invitems[j] != null)
                    {
                        Invitems[i] = Invitems[j];
                        Invitems[j] = temp;
                        InvSlot[i].Quantity = InvSlot[j].Quantity;
                        InvSlot[j].Quantity = prevQuan;
                        break;
                    }
                }
            }
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
            if (InvItems[i] != null && item.ID == InvItems[i].ID && item.ItemKind == Item.Kind.Disposable && InvSlot[i].Quantity < MaxQuatityNum)
            {
                InvSlot[i].Quantity++;
                isbool = true;
                break;
            }
        }      
        return isbool;
    }
}
