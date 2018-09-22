using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public class NamedEnemy:AbstractionEnemy
    {
        
        public NamedEnemy(EnemyAttack attack, EnemySkill skill,
            EnemySkill skill2, EnemyMovement movement, EnemyMovement chase)
            : base(attack, skill, movement, chase)
        { }

        public override void Attack()
        {
            attack.Attack();
        }

        public override void UseSkill()
        {
            skill1.ActivateSkill();
        }

        public void UseSkill2()
        {
            skill2.ActivateSkill();
        }

        public override void Move(NavMeshAgent meshAgent, GameObject gameObject)
        {
            movement.Move(meshAgent, gameObject);
        }

        public override void Chase(NavMeshAgent meshAgent, GameObject gameObject, GameObject player)
        {
            chase.Chase(meshAgent, gameObject, player);
        }
    }
}
