using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SlimeEvolution.GlobalVariable;

namespace SlimeEvolution.Character.LagacyEnemy
{
    public class Goblin : Enemy
    {
        Coroutine nextBehavior;

        private void Awake()
        {
            WaitingTime = 2f;
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            animator = gameObject.GetComponent<Animator>();
            characterStat.MaxHP = 20;
            characterStat.CurrentHP = characterStat.MaxHP;
            characterStat.Speed = 1f;
            characterStat.Damage = 1;
            attackRange = 2.1f;

            state = state = EnemyStateType.Idle;
            enemy = new NormalEnemy(
                new NormalAttack(characterStat.Damage), new Patrol(characterStat.Speed),
                new Chasing(characterStat.Speed), new StopMovement());
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
                case EnemyStateType.Death:
                    Debug.Log("죽음");
                    break;
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                state = EnemyStateType.Chase;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                state = EnemyStateType.Chase;
                if (Vector3.Distance(this.gameObject.transform.position,
                    other.gameObject.transform.position) <= attackRange)
                {
                    state = EnemyStateType.Combat;
                }
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                state = EnemyStateType.Idle;
            }
        }

    }
}