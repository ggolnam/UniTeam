using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopConfirm : MonoBehaviour {


    public GameObject ConfirmPanel;
    public UISprite Item;
    public Item shopItem;
    public UILabel Price;
    public UILabel ExPlain;
    public string EXString;

    public GameObject ResultPanel;
    public UILabel ResultExPlain;
    public string ResultExString;


    public bool isEnoughMoney;


    public void SetPanel(Item item)
    {
        ConfirmPanel.gameObject.SetActive(true);
        Item.atlas = item.iconAtlas;
        shopItem = item;
        Item.spriteName = item.SpriteName;
        Price.text = item.Price.ToString();
        ExPlain.text = EXString;
    }
    public void OnClickedYes()
    {
        if (IsEnoughMoney())
        {
            ResultExPlain.text = "Buy it";
            BackPack.instance.AddItemToSlot(shopItem);
        }
        else
        {
            ResultExPlain.text = "Not Enough Money";
        }

        ResultPanel.gameObject.SetActive(true);
    }
    public bool IsEnoughMoney()
    {
        if (BackPack.instance.MyMoney >= shopItem.Price)
            isEnoughMoney = true;

        Debug.Log(shopItem.Price);
        return isEnoughMoney;
    }
    public void OnClickedBackButton()
    {
        ResultPanel.gameObject.SetActive(false);
        ConfirmPanel.gameObject.SetActive(false);
    }





}
