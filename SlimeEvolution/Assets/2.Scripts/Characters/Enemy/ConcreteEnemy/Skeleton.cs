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
        GameObject playerObject;
        [SerializeField]
        GameObject basePosition;

        AbstractionEnemy skeleton;
        NavMeshAgent navMeshAgent;
        Animator animator;
        //Coroutine patrolCo;
        //IEnumerator EnemyChase;

        EnemyStateType state;

        private void Awake()
        {
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            animator = gameObject.GetComponent<Animator>();
            maxHP = 15;
            currentHP = maxHP;
            speed = 1.5f;
            damage = 2;
            state = EnemyStateType.Idle;
            //patrolCo = StartCoroutine("EnemyChase", 0.5f);
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
            if ((Vector3.Distance(playerObject.transform.position, gameObject.transform.position) < 8)
                && (Vector3.Distance(playerObject.transform.position, gameObject.transform.position) >= 1)) 
            {
                state = EnemyStateType.Chase;
            }
            if (Vector3.Distance(playerObject.transform.position, gameObject.transform.position) >= 8)
            {
                state = EnemyStateType.Idle;
            }
            if (Vector3.Distance(playerObject.transform.position, gameObject.transform.position) < 1)
            {
                state = EnemyStateType.Combat;
            }
            //if(gameObject.activeInHierarchy == false)
            //{
            //    state = EnemyStateType.Death;
            //}
        }
       
        void patrol()
        {
            skeleton.Move(navMeshAgent, gameObject, animator);
        }

        void chase()
        {
            skeleton.Chase(navMeshAgent, gameObject, playerObject, animator);
        }

        void attack()
        {
            skeleton.Attack(playerObject, gameObject, animator, navMeshAgent);
        }

        void stop()
        {
            skeleton.Stop(navMeshAgent, gameObject, animator);
        }
        //코루틴에 enum형식의 조건문이 적용이 되는가 안되는가? Coroutine안에서의 조건문 사용법에 대해 알아보기
        IEnumerator MonsterBehavior()
        {
            Coroutine nextBehavior;
            while (true)
            {
                if (state == EnemyStateType.Idle)
                {
                    StopCoroutine(MonsterBehavior());
                    nextBehavior = StartCoroutine(EnemyIdle());
                    yield return nextBehavior;
                }
                if (state == EnemyStateType.Chase)
                {
                    //StopCoroutine(MonsterBehavior());
                    nextBehavior = StartCoroutine(EnemyChase());
                    yield return nextBehavior;
                }
                if (state == EnemyStateType.Combat)
                {
                    //StopCoroutine(MonsterBehavior());
                    nextBehavior = StartCoroutine(EnemyAttack());
                    yield return nextBehavior;
                }
            }
        }
        IEnumerator EnemyIdle()
        {
            Coroutine nextBehavior;
            //while (state == EnemyStateType.Idle)
            //{
                if (state != EnemyStateType.Idle)
                {
                    nextBehavior = StartCoroutine(MonsterBehavior());
                    StopCoroutine(EnemyIdle());
                    yield return nextBehavior;
                    //break;
                }
                patrol();
                yield return new WaitForSeconds(2.0f);
                stop();
                yield return new WaitForSeconds(2.0f);
            //}
        }
        IEnumerator EnemyChase()
        {//stack over flow
            Coroutine nextBehavior;
            //while (state == EnemyStateType.Chase)
            //{
                if (state != EnemyStateType.Chase)
                {
                    nextBehavior = StartCoroutine(MonsterBehavior());
                    StopCoroutine(EnemyChase());
                    yield return nextBehavior;
                    //break;
                }
                chase();
                yield return new WaitForSeconds(0.1f);
            //}
        }
        IEnumerator EnemyAttack()
        {
            Coroutine nextBehavior;
            //while (state == EnemyStateType.Combat)
            //{
                if (state != EnemyStateType.Combat)
                {
                    nextBehavior = StartCoroutine(MonsterBehavior());
                    StopCoroutine(EnemyAttack());
                    yield return nextBehavior;
                    //break;
                }
                attack();
                yield return new WaitForSeconds(0.1f);
            //}
        }

        IEnumerator EnemyDie()
        {
            Debug.Log("몬스터 쥬금");
            return null;
        }

    }
}