using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
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

            if (timer >= newtarget)
            {
                newTarget(meshAgent,gameObject, animator);
                timer = 0;
            }
        }

        void newTarget(NavMeshAgent navMeshAgent ,GameObject gameObject, Animator animator)
        {
            float myX = gameObject.transform.position.x;
            float myZ = gameObject.transform.position.z;

            float xPosition = myX + Random.Range(myX - 50, myX + 50);
            float zPosition = myZ + Random.Range(myZ - 50, myZ + 50);

            target = new Vector3(xPosition, gameObject.transform.position.y, zPosition);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
                Quaternion.LookRotation(target), 1.0f);
            
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
        public StopMovement()
        {
            this.speed = 0.0f;
        }

        public override void Move(NavMeshAgent navMeshAgent, GameObject gameObject, Animator animator)
        {
            navMeshAgent.speed = 0.0f;
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
        //void StopChase(NavMeshAgent navMeshAgent, GameObject EnemyObject,
        //    GameObject playerObject, Animator animator)
        //{
        //    navMeshAgent.speed = 0.0f;
        //    animator.SetFloat("speed", navMeshAgent.speed);
        //    EnemyObject.transform.LookAt(playerObject.transform.position);
        //}
        public override void Move(NavMeshAgent navMeshAgent, GameObject gameObject, 
            Animator animator) { }
    }
    
}