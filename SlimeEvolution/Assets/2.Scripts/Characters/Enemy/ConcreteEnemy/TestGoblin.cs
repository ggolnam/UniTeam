using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeEvolution.Character;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public enum EnemyStateType
    {
        Idle,
        Chase,
        Combat,
        Dying,
        Death
    }

    //코루틴이나 기타 이벤트함수를 기준으로 몬스터를 움직인다.
    //매개변수를 Awake쪽의 생성부분에서 넣어준다.

    public class TestGoblin : Character
    {
        [SerializeField]
        //Transform player; //플레이어의 위치를 Trigger로 받아오느냐.....Collider로 받아오느냐 그것이 문제로다...
        //return movement에 관해서는 던전시스템자체를 만들어두고 그곳에서 베이스캠프포지션을 받아와서 세팅하는걸로 하자
        AbstractionEnemy goblin;
        NavMeshAgent navMeshAgent;
        Animator animator;

        EnemyStateType enemyState;
        

        private void Awake()
        {
            
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            animator = gameObject.GetComponent<Animator>();
            maxHP = 10;
            currentHP = maxHP;
            speed = 1f;
            damage = 1;
            enemyState = EnemyStateType.Idle;

            goblin = new NormalEnemy(
                new NormalAttack(damage), new Patrol(speed),
                new Chasing(speed), new StopMovement());
        }
       
        private void Start()
        {
            StartCoroutine(patrolAround());
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                enemyState = EnemyStateType.Chase;
                StopCoroutine(patrolAround());
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (enemyState != EnemyStateType.Combat)
                {
                    goblin.Chase(navMeshAgent, gameObject, other.gameObject, animator);
                }
                if (Vector3.Distance(other.gameObject.transform.position, gameObject.transform.position) <= 3)
                {
                    goblin.Stop(navMeshAgent, gameObject, animator);
                    Attack(other.gameObject);
                    enemyState = EnemyStateType.Combat;
                }
                else
                {
                    animator.SetBool("isAttacking", false);
                    enemyState = EnemyStateType.Chase;
                } 
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))    
            {
                enemyState = EnemyStateType.Idle;
                StartCoroutine(patrolAround());
            }
        }
        void Attack(GameObject playerObject)
        {
            goblin.Attack(playerObject, gameObject, animator, navMeshAgent);
            Debug.Log(navMeshAgent.speed);
            enemyState = EnemyStateType.Combat;
        }
        IEnumerator patrolAround()
        { 
            while(enemyState == EnemyStateType.Idle)
            {
                goblin.Stop(navMeshAgent, gameObject, animator);
                yield return new WaitForSeconds(2.0f);

                goblin.Move(navMeshAgent, gameObject, animator);
                yield return new WaitForSeconds(2.0f);
            }
        }
        //IEnumerator moveToOriginPosition()
        //{
        //    yield return new WaitForSeconds(8.0f);
        //}
    }
}