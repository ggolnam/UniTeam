using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour {

    //진
    public static bool isInvClicked;
    public static bool isEquipClicked;
    public int InvSlotCol;
    int InvSlotRow;
    int MaxQuatityNum;
    public int preslot;
    //data 불러올것//
    public int MyMoney;//{ get; set; }
    public ShopMediator ShopMediator;
    public UILabel MoneyLabel;

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

    private void Awake()
    {
        MaxQuatityNum = 100;
        MakeInventorySlot();
    }
    //돈 셋팅하기//
    public void SetMoney(int money)
    {
        MyMoney = money;
    }

    private void Update()
    {
        MoneyLabel.text = MyMoney.ToString();
    }
    //인벤토리 아이템 셋팅//
    public List<Item> Invitems
    {
        get { while (InvItems.Count < InvSlotCol) InvItems.Add(null); return InvItems; }
    }
    public Item GetItem(int slot)
    {
        return (slot < Invitems.Count) ? InvItems[slot] : null;
    }
    //장비창 아이템 셋팅//
    public Item GetEquip(Item.EquipmentSlotKind type)
    {
        return ((int)type < EquipSlots.Length) ? EquipItems[(int)type] : null;
    }
    //아이템 위치바꾸기//
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
    //샵에서 아이템 위치바꾸기//
    public void ReceiveItemFromShop(int slot,int quantity,Item item)
    {
        ShopMediator.SendItemToShop(slot, InvSlot[preslot].Quantity, InvItems[preslot]);
        itemToolTip.HideToolTip();

        InvSlot[preslot].Quantity = quantity;
        InvItems[preslot] = item;
    }
    //판매 취소//
    public void CancelSell(int quantity, Item item)
    {
        AddItemToSlot(quantity, item);
    }
    //장비 장착하기//
    public bool Equip(Item.EquipmentSlotKind equipmentSlotKind)
    {
        if (InvItems[preslot] != null)
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
        return false;
    }
    //장비 장착해제하기//
    public bool UnEquip(int slot)
    {
        Item previtem = EquipItems[preslot];

        if (InvItems[slot] != null)
                return false;
         
        EquipItems[preslot] = InvItems[slot];
        InvItems[slot] = previtem;

        return true;
    }
    //빈칸 정렬하기//
    public void OnClickFillItem()
    {
        FillBlank();
        FillItemButton.SetActive(false);
        SortItemButton.SetActive(true);
    }
    //아이템 번호순으로 정렬하기//
    public void OnClickSortItem()
    {
        SortItem();
        FillItemButton.SetActive(true);
        SortItemButton.SetActive(false);
    }
    //정렬버튼 초기화하기
    public void ResetSortButton()
    {
        FillItemButton.SetActive(true);
        SortItemButton.SetActive(false);
    }
    //아이템 정렬 함수//
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
                            min = j;
                    }
                }
                Invitems[i] = Invitems[min];
                Invitems[min] = temp;

                InvSlot[i].Quantity = InvSlot[min].Quantity;
                InvSlot[min].Quantity = prevQuan;
            }
        }
    }
    //빈칸 정렬 함수//
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
    //인벤토리 만들기//
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
    //아이템 추가하기//
    public void AddItemToSlot(int quantity, Item item)
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
                    InvSlot[i].Quantity = quantity;
                    InvSlot[i].isEmpty = false;
                    return;
                }
            }
        }
    }
    public bool CheckEmptySlot()
    {
        bool isEmpty = false;

        for (int i = 0; i < InvSlot.Count; i++)
        {
            if (InvSlot[i].isEmpty)
                isEmpty = true;
        }

        return isEmpty;

    }
    //소비아이템일경우 숫자올리기//
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
