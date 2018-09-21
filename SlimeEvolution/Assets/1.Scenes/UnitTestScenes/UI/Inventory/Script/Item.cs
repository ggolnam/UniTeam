using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public int ID;
    public string Name = null;
    public string SpriteName;
    public UIAtlas iconAtlas;
    public bool isDefalutItem = false;
    public ItemType Type;

    public virtual void Use(int slotNum)
    {
        Debug.Log("Using" + Name);

    }
    public void RemoveFromInventory(int slotNum)
    {
       // TestInventory.instance.Remove(slotNum, this);
    }
}
public enum ItemType
{
    Equipment,
    Disposable,
}

