using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemElement
{
    public string itemName;
    public GameObject itemObject;
    public int Rarity;
}
public class DroppingItem :MonoBehaviour
{
    public List<ItemElement> itemTable = new List<ItemElement>();
    
}
