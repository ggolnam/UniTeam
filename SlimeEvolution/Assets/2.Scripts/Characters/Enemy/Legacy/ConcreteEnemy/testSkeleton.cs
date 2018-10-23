using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SlimeEvolution.GameSystem;
using SlimeEvolution.GlobalVariable;

namespace SlimeEvolution.Character.LagacyEnemy
{
    public class testSkeleton : Enemy
    {
        Random random;
        Coroutine nextBehavior;
        private void Awake()
        {
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            animator = gameObject.GetComponent<Animator>();
            characterStat.MaxHP = 40;
            recoveryAmount = 20;
            characterStat.CurrentHP = characterStat.MaxHP;
            characterStat.Speed = 1.5f;
            characterStat.Damage = 2;
            
            state = EnemyStateType.Idle;
            enemy = new NamedEnemy(
                new NormalAttack(characterStat.Damage), new RecoverHP(recoveryAmount), 
                new Throwing(characterStat.Damage), new Patrol(characterStat.Speed),new Chasing(characterStat.Speed), new StopMovement());
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
        //trigger enter/ exit로 바꿀 것
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
            if ((characterStat.CurrentHP <= (characterStat.MaxHP * 0.1f)) /*&& (Random.value == 0.1f)*/) 
            {
                state = EnemyStateType.Week;
            }
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
            characterStat.CurrentHP = enemy.RecoveryHP(characterStat.CurrentHP, animator);
        }
        void useThrowing() 
        {
            //이부분은 장거리 공격이므로 추격 중에 일정 확률로 공격해야 한다.
            enemy.Skill1(playerObject, gameObject, animator, navMesh);
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
            if(state == EnemyStateType.Week)
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
            if (Random.Range(0, 100) == 0) 
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
        }
        IEnumerator Recovery()
        {
            if (state == EnemyStateType.Week)
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