using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    public Item item;

    public void PickUp()
    {
        Debug.Log("Picking Up " + item.name);
        bool wasPickedUp = TestInventory.instance.Add(item);
        if (wasPickedUp)
        {
            Debug.Log("pick");
        }
    }
}
