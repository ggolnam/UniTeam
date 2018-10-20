using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ItemSlot{

    public BackPack storage;
    public Item.EquipmentSlotKind equipmentSlotType;


    protected override Item ObservedItem
    {
        get
        {
            return (storage != null) ? storage.GetEquip(equipmentSlotType) : null;
        }
    }

    void Start()
    {
        storage = GameObject.FindWithTag("BACKPACK").GetComponent<BackPack>();
        isEquipSlot = true;
    }
    void OnClick()
    {
        if (!BackPack.isEquipClicked && DraggedItem == null) 
        {
            if (Item != null)
            {

                DraggedItem = Item;
                storage.preslot = (int)equipmentSlotType;
                BackPack.isEquipClicked = true;
                UpdateCursor();
                Debug.Log("EQUIP");
            }
            Debug.Log("NullItem");

        }
        else if (BackPack.isEquipClicked && !BackPack.isInvClicked) 
        {
            DraggedItem = null;
            BackPack.isEquipClicked = false ;
            BackPack.isInvClicked = false;
            UpdateCursor();
            Debug.Log("EQUIP1");

        }
        else
        {
            storage.Equip(equipmentSlotType);
            DraggedItem = null;
            BackPack.isInvClicked = false;
            UpdateCursor();
            Debug.Log("EQUIP2");
            storage.itemToolTip.HideToolTip();


        }
    }
}
