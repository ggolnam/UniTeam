using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageMediator : MonoBehaviour {

    [SerializeField]
    VillageUI villageUI;



    public void EnterShop()
    {
        villageUI.ShowShopUI();
    }
    public void EnterInventory()
    {
        villageUI.ShowEquipMentUI();
    }
}
