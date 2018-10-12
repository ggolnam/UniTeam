using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemySkill
    {
        public GameObject enemy;
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
            Rigidbody throwingRigidbody;
            GameObject throwingObject;
            Vector3 playerPosition = playerObject.transform.position;
            EnemyObject.transform.LookAt(playerPosition);//플레이어를 향해서 발사한다. 
            //일단 Instantiate로 오브젝트를 생성하는것만 해주면 OK!
            throwingObject = ThrowingObjectPool.Instance.PopFromPool(EnemyObject.transform);
            throwingObject.transform.position = new Vector3(
                throwingObject.transform.position.x, 1, throwingObject.transform.position.z);
            
            throwingObject.transform.rotation = EnemyObject.transform.rotation;
            //날아가는 궤도 및 반환조건은 Throwing object의 script에서 구현한다.
            animator.SetBool("isAttacking", true);
        }

        public override int ActivateSkill(int currentHP, Animator animator)
        {
            throw new System.NotImplementedException();
        }
    }
}
