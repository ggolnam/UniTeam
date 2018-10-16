using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SlimeEvolution.Character.Player
{

    public class AttackAreaActivator : MonoBehaviour
    {
        [SerializeField]
        Collider[] attackAreaColliders;

        public void StartAttackHit()
        {
            for (int i = 0; i < attackAreaColliders.Length; i++)
                attackAreaColliders[i].enabled = true;

        }

        public void EndAttackHit()
        {
            for (int i = 0; i < attackAreaColliders.Length; i++)
                attackAreaColliders[i].enabled = false;
        }
    }
}
