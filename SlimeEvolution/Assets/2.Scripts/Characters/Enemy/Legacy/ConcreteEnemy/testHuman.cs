using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SlimeEvolution.GlobalVariable;

namespace SlimeEvolution.Character.LagacyEnemy
{
    public class testHuman: Enemy
    {
        private void Awake()
        {
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
            
        }
        private void Update()
        {
            switch (state)
            {
                case EnemyStateType.Idle: 
                    patrol();
                    break;
                case EnemyStateType.Chase:
                    chase();
                    break;
                case EnemyStateType.Combat:
                    attack();
                    break;
                case EnemyStateType.Dying:
                    useRecoveringHP();
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
                if(Vector3.Distance(this.gameObject.transform.position , other.gameObject.transform.position) <= 2)
                {
                    state = EnemyStateType.Combat;
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

        void patrol()
        {
            enemy.Move(navMesh, gameObject, animator);
        }

        void chase( )
        {
            enemy.Chase(navMesh, gameObject, playerObject, animator);
        }
        void attack( )
        {
            enemy.Attack(playerObject, gameObject, animator, navMesh);
        }
        void useRecoveringHP()
        {
            //이부분 반환형식이나 누적연산에 대해 더 고려해볼것
            characterStat.CurrentHP += enemy.RecoveryHP(characterStat.CurrentHP, animator);
        }
        void useSmeshing(GameObject playerObject)
        {
            enemy.Skill1(playerObject, this.gameObject, animator, navMesh);
        }
        void stop()
        {
            enemy.Stop(navMesh, gameObject, animator);
        }
        void enemyDie() //상위 클래스에서 구현하여 상속만 하면 가능
        {
            Debug.Log("죽음");
            //몬스터 죽음의 카운트를 시스템에 전송(시스템으로부터 메소드를 받아야함)
        }
    }
}