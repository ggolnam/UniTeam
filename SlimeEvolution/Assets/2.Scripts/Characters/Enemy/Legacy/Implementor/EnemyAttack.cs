using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.LagacyEnemy
{
    public abstract class EnemyAttack
    {
        protected int magnification;
        protected int damage;
        
        public abstract void Attack(GameObject gameObject, GameObject EnemyObject,
            Animator animator, NavMeshAgent navMeshAgent);
    }
    


    public class NormalAttack : EnemyAttack
    {
        public NormalAttack(float damage)
        {
            magnification = 1;
        }
        public override void Attack(GameObject playerObject, GameObject EnemyObject,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            Vector3 playerPosition = playerObject.transform.position;
            //animator.SetBool("isSmeshAttacking", false); //wtf
            playerPosition.y = EnemyObject.transform.position.y;
            EnemyObject.transform.LookAt(playerPosition);
                animator.SetBool("isAttacking", true);
            
        }

    }
    
}