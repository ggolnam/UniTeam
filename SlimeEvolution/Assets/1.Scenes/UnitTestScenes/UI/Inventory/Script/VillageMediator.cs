using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageMediator : MonoBehaviour {



    [SerializeField]
    VillageUI villageUI;



    public void EnterShop(ShopSlotCtrl.ShopType shopType)
    {
        villageUI.ShowShopUI(shopType);
    }
    public void EnterInventory(ShopSlotCtrl.ShopType shopType)
    {
        villageUI.ShowShopUI(shopType);
    }
    public void EnterInventroy()
    {
        villageUI.ShowInvUI();
    }
}
