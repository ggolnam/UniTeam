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
                navMeshAgent.speed = 0f;
                EnemyObject.transform.LookAt(playerObject.transform.position);
                animator.SetBool("isAttacking", true);
                animator.SetFloat("speed", navMeshAgent.speed);
        }
    }
    public class SmeshAttack : EnemyAttack  
    {
        public SmeshAttack()
        {
            magnification = 3;
        }
        public override void Attack(GameObject gameObject, GameObject EnemyObject,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            //실제 Attack 구현부
        }
    }
}