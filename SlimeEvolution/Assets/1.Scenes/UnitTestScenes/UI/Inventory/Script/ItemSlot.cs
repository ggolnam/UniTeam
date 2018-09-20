﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSlot : MonoBehaviour {

    public UISprite icon;
    [SerializeField]
    Item mItem;

    static Item mDraggedItem;

    abstract protected Item observedItem { get; }
    abstract protected Item Replace(Item item);


    void OnClick()
    {
        if (mDraggedItem != null)
        {
            OnDrop(null);
        }
        else if (mItem != null)
        {
            mDraggedItem = Replace(null);
            UpdateCursor();
        }

        Debug.Log("OnClick");
    }
    void OnDrag(Vector2 delta)
    {
        if (mDraggedItem == null && mItem != null)
        {
            UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
            mDraggedItem = Replace(null);
            UpdateCursor();
        }
    }
    void OnDrop(GameObject go)
    {
        Item item = Replace(mDraggedItem);

        mDraggedItem = item;
        UpdateCursor();
    }
    void UpdateCursor()
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
                }
                else
                {
                    icon.atlas = mItem.iconAtlas;
                    icon.spriteName = mItem.SpriteName;
                    icon.enabled = true;
                    icon.MakePixelPerfect();
                }
            }

        }
    }
}