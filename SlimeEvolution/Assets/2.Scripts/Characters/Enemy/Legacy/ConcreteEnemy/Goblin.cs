using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SlimeEvolution.GlobalVariable;
using SlimeEvolution.GameSystem;

namespace SlimeEvolution.Character.EnemyLagacy
{
    public class Goblin : Enemy
    {
        private void Awake()
        {
            WaitingTime = 2f;
            
            animator = gameObject.GetComponent<Animator>();
            characterStat.MaxHP = 20;
            characterStat.CurrentHP = characterStat.MaxHP;
            characterStat.Speed = 5f;
            characterStat.Damage = 1;
            attackRange = 2.1f;

            state = state = EnemyStateType.Idle;
            enemy = new NormalEnemy(
                new NormalAttack(characterStat.Damage), new Patrol(characterStat.Speed),
                new Chasing(characterStat.Speed), new StopMovement());
        }
        
        private void Start()
        {
            navMesh = gameObject.GetComponent<NavMeshAgent>();
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
                    enemy.Chase(navMesh, gameObject.transform, playerObject.transform.position, animator);
                    break;
                case EnemyStateType.Combat:
                    enemy.Attack(playerObject.transform.position, gameObject.transform, animator, navMesh);
                    break;
                case EnemyStateType.Death:
                    //death카운트를 GameController역할을 하는 놈에게 보낸다. //mediator? callback?
                    //
                    
                    EnemyObjectManager.Instance.goblinPool.PushToPool(gameObject);
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
                ////////////////
                if(characterStat.CurrentHP <= 0)
                {
                    state = EnemyStateType.Death;
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