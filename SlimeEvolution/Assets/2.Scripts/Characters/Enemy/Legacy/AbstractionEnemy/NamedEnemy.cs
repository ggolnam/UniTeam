using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.EnemyLagacy
{
    public class NamedEnemy : AbstractionEnemy
    {
        
        public NamedEnemy(EnemyAttack attack, EnemySkill skill1,
            EnemySkill skill2, EnemyMovement movement, EnemyMovement chase, EnemyMovement stop)
            : base(attack, skill1,skill2, movement, chase, stop)
        { }

        public override void Attack(Vector3 playerPosition, Transform enemyTransform, Animator animator, NavMeshAgent navMeshAgent)
        {
            attack.Attack(playerPosition, enemyTransform, animator, navMeshAgent);
        }

        public override int RecoveryHP(int currentHP, Animator animator)
        {
            return skill1.ActivateSkill(currentHP, animator);
        }

        public override void Skill1(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            skill2.ActivateSkill(playerPosition, enemyTransform, animator, navMeshAgent);
        }

        public override void Move(NavMeshAgent meshAgent, Transform enemyTransform, Animator animator)
        {
            movement.Move(meshAgent, enemyTransform, animator);
        }

        public override void Chase(NavMeshAgent meshAgent, Transform enemyTransform, Vector3 playerPosition, Animator animator)
        {
            chase.Chase(meshAgent, enemyTransform, playerPosition, animator);
        }

        public override void Stop(NavMeshAgent navMeshAgent, Transform enemyTransform, Animator animator)
        {
            stopMovement.Move(navMeshAgent, enemyTransform, animator);
        }
    }
}
