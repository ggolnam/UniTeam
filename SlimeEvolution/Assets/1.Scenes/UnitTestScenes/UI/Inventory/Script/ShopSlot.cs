using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlot : MonoBehaviour {

    public ShopSlotCtrl storage;
    public Item item;
    public UILabel label;
    public int SlotNum;
    public UISprite icon;


    // Use this for initialization
    void Start () {

        icon.atlas = item.iconAtlas;
        icon.spriteName = item.SpriteName;
        icon.enabled = true;
    }

    void OnClick()
    {
        storage.shopConfirm.SetPanel(item);
        Debug.Log("gogogo");

    }
    
}
