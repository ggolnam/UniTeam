using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSlot : MonoBehaviour {

    public UISprite icon;
    [SerializeField]
    public Item mItem;
    public bool isEmpty;

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

    //void OnTooltip(bool show)
    //{
    //    Item item = show ? mItem : null;

    //    if (item != null)
    //    {

    //        string t = item.name + "[-]\n";

    //        t += "[AFAFAF]Level " + item.ID;

    //        UITooltip.Show(t);
    //        return;
    //    }

    //    UITooltip.Hide();
    //}




}
