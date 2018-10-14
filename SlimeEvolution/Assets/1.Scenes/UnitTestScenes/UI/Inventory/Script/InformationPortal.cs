using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationPortal : MonoBehaviour {

    [SerializeField]
    VillageMediator villageMediator;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            villageMediator.EnterInventory();
    }
}
