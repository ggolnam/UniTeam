using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemyAttack
    {
        protected int AttackPointMagnification;
        protected int Damage;
        
        public abstract void Attack();

    }

    public class NormalAttack : EnemyAttack
    {
        public NormalAttack(int Damage)
        {
            base.Damage = Damage;
            AttackPointMagnification = 1;
            
        }

        public override void Attack()
        {
            //실제 Attack구현부
            Debug.Log("Attack대미지" + AttackPointMagnification.ToString());
        }

    }

    public class SmeshAttack : EnemyAttack  
    {
        public SmeshAttack(int Damage)
        {
            AttackPointMagnification = 3;
        }

        public override void Attack()
        {
            //실제 Attack 구현부
            Debug.Log("Attack대미지:" + AttackPointMagnification.ToString());
        }
    }

}