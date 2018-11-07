using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public abstract class AttackSkill 
    {
        protected Transform playerTransform;


        public AttackSkill(Transform playerTransform)
        {
            this.playerTransform = playerTransform;
        }

        public abstract void Use(Transform target);
    }
}
