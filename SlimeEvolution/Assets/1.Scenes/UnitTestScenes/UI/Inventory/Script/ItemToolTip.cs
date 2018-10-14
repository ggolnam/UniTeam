using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolTip : MonoBehaviour
{


    [Header("Equiped")]
    public GameObject EquipedItemPanel;
    public UISprite EquipedItem;
    public UILabel EquipName;
    public UILabel EquipDesc;
    [Header("Inventory")]
    public GameObject InvItemPanel;
    public UISprite InvItem;
    public UILabel InvName;
    public UILabel InvDesc;

    //툴팁 보여주기//
    public bool ShowToolTip(Item[] Equip, Item Inv, Vector3 pos)
    {
        if (Inv == null)
            return false;

        transform.position = pos;
        if (Inv.ItemKind == Item.Kind.Equipment)
            SetEquipedItemToolTip(Equip[(int)Inv.EquipSlotKind]);
        SetInvItemToolTip(Inv);
        Debug.Log("equip1");

        return true;
    }
    //툴팁 숨기기//
    public void HideToolTip()
    {
        EquipedItemPanel.SetActive(false);
        InvItemPanel.SetActive(false);
    }
    //장착중인 장비 툴팁 셋팅하기//
    void SetEquipedItemToolTip(Item item)
    {
        if (item == null)
            return;


        EquipedItemPanel.SetActive(true);
        EquipedItem.atlas = item.iconAtlas;
        EquipedItem.spriteName = item.SpriteName;
        EquipName.text = item.Name.ToString();
        EquipDesc.text = item.ItemKind.ToString();
    }
    //인벤토리 아이템 툴팁 셋팅하기//
    void SetInvItemToolTip(Item item)
    {
        if (item == null)
            return;

        InvItemPanel.SetActive(true);
        InvItem.atlas = item.iconAtlas;
        InvItem.spriteName = item.SpriteName;
        InvName.text = item.Name.ToString();
        InvDesc.text = item.ItemKind.ToString();
    }
}
