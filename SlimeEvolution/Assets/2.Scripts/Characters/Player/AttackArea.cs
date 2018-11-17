using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{

    public class AttackArea : MonoBehaviour
    {
        [SerializeField]
        private PlayerForm form;

        Player player;

        void Start()
        {
            player = transform.root.GetComponent<Player>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                switch (form)
                {
                    case PlayerForm.Slime:

                        GameObject temp = GameSystem.ObjectPoolManager.Instance.testPool.PopFromPool(0);
                        temp.transform.position = other.transform.position;
                        temp.SetActive(true);
                        break;
                }
            }

        }


    }
}