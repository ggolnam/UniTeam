using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour {

    #region Singleton
    public static TestInventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public delegate void OnItemRemoved(int slotNum);

    public OnItemChanged OnItemChangedCallback;
    public OnItemRemoved OnitemRemoveCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    private void Start()
    {
        for (int i = 0; i < space; i++)
        {
            items.Add(new Item());
        }
    }
    public bool Add(Item item)
    {
        if (!item.isDefalutItem)
        {
            //if (items.Count >= space)
            //{
            //    Debug.Log("Not Enough Room");
            //    return false;
            //}
            for (int i = 0; i < space; i++)
            {
                if (items[i].name == null)
                {
                    items[i] = item;

                    break;
                }
            }
            if (OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
        }
        return true;

    }
    public void ChangeSlot(int slotNum, Item oldItem)
    {
        items[slotNum] = oldItem;
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
    public void Remove(int slotNum, Item item)
    {

        //bool값을 하나 두고 그것이 트루일때 슬롯을 안보이게 만들어버림//
        if (OnitemRemoveCallback != null)
            OnitemRemoveCallback.Invoke(slotNum);
    }
}
