using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public class NormalEnemy : AbstractionEnemy
    {
        public NormalEnemy(EnemyAttack attack, EnemyMovement movement, 
            EnemyMovement chase, StopMovement stopMovement)
            : base(attack, movement, chase, stopMovement)
        { }

        public override void UseSkill()
        {
        }

        public override void Attack()
        {
            attack.Attack();
        }

        public override void Move(NavMeshAgent meshAgent, GameObject gameObject, Animator animator)
        {
            movement.Move(meshAgent, gameObject, animator);
        }

        public override void Chase(NavMeshAgent meshAgent, GameObject gameObject, GameObject player, Animator animator)
        {
            chase.Chase(meshAgent, gameObject, player, animator);
        }

        public override void Stop(NavMeshAgent navMeshAgent, GameObject gameObject, Animator animator)
        {
            stopMovement.Move(navMeshAgent,gameObject, animator);
        }
    }
}