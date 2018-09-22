﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemyAttack
    {
        protected int damageMagnification;
        protected int damage;
        
        public abstract void Attack();

    }

    public class NormalAttack : EnemyAttack
    {
        public NormalAttack(float damage)
        {
            //damageMagnification = 1;
        }

        public override void Attack()
        {
            //실제 Attack구현부
            Debug.Log("Attack대미지" + damageMagnification.ToString());
        }

    }

    public class SmeshAttack : EnemyAttack  
    {
        public SmeshAttack()
        {
            damageMagnification = 3;
        }

        public override void Attack()
        {
            //실제 Attack 구현부
            Debug.Log("Attack대미지:" + damageMagnification.ToString());
        }
    }

}