using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemyAttack
    {
        protected int magnification;
        protected int damage;
        
        public abstract void Attack(GameObject gameObject, GameObject EnemyObject, Animator animator, NavMeshAgent navMeshAgent);

    }

    public class NormalAttack : EnemyAttack
    {
        public NormalAttack(float damage)
        {
            magnification = 1;
        }

        public override void Attack(GameObject playerObject, GameObject EnemyObject, Animator animator, NavMeshAgent navMeshAgent)
        {
            if (Vector3.Distance(playerObject.transform.position, EnemyObject.transform.position) < 2)
            {
                navMeshAgent.speed = 0f;
                animator.SetFloat("speed", navMeshAgent.speed);
                Vector3 direction = playerObject.transform.position - EnemyObject.transform.position;
                direction.y = 0;
                //movement쪽의 LookAt으로 수정할것
                EnemyObject.transform.rotation = Quaternion.Slerp(EnemyObject.transform.rotation,
                    Quaternion.LookRotation(direction), 1.0f);
                animator.SetBool("isAttacking", true);
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }

    }

    public class SmeshAttack : EnemyAttack  
    {
        public SmeshAttack()
        {
            magnification = 3;
        }

        public override void Attack(GameObject gameObject, GameObject EnemyObject, Animator animator, NavMeshAgent navMeshAgent)
        {
            //실제 Attack 구현부
        }
    }

}