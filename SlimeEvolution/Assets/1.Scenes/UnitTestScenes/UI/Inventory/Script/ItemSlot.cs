using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSlot : MonoBehaviour {

    public UISprite icon;
    [SerializeField]
    Item mItem;

    static Item mDraggedItem;

    abstract protected Item observedItem { get; }
    abstract protected Item Replace(Item item);



    void OnTooltip(bool show)
    {
        Item item = show ? mItem : null;

        if (item != null)
        {

            //string t = "[" + NGUIText.EncodeColor(item.color) + "]" + item.name + "[-]\n";

            //t += "[AFAFAF]Level " + item.itemLevel + " " + bi.slot;

            //List<InvStat> stats = item.CalculateStats();

            //for (int i = 0, imax = stats.Count; i < imax; ++i)
            //{
            //    InvStat stat = stats[i];
            //    if (stat.amount == 0) continue;

            //    if (stat.amount < 0)
            //    {
            //        t += "\n[FF0000]" + stat.amount;
            //    }
            //    else
            //    {
            //        t += "\n[00FF00]+" + stat.amount;
            //    }

            //    if (stat.modifier == InvStat.Modifier.Percent) t += "%";
            //    t += " " + stat.id;
            //    t += "[-]";
            //}

            //if (!string.IsNullOrEmpty(bi.description)) t += "\n[FF9900]" + bi.description;
            UITooltip.Show("gogogogogogogogogogogo");
            return;
        }

        UITooltip.Hide();
    }


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
