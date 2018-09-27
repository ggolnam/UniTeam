using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemyMovement
    {
        protected Vector3 target;
        //protected Animator animator; //심사숙고좀 ....

        protected float speed;
        protected float timer;
        protected float magnification;
        protected int newtarget;
        
        public abstract void Move(NavMeshAgent navMeshAgent, GameObject gameObject, Animator animator);
        public abstract void Chase(NavMeshAgent navMeshAgent, GameObject gameObject, GameObject player, 
            Animator animator);
        
    }



    public class RandomMovement : EnemyMovement
    {
        public RandomMovement(float speed)
           
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

            float xPosition = myX + Random.Range(myX - 100, myX + 100);
            float zPosition = myZ + Random.Range(myZ - 100, myZ + 100);

            target = new Vector3(xPosition, gameObject.transform.position.y, zPosition);
            navMeshAgent.speed = speed;
            navMeshAgent.SetDestination(target);
            animator.SetFloat("speed", speed);
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
        }

        public override void Chase(NavMeshAgent navMeshAgent, GameObject gameObject,
            GameObject player, Animator animator) { }
    }




    public class Chasing : EnemyMovement
    {

        public Chasing(float speed)
        {
            
            magnification = 2.0f;
            this.speed = speed * magnification;
        }
        
        public override void Chase(NavMeshAgent navMeshAgent, GameObject gameObject,
            GameObject player, Animator animator)
        {
            float xPosition =player.transform.position.x;
            float zPosition =player.transform.position.z;

            target = new Vector3(xPosition, gameObject.transform.position.y, zPosition);
            navMeshAgent.speed = speed;
            animator.SetFloat("speed", speed);
            navMeshAgent.SetDestination(target);
        }

        public override void Move(NavMeshAgent navMeshAgent, GameObject gameObject, 
            Animator animator) { }
    }
}