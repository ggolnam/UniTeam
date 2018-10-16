using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPortal : MonoBehaviour {

    [SerializeField]
    VillageMediator villageMediator;
    [SerializeField]
    ShopSlotCtrl.ShopType shopType;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            villageMediator.EnterShop(shopType);
    }
}
