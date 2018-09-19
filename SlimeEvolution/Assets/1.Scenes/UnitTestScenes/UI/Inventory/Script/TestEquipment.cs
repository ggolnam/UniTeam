using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class TestEquipment : Item
{


    public EquipmentSlot equipSlot;
    public int armorModifier;
    public int damageModifier;


    public override void Use(int slotNum)
    {
        base.Use(slotNum);
        RemoveFromInventory(slotNum);
        TestEquipmentManager.instance.Equip(this, slotNum);
        Debug.Log("eqiped");
        //아이템 제거//


    }

}
    public enum EquipmentSlot { Head, Weapon, Shield }

