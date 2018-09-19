using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEquipmentManager : MonoBehaviour {


    #region Singleton
    public static TestEquipmentManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    public List<TestEquipment> currentEquipment;
    TestInventory inventory;

    public delegate void OnEquipmentChanged(TestEquipment newItem, TestEquipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start()
    {
        inventory = TestInventory.instance;


        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        for (int i = 0; i < numSlots; i++)
        {
            currentEquipment.Add(new TestEquipment());
        }

    }
    public void Equip(TestEquipment newItem, int slotNum)
    {
        int slotIndex = (int)newItem.equipSlot;

        TestEquipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.ChangeSlot(slotNum, oldItem);
        }
        currentEquipment[slotIndex] = newItem;

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);
    }
    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            TestEquipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = new TestEquipment();

            if (onEquipmentChanged != null)
                onEquipmentChanged.Invoke(null, oldItem);
        }
    }
    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Count; i++)
        {
            Unequip(i);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
