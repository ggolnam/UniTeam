using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = null;
    public string SpriteName;
    public UIAtlas iconAtlas;
    public bool isDefalutItem = false;

    public virtual void Use(int slotNum)
    {
        Debug.Log("Using" + name);

    }
    public void RemoveFromInventory(int slotNum)
    {
        TestInventory.instance.Remove(slotNum, this);
    }
}

