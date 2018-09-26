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

        public override void Move(NavMeshAgent meshAgent, GameObject gameObject)
        {
            movement.Move(meshAgent, gameObject);
        }

        public override void Chase(NavMeshAgent meshAgent, GameObject gameObject, GameObject player)
        {
            chase.Chase(meshAgent, gameObject, player);
        }

        public override void Stop(NavMeshAgent navMeshAgent, GameObject gameObject)
        {
            stopMovement.Move(navMeshAgent,gameObject);
        }
    }
}