using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSlot : MonoBehaviour {

    public UISprite icon;
    public UILabel label;
    public UISprite BGImg;
    [SerializeField]
    public Item Item;
    public int Quantity;
    public bool isEmpty;

    protected bool isEquipSlot;

    protected static Item DraggedItem;

    abstract protected Item ObservedItem { get; }

    protected void UpdateCursor()
    {
        if (DraggedItem != null && Item != null)
        {
            UICursor.Set(DraggedItem.iconAtlas, DraggedItem.SpriteName);
        }
        else
        {
            UICursor.Clear();
        }
    }
    public void UpdateText()
    {
        if (Item.ItemKind == Item.Kind.Equipment)
            label.text = "";
        else if (Quantity == 0)
            label.text = "";
        else
            label.text = Quantity.ToString();
    }
    void Update()
    {
        Item i = ObservedItem;

        if (Item != null)
            UpdateText();


        if (Item != i)
        {
            Item = i;

            if (icon != null)
            {
                if (Item == null || Item.iconAtlas == null)
                {
                    icon.enabled = false;
                    BGImg.enabled = false;
                    isEmpty = true;
                }
                else
                {
                    icon.atlas = Item.iconAtlas;
                    icon.spriteName = Item.SpriteName;

                    if (isEquipSlot)
                        BGImg.spriteName = Item.SpriteEquip;
                    else
                        BGImg.spriteName = Item.SpriteInventorySlot;
                    icon.enabled = true;
                    BGImg.enabled = true;

                    isEmpty = false;

                    icon.MakePixelPerfect();
                }
            }
        }


    }
}
