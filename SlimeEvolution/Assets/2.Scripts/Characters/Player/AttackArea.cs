using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{

    public class AttackArea : MonoBehaviour
    {
        Player player;

        void Start()
        {
            player = transform.root.GetComponent<Player>();
        }

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log(player.CharacterStat.Damage);
            if (other.CompareTag("Enemy")) 
                Debug.Log(other.name);
        }


    }
}