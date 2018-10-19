using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeEvolution.GameSystem;

public class ShopConfirm : MonoBehaviour {

    public ShopMediator ShopMediator;

    public GameObject ConfirmPanel;
    public UISprite Item;
    public UISprite BGImg;

    public Item shopItem;
    public UILabel Price;
    public UILabel ExPlain;
    public string EXString;

    public GameObject ResultPanel;
    public UILabel ResultExPlain;
    public string ResultExString;


    public bool isEnoughMoney;

    //패널셋팅하기//
    public void SetPanel(Item item)
    {
        ConfirmPanel.gameObject.SetActive(true);
        Item.atlas = item.iconAtlas;
        shopItem = item;
        Item.spriteName = item.SpriteName;
        BGImg.spriteName = item.SpriteInventorySlot;

        Price.text = item.Price.ToString();
        ExPlain.text = EXString;
    }
    //Yes버튼 클릭//
    public void OnClickedYes()
    {
        //돈있을때 아이템 구매//
        if (IsEnoughMoney() && ShopMediator.IsInvEmpty())
        {
            ResultExPlain.text = "Buy it";
            ShopMediator.SetMnoey((ShopMediator.GetMoney() -shopItem.Price));
            ShopMediator.AddItemToInv(1, shopItem);


        }
        //없을때 안사짐//
        else if (!IsEnoughMoney())
        {
            ResultExPlain.text = "Not Enough Money";
        }
        else
        {
            ResultExPlain.text = "There is No Empty Slot";
        }
        ShopMediator.HideToolTip();
        ResultPanel.gameObject.SetActive(true);
    }
    //No버튼 클릭//
    public void OnClickedNo()
    {
        ShopMediator.HideToolTip();
        ConfirmPanel.gameObject.SetActive(false);
    }
    //잔돈 확인하기//
    public bool IsEnoughMoney()
    {
        if (ShopMediator.GetMoney() >= shopItem.Price)
            isEnoughMoney = true;
        else
            isEnoughMoney = false;

        return isEnoughMoney;
    }
    //Back버튼 클릭//
    public void OnClickedBackButton()
    {
        ResultPanel.gameObject.SetActive(false);
        ConfirmPanel.gameObject.SetActive(false);
        Debug.Log("OnClickedBackButton");
    }

}
