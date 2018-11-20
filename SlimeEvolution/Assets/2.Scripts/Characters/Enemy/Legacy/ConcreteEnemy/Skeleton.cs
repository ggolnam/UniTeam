using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SlimeEvolution.GlobalVariable;
using TestLee;

namespace SlimeEvolution.Character.EnemyLagacy
{
    public class Skeleton : Enemy
    {
        
        private void Awake()
        {
            WaitingTime = 3f;
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            animator = gameObject.GetComponent<Animator>();
            characterStat.MaxHP = 30;
            characterStat.CurrentHP = characterStat.MaxHP;
            recoveryAmount = 5;
            characterStat.Speed = 5f;
            characterStat.Damage = 1;
            attackRange = 2.1f;
            state = state = EnemyStateType.Idle;
            enemy = new NamedEnemy(new NormalAttack(characterStat.Damage), new RecoverHP(recoveryAmount),
                new Throwing(characterStat.Damage), new Patrol(characterStat.Speed), new Chasing(characterStat.Speed),
                new StopMovement()
                );

            //testmediator = new TestMediator();
        }

        private void Start()//OnEnable로 쓸지를 고려
        {
            state = EnemyStateType.Idle;
        }

        private void Update()
        {
            //Vector3 test = testmediator.GetGoblinsPosition();
            //Debug.Log(test);
            Timer += Time.deltaTime;
            switch (state)
            {
                case EnemyStateType.Idle:
                    if (Timer >= WaitingTime)
                    {
                        enemy.Stop(navMesh, gameObject.transform, animator);
                        Timer = 0f;
                        state = EnemyStateType.Patrol;
                    }
                    break;
                case EnemyStateType.Patrol:
                    if (Timer >= WaitingTime)
                    {
                        enemy.Move(navMesh, gameObject.transform, animator);
                        Timer = 0f;
                        state = EnemyStateType.Idle;
                    }
                    break;
                case EnemyStateType.Chase:
                    if (Random.Range(0, 30) == 0)
                    {
                        enemy.Skill1(playerObject.transform.position, this.gameObject.transform, animator, navMesh);
                    }
                    else
                    {
                        enemy.Chase(navMesh, gameObject.transform, playerObject.transform.position, animator);
                    }
                    break;
                case EnemyStateType.Combat:
                    enemy.Attack(playerObject.transform.position, gameObject.transform, animator, navMesh);
                    break;
                case EnemyStateType.Week:
                    enemy.RecoveryHP(CharacterStat.CurrentHP, animator);
                    break;
                case EnemyStateType.Death:

                    //죽는모션
                    //Death count저장(이건 상의 후 결정)
                    //몇 초 후
                    //해당 오브젝트풀에 집어넣기
                    //Death 상태를 어떻게 지정해 줄 것인가.
                    break;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                state = EnemyStateType.Chase;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Vector3.Distance(this.gameObject.transform.position,
                    other.gameObject.transform.position) <= attackRange)
                {
                    state = EnemyStateType.Combat;
                    if ((characterStat.CurrentHP < characterStat.MaxHP * 0.1f) 
                        && (Random.Range(0, 30) == 0))
                    {
                        state = EnemyStateType.Week;
                    }
                }
                else
                {
                    state = EnemyStateType.Chase;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                state = EnemyStateType.Idle;
            }
        }
    }
}
