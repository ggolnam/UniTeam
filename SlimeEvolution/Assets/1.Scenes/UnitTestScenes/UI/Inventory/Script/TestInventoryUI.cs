using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventoryUI : MonoBehaviour {

    public Transform itemsParent;

    TestInventory inventory;
    [SerializeField]
    InventorySlot[] slots;
    // Use this for initialization
    void Start()
    {
        inventory = TestInventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;
        inventory.OnitemRemoveCallback += ClearSlotUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        Debug.Log("Update");

    }
    void ClearSlotUI(int slotNum)
    {
        slots[slotNum].ClearSlot();
        Debug.Log("Clear");
    }
}
