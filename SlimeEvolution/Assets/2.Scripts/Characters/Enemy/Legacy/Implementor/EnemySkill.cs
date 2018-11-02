using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.LagacyEnemy
{
    public abstract class EnemySkill
    {
        public GameObject enemy;
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
            //회복 이펙트 호출
            return currentHP;
        }

        public override void ActivateSkill(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            throw new System.NotImplementedException();
        }
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
            
            enemyTransform.transform.LookAt(playerPosition);
            throwingObject = ThrowingObjectPool.Instance.PopFromPool(enemyTransform.transform);
            throwingObject.transform.position = new Vector3(enemyTransform.position.x, 0.5f, enemyTransform.position.z);
            
            
            //성능 f.....
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
        public override void ActivateSkill(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            navMeshAgent.speed = 0f;
            enemyTransform.LookAt(playerPosition);
            animator.SetBool("isSmeshAttacking", true);
            animator.SetFloat("speed", navMeshAgent.speed);
        }

        public override int ActivateSkill(int currentHP, Animator animator)
        {
            return 0;
        }
    }
}
