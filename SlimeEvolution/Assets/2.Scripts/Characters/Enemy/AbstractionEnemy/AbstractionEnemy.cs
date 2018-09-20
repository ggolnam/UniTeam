using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class AbstractionEnemy
    {
        protected EnemySkill skill1;
        protected EnemySkill skill2;
        protected EnemyAttack attack;
        protected EnemyMovement movement;
        protected EnemyMovement chase;
        
        protected int AttackPoint;

        //Normal Enemy
        public AbstractionEnemy(EnemyAttack attack, EnemyMovement movement, 
            EnemyMovement chase)
        {
            this.attack = attack;
            this.movement = movement;
            this.chase = chase;
        }

        //Named Enemy
        public AbstractionEnemy(EnemyAttack attack, EnemySkill skill,
            EnemyMovement movement, EnemyMovement chase)
        {
            this.attack = attack;
            this.skill1 = skill;
            this.movement = movement;
            this.chase = chase;
        }
        

        public abstract void UseSkill();
        public abstract void Attack();
        public abstract void Move();
        public abstract void Chase();
    }
}