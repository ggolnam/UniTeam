using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ItemSlot{


    public BackPack storage;

    public Item.EquipmentSlotKind equipmentSlotType;


    protected override Item observedItem
    {
        get
        {
            return (storage != null) ? storage.GetEquip(equipmentSlotType) : null;
        }
    }
    void OnClick()
    {
        if (!BackPack.isEquipClicked && mDraggedItem == null) 
        {
            //원래자리에 있던 아이템을 든다//
            //mDraggedItem을 mitem으로 설정
            mDraggedItem = mItem;
            storage.preslot = (int)equipmentSlotType;

            //BackPack.isInvClicked = true;
            BackPack.isEquipClicked = true;
            UpdateCursor();
            Debug.Log("EQUIP");
        }
        else if (BackPack.isEquipClicked && !BackPack.isInvClicked) 
        {
            mDraggedItem = null;
            BackPack.isEquipClicked = false ;
            BackPack.isInvClicked = false;
            UpdateCursor();
            Debug.Log("EQUIP1");

        }
        else
        {
            storage.Equip(equipmentSlotType);
            mDraggedItem = null;
            BackPack.isInvClicked = false;
            UpdateCursor();
            Debug.Log("EQUIP2");

        }
    }


    void Start()
    {
        storage = GameObject.FindWithTag("BACKPACK").GetComponent<BackPack>();

    }

    void Update()
    {
        Item i = observedItem;

        if (mItem != i)
        {
            mItem = i;

            if (icon != null)
            {
                if (mItem == null || mItem.iconAtlas == null)
                {
                    icon.enabled = false;
                    isEmpty = true;
                }
                else
                {
                    icon.atlas = mItem.iconAtlas;
                    icon.spriteName = mItem.SpriteName;
                    icon.enabled = true;
                    isEmpty = false;

                    icon.MakePixelPerfect();
                }
            }
        }

    }
}
