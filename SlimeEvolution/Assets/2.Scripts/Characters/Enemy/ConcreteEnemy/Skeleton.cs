using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    //현재 Vector3.Distance로 Enemy움직임을 조정할 수 있는 법을 생각중
    public class Skeleton : Character
    {
        //임시 플레이어 공간 //다른 구현법 테스트 //이 구조를 이용하려면 Mediator클래스가 필수적이다.
        [SerializeField]
        GameObject playerPosition;
        [SerializeField]
        GameObject basePosition;

        AbstractionEnemy skeleton;
        NavMeshAgent navMeshAgent;
        Animator skeletonAnimator;

        EnemyState state;

        private void Awake()
        {
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            skeletonAnimator = gameObject.GetComponent<Animator>();
            maxHP = 15;
            currentHP = maxHP;
            speed = 1.5f;
            damage = 2;

            skeleton = new NamedEnemy(
                new NormalAttack(damage), new RecoverHP(), 
                new Defence(), new Patrol(speed),new Chasing(speed), new StopMovement());
        }
        private void Start()
        {
            StartCoroutine(MonsterBehavior());
        }
        private void Update()
        {
            //항상 체크를 하는데 문제없으려나
            if ((Vector3.Distance(playerPosition.transform.position, gameObject.transform.position) < 10)
                && (Vector3.Distance(playerPosition.transform.position, gameObject.transform.position) >= 3)) 
            {
                //StopCoroutine(patrolAround());
                //StartCoroutine(chasePlayer());
                state = EnemyState.Chase;
                
                if(Vector3.Distance(playerPosition.transform.position, gameObject.transform.position) >= 10)
                {
                    //StopCoroutine(chasePlayer());
                    //StartCoroutine(patrolAround());
                    state = EnemyState.Idle;
                }
            }
            
            if (Vector3.Distance(playerPosition.transform.position, gameObject.transform.position) < 3)
            {
                //StopCoroutine(chasePlayer());
                //StartCoroutine(attackPlayer());
                state = EnemyState.Combat;
            }
        }

        void patrol()
        {
            
        }

        void chase()
        {
            
        }

        void attack()
        {

        }

        void stop()
        {

        }
        /// <summary>
        /// 9월 28일 다음엔 여기서부터 합시다.////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>

        //코루틴에 enum형식의 조건문이 적용이 되는가 안되는가? Coroutine안에서의 조건문 사용법에 대해 알아보기
        IEnumerator MonsterBehavior()
        {
            while (state == EnemyState.Idle)
            {
                patrol();
                yield return new WaitForSeconds(2.0f);
                stop();
                yield return new WaitForSeconds(2.0f);
            }
            while(state == EnemyState.Chase)
            {
                chase();
            }
            while(state == EnemyState.Combat)
            {
                attack();
                yield return new WaitForSeconds(0.5f);
            }
            while(state == EnemyState.Death)
            {

            }
        }
        
    }
}