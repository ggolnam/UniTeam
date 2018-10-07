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
            this.recoveryAmount = 20;
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
        public Throwing()
        {
           
        }

        public override void ActivateSkill(GameObject playerObject, GameObject EnemyObject,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            Vector3 playerPosition = playerObject.transform.position;
            EnemyObject.transform.LookAt(playerPosition);//플레이어를 향해서 발사한다. 
            //이부분에서는 Objectpool Manager에서 장거리 공격용 오브젝트를 활성화하고 불러와야 한다. 
            //일단 Instantiate로 오브젝트를 생성하는것만 해주면 OK!


            //날아가는 궤도 및 반환조건은 Throwing object의 script에서 구현한다.
            animator.SetBool("isAttacking", true);
        }

        public override int ActivateSkill(int currentHP, Animator animator)
        {
            throw new System.NotImplementedException();
        }
    }
}
