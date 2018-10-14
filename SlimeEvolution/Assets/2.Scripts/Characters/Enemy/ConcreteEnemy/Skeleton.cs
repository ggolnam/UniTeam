using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SlimeEvolution.GameSystem;

namespace SlimeEvolution.Character.Enemy
{
    public class Skeleton : Enemy
    {
        Random random;
        Coroutine nextBehavior;
        DungeonMediator mediator;//DungeonMediator 테스트
        private void Awake()
        {
            mediator = new DungeonMediator();//DungeonMediator 테스트
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            animator = gameObject.GetComponent<Animator>();
            maxHP = 40;
            recoveryAmount = 20;
            currentHP = maxHP;
            speed = 1.5f;
            damage = 2;
            
            state = EnemyStateType.Idle;
            enemy = new NamedEnemy(
                new NormalAttack(damage), new RecoverHP(recoveryAmount), 
                new Throwing(damage), new Patrol(speed),new Chasing(speed), new StopMovement());
        }

        //DungeonMediator 테스트
        void testmed()
        {
            // Test = mediator.TestSend();
            //Debug.Log(Test);
        }
        private void Start()
        {
            StartCoroutine(MonsterBehavior());
        }
        private void Update()
        {
            testmed();//DungeonMediator 테스트
            if ((Vector3.Distance(playerObject.transform.position, gameObject.transform.position) < 8)
                && (Vector3.Distance(playerObject.transform.position, gameObject.transform.position) > 2)) 
            {
                state = EnemyStateType.Chase;
            }
            if (Vector3.Distance(playerObject.transform.position, gameObject.transform.position) >= 8)
            {
                state = EnemyStateType.Idle;
            }
            if (Vector3.Distance(playerObject.transform.position, gameObject.transform.position) <= 2)
            {
                state = EnemyStateType.Combat;
            }
            if ((currentHP <= (maxHP/10)) /*&& (Random.value == 0.1f)*/) 
            {
                state = EnemyStateType.Dying;
            }
            //if(gameObject.activeInHierarchy == false)
            //{
            //    state = EnemyStateType.Death;
            //}
        }
       
        void patrol()
        {
            enemy.Move(navMesh, gameObject, animator);
        }
        void chase()
        {
            enemy.Chase(navMesh, gameObject, playerObject, animator);
        }
        void attack()
        {
            enemy.Attack(playerObject, gameObject, animator, navMesh);
        }
        void useRecovering()
        {
            currentHP = enemy.RecoveryHP(currentHP, animator);
        }
        void useThrowing() 
        {
            //이부분은 장거리 공격이므로 추격 중에 일정 확률로 공격해야 한다.
            enemy.Throw(playerObject, gameObject, animator, navMesh);
        }
        void stop()
        {
            enemy.Stop(navMesh, gameObject, animator);
        }

        IEnumerator MonsterBehavior()
        {
            if (state == EnemyStateType.Idle)
            {
                nextBehavior = StartCoroutine(EnemyIdle());
                yield return nextBehavior;
            }
            if (state == EnemyStateType.Chase)
            {
                nextBehavior = StartCoroutine(EnemyChase());
                yield return nextBehavior;
            }
            if (state == EnemyStateType.Combat)
            {
                nextBehavior = StartCoroutine(EnemyAttack());
                yield return nextBehavior;
            }
            if(state == EnemyStateType.Dying)
            {
                nextBehavior = StartCoroutine(Recovery());
                yield return nextBehavior;
            }
           
            nextBehavior = StartCoroutine(MonsterBehavior());
        }
        IEnumerator EnemyIdle()
        {
             if (state != EnemyStateType.Idle)
             {
                 nextBehavior = StartCoroutine(MonsterBehavior());
                 yield return nextBehavior;
             }
             
             patrol();
             yield return new WaitForSeconds(2.0f);
             stop();
             yield return new WaitForSeconds(2.0f);
        }
        IEnumerator EnemyChase()
        {
            if (Random.Range(0, 10) == 0) 
            {
                //stop();
                useThrowing();
                //yield return new WaitForSeconds(0.8f);
                Debug.Log("useThrowing 메소드 입구 들어옴");
            }
            if (state != EnemyStateType.Chase)
            {
                stop();
                nextBehavior = StartCoroutine(MonsterBehavior());
                yield return nextBehavior;
            }
            chase();
            //일정 확률로 Throw()를 호출한다.
            //yield return new WaitForSeconds(0.1f); //몬스터 움직임 끊김문제
            
        }
        IEnumerator EnemyAttack()
        {
            if (state != EnemyStateType.Combat)
            {
                nextBehavior = StartCoroutine(MonsterBehavior());
                yield return nextBehavior;
            }
            stop();
            attack();
            //yield return new WaitForSeconds(2.0f);
        }
        IEnumerator Recovery()
        {
            if (state == EnemyStateType.Dying)
            {
                useRecovering();

                yield return new WaitForSeconds(1f);
                animator.SetBool("isRecovering", false); //왜 이샛기만 들어가면 중첩합 버그나 날까 ... ?
                StopCoroutine(Recovery());

                state = EnemyStateType.Idle;
               
                nextBehavior = StartCoroutine(MonsterBehavior());
                yield return nextBehavior;
            }
        }
        IEnumerator EnemyDie()
        {
            Debug.Log("몬스터 쥬금");
            return null;
        }
    }
}