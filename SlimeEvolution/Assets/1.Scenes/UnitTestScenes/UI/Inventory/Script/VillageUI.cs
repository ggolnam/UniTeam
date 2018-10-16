using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageUI : MonoBehaviour {

    public GameObject EquipMentUI;
    public GameObject InventoryUI;
    public GameObject ShopUI;
    public ShopSlotCtrl slotCtrl;


    public void ShowShopUI(ShopSlotCtrl.ShopType shopType)
    {
        InventoryUI.gameObject.SetActive(true);
        ShopUI.gameObject.SetActive(true);
        slotCtrl.SetShopItem(shopType);
        EquipMentUI.gameObject.SetActive(false);

    }
    public void ShowInvUI()
    {
        InventoryUI.gameObject.SetActive(true);
        EquipMentUI.gameObject.SetActive(true);
        ShopUI.gameObject.SetActive(false);

    }
    public void HideUI()
    {
        InventoryUI.gameObject.SetActive(false);
        EquipMentUI.gameObject.SetActive(false);
        ShopUI.gameObject.SetActive(false);
    }

}
