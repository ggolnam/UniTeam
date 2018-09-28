using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public enum Kind { Equipment, Disposable }
    public enum EquipmentSlotKind { Weapon, Shield, }

    public int ID;
    public string Name = null;
    public string SpriteName;
    public UIAtlas iconAtlas;

    public Kind ItemKind;
    public EquipmentSlotKind EquipSlotKind;

    public bool isDefalutItem = false;

    public int armorModifier;
    public int damageModifier;
    public virtual void Use(int slotNum)
    {
        Debug.Log("Using" + Name);

    }

}


