using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractVillageMediator : MonoBehaviour {


    public abstract void SendItemToShop(int slot, int quantity, Item item);


}
