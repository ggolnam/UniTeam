using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.EnemyLagacy
{
    public abstract class EnemySkill
    {
        public int magnification;
        public abstract int ActivateSkill(int currentHP, Animator animator);
        public abstract void ActivateSkill(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent);
    }
    


    public class RecoverHP : EnemySkill
    {
        int recoveryAmount;
        public RecoverHP(int recoveryAmount)
        {
            this.recoveryAmount = recoveryAmount;
        }
        public override int ActivateSkill(int currentHP, Animator animator)
        {
            animator.SetBool("isRecovering", true);
            currentHP += recoveryAmount;
            
            return currentHP;
        }

        public override void ActivateSkill(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent)
        {  }
    }
    public class Throwing : EnemySkill
    {
        int damage;
        public Throwing(int damage)
        {
            this.damage = damage;
        }

        public override void ActivateSkill(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            GameObject throwingObject;
<<<<<<< HEAD
            enemyTransform.transform.LookAt(playerPosition);
            throwingObject = ThrowingObjectPool.Instance.PopFromPool(enemyTransform.transform);
            throwingObject.transform.position = new Vector3(enemyTransform.transform.position.x, 0.5f, enemyTransform.transform.position.z);
=======
            
            enemyTransform.transform.LookAt(playerPosition);
            throwingObject = ThrowingObjectPool.Instance.PopFromPool(enemyTransform.transform);
            throwingObject.transform.position = new Vector3(enemyTransform.position.x, 0.5f, enemyTransform.position.z);
>>>>>>> 90ad0829ff8104e7225cedc39a1aa62f98352efb
            
            
            Rigidbody throwingRigid = throwingObject.GetComponent<Rigidbody>();
            throwingObject.transform.position = throwingObject.transform.position + enemyTransform.transform.forward * 2;
            throwingRigid.velocity = enemyTransform.transform.forward * 10;
           
        }
        
        public override int ActivateSkill(int currentHP, Animator animator)
        {
            return 0;
        }
        
    }
    public class SmeshAttack : EnemySkill
    {
        public SmeshAttack()
        {
            magnification = 3;
        }
<<<<<<< HEAD
        public override void ActivateSkill(Vector3 playerObject, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            navMeshAgent.speed = 0f;
            enemyTransform.transform.LookAt(playerObject);
=======
        public override void ActivateSkill(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            navMeshAgent.speed = 0f;
            enemyTransform.LookAt(playerPosition);
>>>>>>> 90ad0829ff8104e7225cedc39a1aa62f98352efb
            animator.SetBool("isSmeshAttacking", true);
            animator.SetFloat("speed", navMeshAgent.speed);
        }

        public override int ActivateSkill(int currentHP, Animator animator)
        {
            return 0;
        }
    }
}
