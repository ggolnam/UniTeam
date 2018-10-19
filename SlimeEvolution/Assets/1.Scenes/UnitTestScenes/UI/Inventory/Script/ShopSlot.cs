using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlot : MonoBehaviour {

    public ShopSlotCtrl storage;
    public Item item;
    public int SlotNum;
    public UISprite icon;
    public UISprite BGImg;



    // Use this for initialization
    void Start () {

        icon.atlas = item.iconAtlas;
        icon.spriteName = item.SpriteName;
        BGImg.spriteName = item.SpriteInventorySlot;
        icon.enabled = true;
    }

    void OnClick()
    {
        storage.shopMediator.ShowConfirmPanel(item);
    }

    public void UpdateImg()
    {
        icon.atlas = item.iconAtlas;
        icon.spriteName = item.SpriteName;
        BGImg.spriteName = item.SpriteInventorySlot;
        icon.enabled = true;
    }
    
}
