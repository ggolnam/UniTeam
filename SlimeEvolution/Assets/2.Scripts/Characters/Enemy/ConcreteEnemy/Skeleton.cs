﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    //현재 Vector3.Distance로 Enemy움직임을 조정할 수 있는 법을 생각중
    public class Skeleton : Enemy
    {
        Coroutine nextBehavior;
        private void Awake()
        {
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            animator = gameObject.GetComponent<Animator>();
            maxHP = 15;
            currentHP = maxHP;
            speed = 1.5f;
            damage = 2;
            state = EnemyStateType.Idle;
            //patrolCo = StartCoroutine("EnemyChase", 0.5f);
            enemy = new NamedEnemy(
                new NormalAttack(damage), new RecoverHP(recoveryAmount), 
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

        void stop()
        {
            enemy.Stop(navMesh, gameObject, animator);
        }
        //코루틴에 enum형식의 조건문이 적용이 되는가 안되는가? Coroutine안에서의 조건문 사용법에 대해 알아보기
        IEnumerator MonsterBehavior()
        {
            //Coroutine nextBehavior;
            
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
            nextBehavior = StartCoroutine(MonsterBehavior());
            
        }
        IEnumerator EnemyIdle()
        {
            //Coroutine nextBehavior;
            
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
            //Coroutine nextBehavior;

            if (state != EnemyStateType.Chase)
            {
                nextBehavior = StartCoroutine(MonsterBehavior());
                yield return nextBehavior;
            }
            chase();
            Debug.Log("현재 추격 들어옴");
            yield return new WaitForSeconds(0.5f);

        }
        IEnumerator EnemyAttack()
        {
            //Coroutine nextBehavior;
            if (state != EnemyStateType.Combat)
            {
                nextBehavior = StartCoroutine(MonsterBehavior());
                yield return nextBehavior;
            }
            stop();
            attack();
            //yield return new WaitForSeconds(3.0f);

        }

        IEnumerator EnemyDie()
        {
            Debug.Log("몬스터 쥬금");
            return null;
        }

    }
}