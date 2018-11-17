using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.LagacyEnemy
{
    public abstract class EnemyMovement
    {
        protected Vector3 target;
       
        protected float speed;
        protected float timer;
        protected float magnification;
        
        public abstract void Move(NavMeshAgent navMeshAgent, Transform enemyTransform, Animator animator);
        public abstract void Chase(NavMeshAgent navMeshAgent, Transform enemyTransform, Vector3 playerPosition, 
            Animator animator);
        
    }

    
    public class Patrol : EnemyMovement
    {
        public Patrol(float speed)
        {
            this.speed = speed;
        }

        public override void Move(NavMeshAgent navMeshAgent, Transform enemyTransform, Animator animator)
        {
            int randomValue = Random.Range(-20, 20);
            
            float xPosition = enemyTransform.position.x + randomValue;
            float zPosition = enemyTransform.position.z + randomValue;

            target = new Vector3(xPosition, enemyTransform.position.y, zPosition);

            navMeshAgent.speed = speed;
            navMeshAgent.SetDestination(target);

            animator.SetFloat("speed", speed);
            animator.SetBool("isAttacking", false);
        }

        public override void Chase(NavMeshAgent navMeshAgent, Transform enemyTransform,
            Vector3 playerPosition, Animator animator) { }
    }

    public class StopMovement: EnemyMovement
    {
        
        public override void Move(NavMeshAgent navMeshAgent, Transform enemyTransform, Animator animator)
        {
            navMeshAgent.speed = 0.0f;
            speed = navMeshAgent.speed;
            animator.SetFloat("speed", speed);
            animator.SetBool("isAttacking", false);
        }

        public override void Chase(NavMeshAgent navMeshAgent, Transform enemyTransform,
             Vector3 playerPosition, Animator animator) { }
    }

    public class Chasing : EnemyMovement
    {
        public Chasing(float speed)
        {
            magnification = 3f;
            this.speed = speed * magnification;
        }

        public override void Chase(NavMeshAgent navMeshAgent, Transform enemyTransform,
            Vector3 playerPosition, Animator animator)
        {
            target = new Vector3(playerPosition.x, enemyTransform.transform.position.y, playerPosition.z);

            enemyTransform.transform.LookAt(playerPosition);
            navMeshAgent.speed = speed;
            animator.SetFloat("speed", speed);
            animator.SetBool("isAttacking", false);
            navMeshAgent.SetDestination(target);
        }

        public override void Move(NavMeshAgent navMeshAgent, Transform enemyTransform, 
            Animator animator) { }
    }
    
}