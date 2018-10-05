using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlotCtrl : MonoBehaviour {

    int InvSlotCol;
    int InvSlotRow;

    public List<Item> itemList;

    public List<ShopSlot> ShopSlot;

    public GameObject shopSlotPrefab;

    private void Awake()
    {
        MakeInventorySlot();
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
