using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPortal : MonoBehaviour {

    [SerializeField]
    VillageMediator villageMediator;
    [SerializeField]
    ShopSlotCtrl.ShopType shopType;

    public int speed;
    public bool isTurn;

    public int TestMaxUp;
    public int TestMaxDown;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            villageMediator.EnterShop(shopType);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            villageMediator.ExitShop();
    }

    private void Update()
    {
        //gameObject.transform.Rotate(0, Time.deltaTime * 5*speed, 0);

        if (gameObject.transform.localPosition.y <= TestMaxUp && !isTurn)
        {
            gameObject.transform.Translate(0, Time.deltaTime * speed, 0);

        }
        else if (gameObject.transform.localPosition.y >= TestMaxDown && isTurn)
        {
            gameObject.transform.Translate(0, -Time.deltaTime * speed, 0);

        }
        else if (gameObject.transform.localPosition.y >= TestMaxUp)
            isTurn = true;

        else if (gameObject.transform.localPosition.y <= TestMaxDown)
            isTurn = false;
    }

}
