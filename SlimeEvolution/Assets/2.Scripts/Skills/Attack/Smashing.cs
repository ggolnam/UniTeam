using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public class Smashing : AttackSkill
    {
        public Smashing(Transform playerTransform) : base (playerTransform)
        { }

        public override void Use(Transform target)
        {
            temp[1].transform.position = target.position;
            temp[1].SetActive(true);
        }
    }
}
