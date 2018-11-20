using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.EnemyLagacy
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

<<<<<<< HEAD
            float myX = enemyTransform.position.x;
            float myZ = enemyTransform.position.z;

            //랜덤 방향 계산 개선요망
            float xPosition = myX + Random.Range(myX - 360, myX + 360);
            float zPosition = myZ + Random.Range(myZ - 360, myZ + 360);

=======
>>>>>>> 90ad0829ff8104e7225cedc39a1aa62f98352efb
            target = new Vector3(xPosition, enemyTransform.position.y, zPosition);

            navMeshAgent.speed = speed;
            navMeshAgent.SetDestination(target);

            animator.SetFloat("speed", speed);
            animator.SetBool("isAttacking", false);
        }

<<<<<<< HEAD
        
        
=======
>>>>>>> 90ad0829ff8104e7225cedc39a1aa62f98352efb
        public override void Chase(NavMeshAgent navMeshAgent, Transform enemyTransform,
            Vector3 playerPosition, Animator animator) { }
    }

    public class StopMovement: EnemyMovement
    {
        
<<<<<<< HEAD
        public override void Move(NavMeshAgent navMeshAgent, Transform gameObject, Animator animator)
=======
        public override void Move(NavMeshAgent navMeshAgent, Transform enemyTransform, Animator animator)
>>>>>>> 90ad0829ff8104e7225cedc39a1aa62f98352efb
        {
            navMeshAgent.speed = 0.0f;
            speed = navMeshAgent.speed;
            animator.SetFloat("speed", speed);
            animator.SetBool("isAttacking", false);
        }

        public override void Chase(NavMeshAgent navMeshAgent, Transform enemyTransform,
<<<<<<< HEAD
            Vector3 playerPosition, Animator animator) { }
=======
             Vector3 playerPosition, Animator animator) { }
>>>>>>> 90ad0829ff8104e7225cedc39a1aa62f98352efb
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
<<<<<<< HEAD
            float xPosition = playerPosition.x;
            float zPosition = playerPosition.z;
            
            target = new Vector3(xPosition, enemyTransform.transform.position.y, zPosition);
=======
            target = new Vector3(playerPosition.x, enemyTransform.transform.position.y, playerPosition.z);
>>>>>>> 90ad0829ff8104e7225cedc39a1aa62f98352efb

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