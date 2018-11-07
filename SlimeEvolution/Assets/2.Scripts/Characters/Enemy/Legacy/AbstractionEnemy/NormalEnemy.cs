using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.LagacyEnemy
{
    public class NormalEnemy : AbstractionEnemy
    {
        public NormalEnemy(EnemyAttack attack, EnemyMovement movement, 
            EnemyMovement chase, EnemyMovement stopMovement)    
            : base(attack, movement, chase, stopMovement)
        { }

        public override int RecoveryHP(int recoverAmount, Animator animator)
        {
            Debug.LogError("<color=red> Error: </color>Not implement RecoveryHP() method in NormalEnemy Class!");
            throw new System.NotImplementedException();
        }
        public override void Skill1(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            Debug.LogError("<color=red> Error: </color>Not implement RecoveryHP() method in NormalEnemy Class!");
            throw new System.NotImplementedException();
        }
        public override void Attack(Vector3 playerPosition, Transform enemyTransform, Animator animator, NavMeshAgent navMeshAgent)
        {
            attack.Attack(playerPosition, enemyTransform, animator, navMeshAgent);
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
            stopMovement.Move(navMeshAgent,enemyTransform, animator);
        }

       
    }
}