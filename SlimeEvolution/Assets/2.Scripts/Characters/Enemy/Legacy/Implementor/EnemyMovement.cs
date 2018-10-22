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
        protected int newtarget;
        
        public abstract void Move(NavMeshAgent navMeshAgent, GameObject gameObject, Animator animator);
        public abstract void Chase(NavMeshAgent navMeshAgent, GameObject gameObject, GameObject player, 
            Animator animator);
        
    }

    
    public class Patrol : EnemyMovement
    {
        public Patrol(float speed)
        {
            this.speed = speed;
        }

        public override void Move(NavMeshAgent meshAgent, GameObject gameObject, Animator animator)
        {
            timer += Time.deltaTime;
            Debug.Log("호출됨");
            if (timer >= newtarget)
            {
                newTarget(meshAgent,gameObject, animator);
                timer = 0;
            }
        }

        void newTarget(NavMeshAgent navMeshAgent ,GameObject enemyObject, Animator animator)
        {
            float myX = enemyObject.transform.position.x;
            float myZ = enemyObject.transform.position.z;

            //랜덤 방향 계산 개선요망
            float xPosition = myX + Random.Range(myX - 60, myX + 60);
            float zPosition = myZ + Random.Range(myZ - 60, myZ + 60);

            target = new Vector3(xPosition, enemyObject.transform.position.y, zPosition);
            
            navMeshAgent.speed = speed;
            navMeshAgent.SetDestination(target);
            
            animator.SetFloat("speed", speed);
            animator.SetBool("isAttacking", false);
        }
        
        public override void Chase(NavMeshAgent navMeshAgent, GameObject gameObject,
            GameObject player, Animator animator) { }
    }

    public class StopMovement: EnemyMovement
    {
        
        public override void Move(NavMeshAgent navMeshAgent, GameObject gameObject, Animator animator)
        {
            navMeshAgent.speed = 0.0f;
            speed = navMeshAgent.speed;
            animator.SetFloat("speed", speed);
            animator.SetBool("isAttacking", false);
        }

        public override void Chase(NavMeshAgent navMeshAgent, GameObject gameObject,
            GameObject player, Animator animator) { }
    }

    public class Chasing : EnemyMovement
    {
        public Chasing(float speed)
        {
            magnification = 3f;
            this.speed = speed * magnification;
        }

        public override void Chase(NavMeshAgent navMeshAgent, GameObject EnemyObject,
            GameObject playerObject, Animator animator)
        {
            float xPosition = playerObject.transform.position.x;
            float zPosition = playerObject.transform.position.z;
            
            target = new Vector3(xPosition, EnemyObject.transform.position.y, zPosition);

            EnemyObject.transform.LookAt(playerObject.transform.position);
            navMeshAgent.speed = speed;
            animator.SetFloat("speed", speed);
            animator.SetBool("isAttacking", false);
            navMeshAgent.SetDestination(target);
        }

        public override void Move(NavMeshAgent navMeshAgent, GameObject gameObject, 
            Animator animator) { }
    }
    
}