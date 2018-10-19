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
        public override void Skill1(GameObject playerObject, GameObject EnemyObject,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            Debug.LogError("<color=red> Error: </color>Not implement RecoveryHP() method in NormalEnemy Class!");
            throw new System.NotImplementedException();
        }
        public override void Attack(GameObject gameObject, GameObject EnemyObject, Animator animator, NavMeshAgent navMeshAgent)
        {
            attack.Attack(gameObject, EnemyObject, animator, navMeshAgent);
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