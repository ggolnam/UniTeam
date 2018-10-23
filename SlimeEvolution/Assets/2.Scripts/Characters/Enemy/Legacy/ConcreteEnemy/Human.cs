using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SlimeEvolution.GlobalVariable;

namespace SlimeEvolution.Character.LagacyEnemy
{
    public class Human: Enemy
    {
        private void Awake()
        {
            WaitingTime = 2.5f;
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            animator = gameObject.GetComponent<Animator>();
            characterStat.MaxHP = 50;
            characterStat.CurrentHP = characterStat.MaxHP;
            recoveryAmount = 10;
            characterStat.Speed = 1f;
            characterStat.Damage = 3;
            attackRange = 2.1f;

            state = state = EnemyStateType.Idle;
            enemy = new NamedEnemy(new NormalAttack(characterStat.Damage), new RecoverHP(recoveryAmount),
                new SmeshAttack(), new Patrol(characterStat.Speed), new Chasing(characterStat.Speed),
                new StopMovement()
                );
        }

        private void Start()
        {
            state = EnemyStateType.Idle;
        }

        private void Update()
        {
            Timer += Time.deltaTime;
            switch (state)
            {
                
                case EnemyStateType.Idle:
                    if (Timer >= WaitingTime)
                    {
                        enemy.Stop(navMesh, gameObject, animator);
                        Timer = 0f;
                        state = EnemyStateType.Patrol;
                    }
                    break;
                case EnemyStateType.Patrol:
                    if (Timer >= WaitingTime)
                    {
                        enemy.Move(navMesh, gameObject, animator);
                        Timer = 0f;
                        state = EnemyStateType.Idle;
                    }
                    break;
                case EnemyStateType.Chase:
                    enemy.Chase(navMesh, gameObject, playerObject, animator);
                    break;
                case EnemyStateType.Combat:
                    enemy.Attack(playerObject, gameObject, animator, navMesh);
                    break;
                case EnemyStateType.Week:
                    characterStat.CurrentHP += enemy.RecoveryHP(characterStat.CurrentHP, animator);
                    break;
                case EnemyStateType.Death:
                    Debug.Log("죽음");
                    break;

            }
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            state = EnemyStateType.Chase;
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                if(Vector3.Distance(this.gameObject.transform.position , 
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
            if(other.CompareTag("Player"))
            state = EnemyStateType.Idle;
        }
    }
}