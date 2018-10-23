using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  delegate void OnClickHideUI();

public class VillageUI : MonoBehaviour {

    public GameObject EquipMentUI;
    public GameObject InventoryUI;
    public GameObject ShopUI;
    public UIPanel InvScorll;
    public ShopSlotCtrl slotCtrl;
    public OnClickHideUI HideUIDelegate;
    ShopMediator shopMediator;
    private void OnEnable()
    {
        shopMediator = GameObject.FindGameObjectWithTag("Mediator").GetComponent<ShopMediator>();


        HideUIDelegate = new OnClickHideUI(shopMediator.HideShopUI);

    }

    private void Start()
    {
        InventoryUI.gameObject.SetActive(false);
        EquipMentUI.gameObject.SetActive(false);
        ShopUI.gameObject.SetActive(false);
    }

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
        //callback하기//
        if (HideUIDelegate != null && InventoryUI.activeSelf==true)
            HideUIDelegate();

        InvScorll.transform.localPosition = Vector3.zero;
        InvScorll.clipOffset=Vector2.zero;
        InventoryUI.gameObject.SetActive(false);
        EquipMentUI.gameObject.SetActive(false);
        ShopUI.gameObject.SetActive(false);
    }

}
