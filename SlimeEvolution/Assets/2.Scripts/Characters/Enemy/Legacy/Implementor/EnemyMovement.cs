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

            float myX = enemyTransform.position.x;
            float myZ = enemyTransform.position.z;

            //랜덤 방향 계산 개선요망
            //float xPosition = myX + Random.Range(myX - 100, myX + 100);
            //float zPosition = myZ + Random.Range(myZ - 100, myZ + 100);

            float xPosition = myX + Random.Range(-20, 20);
            float zPosition = myZ + Random.Range(-20, 20);

            target = new Vector3(xPosition, enemyTransform.transform.position.y, zPosition);

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
            float xPosition = playerPosition.x;
            float zPosition = playerPosition.z;
            
            target = new Vector3(xPosition, enemyTransform.transform.position.y, zPosition);

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