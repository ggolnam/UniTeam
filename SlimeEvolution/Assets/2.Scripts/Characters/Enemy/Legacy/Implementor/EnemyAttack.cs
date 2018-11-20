using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.EnemyLagacy
{
    public abstract class EnemyAttack
    {
        protected int magnification;
        protected int damage;
        
        public abstract void Attack(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent);
    }
    


    public class NormalAttack : EnemyAttack
    {
        public NormalAttack(float damage)
        {
            magnification = 1;
        }
        public override void Attack(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            //animator.SetBool("isSmeshAttacking", false); //wtf
            playerPosition.y = enemyTransform.position.y;
            enemyTransform.LookAt(playerPosition);
                animator.SetBool("isAttacking", true);
            
        }

    }
    
}