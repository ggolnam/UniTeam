using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSlot : MonoBehaviour {

    public UISprite icon;
    public UILabel label;
    public UISprite BGImg;
    [SerializeField]
    public Item mItem;
    public int Quantity;
    public bool isEmpty;

    protected bool isEquipSlot;

    protected static Item mDraggedItem;

    abstract protected Item observedItem { get; }

    protected void UpdateCursor()
    {
        if (mDraggedItem != null && mItem != null)
        {
            UICursor.Set(mDraggedItem.iconAtlas, mDraggedItem.SpriteName);
        }
        else
        {
            UICursor.Clear();
        }
    }
    public void UpdateText()
    {
        if (mItem.ItemKind == Item.Kind.Equipment)
            label.text = "";
        else if (Quantity == 0)
            label.text = "";
        else
            label.text = Quantity.ToString();
    }
    void Update()
    {
        Item i = observedItem;

        if (mItem != null)
            UpdateText();

        if (mItem != i)
        {
            mItem = i;

            if (icon != null)
            {
                if (mItem == null || mItem.iconAtlas == null)
                {
                    icon.enabled = false;
                    BGImg.enabled = false;
                    isEmpty = true;
                }
                else
                {
                    icon.atlas = mItem.iconAtlas;
                    icon.spriteName = mItem.SpriteName;

                    if (isEquipSlot)
                        BGImg.spriteName = mItem.SpriteEquip;
                    else
                        BGImg.spriteName = mItem.SpriteInventorySlot;
                    icon.enabled = true;
                    BGImg.enabled = true;

                    isEmpty = false;

                    icon.MakePixelPerfect();
                }
            }
        }

    }
}
