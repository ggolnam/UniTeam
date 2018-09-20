using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public class NormalEnemy : AbstractionEnemy
    {
        public NormalEnemy(EnemyAttack attack, EnemyMovement movement, 
            EnemyMovement chase)
            : base(attack, movement, chase)
        { }

        public override void UseSkill()
        {
        }

        public override void Attack()
        {
            attack.Attack();
        }

        public override void Move()
        {
            movement.Move();
        }

        public override void Chase()
        {
            chase.Move();
        }
    }
}