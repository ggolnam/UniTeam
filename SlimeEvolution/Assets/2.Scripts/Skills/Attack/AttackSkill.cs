using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public abstract class AttackSkill 
    {
        protected Transform playerTransform;
        protected GameObject[] temp;


        public AttackSkill(Transform playerTransform)
        {
            this.playerTransform = playerTransform;
            temp = GameObject.FindGameObjectsWithTag("Particle");
        }

        public abstract void Use(Transform target);
    }
}
