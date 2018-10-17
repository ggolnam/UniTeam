using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemySkill
    {
        public GameObject enemy;
        public int magnification;
        public abstract int ActivateSkill(int currentHP, Animator animator);
        public abstract void ActivateSkill(GameObject playerObject, GameObject EnemyObject,
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

        public override void ActivateSkill(GameObject playerObject, GameObject EnemyObject,
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

        public override void ActivateSkill(GameObject playerObject, GameObject EnemyObject,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            GameObject throwingObject;
            Vector3 playerPosition = playerObject.transform.position;
            EnemyObject.transform.LookAt(playerPosition);
            throwingObject = ThrowingObjectPool.Instance.PopFromPool(EnemyObject.transform);
            throwingObject.transform.position = new Vector3(EnemyObject.transform.position.x, 0.5f, EnemyObject.transform.position.z);
            
            
            //성능 f.....
            Rigidbody throwingRigid = throwingObject.GetComponent<Rigidbody>();
            throwingObject.transform.position = throwingObject.transform.position + EnemyObject.transform.forward * 2;
            throwingRigid.velocity = EnemyObject.transform.forward * 10;
           
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
        public override void ActivateSkill(GameObject playerObject, GameObject EnemyObject,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            navMeshAgent.speed = 0f;
            EnemyObject.transform.LookAt(playerObject.transform.position);
            animator.SetBool("isSmeshAttacking", true);
            animator.SetFloat("speed", navMeshAgent.speed);
        }

        public override int ActivateSkill(int currentHP, Animator animator)
        {
            return 0;
        }
    }
}
