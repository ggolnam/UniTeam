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
            StartCoroutine(EnemyIdle());
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                state = EnemyStateType.Chase;
                StopCoroutine(EnemyIdle());
                StartCoroutine(EnemyChase(other.gameObject));
            }
        }

        //ontriggerstay를 쓰는방향으로 오늘안에 enemy마무리합시다.
        

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                state = EnemyStateType.Idle;
                StopCoroutine(EnemyChase(other.gameObject));
                StopCoroutine(EnemyAttack(other.gameObject));
                StartCoroutine(EnemyIdle());
            }
        }
        void OnDisable()
        {
            enemyDie();
            StopAllCoroutines();
        }

        void patrol()
        {
            enemy.Move(navMesh, gameObject, animator);
        }
        void chase(GameObject playerObject)
        {
            enemy.Chase(navMesh, gameObject, playerObject, animator);
        }
        void attack(GameObject playerObject)
        {
            enemy.Attack(playerObject, gameObject, animator, navMesh);
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

        IEnumerator EnemyIdle()
        {
            while (state == EnemyStateType.Idle)
            {
                patrol();
                yield return new WaitForSeconds(2.0f);
                stop();
                yield return new WaitForSeconds(2.0f);
            }
        }
        IEnumerator EnemyChase(GameObject playerObject)
        {
            while (state == EnemyStateType.Chase)
            {
                if (Vector3.Distance(playerObject.transform.position, this.gameObject.transform.position) <= attackRange)
                {
                    stop();
                    state = EnemyStateType.Combat;
                    nextBehavior = StartCoroutine(EnemyAttack(playerObject));
                    StopCoroutine(EnemyAttack(playerObject));
                   yield return nextBehavior;
                }
                chase(playerObject);
                yield return new WaitForSeconds(0.5f);
            }
            
        }
        IEnumerator EnemyAttack(GameObject playerObject)
        {
            while (state == EnemyStateType.Combat)
            {
                if (Vector3.Distance(playerObject.transform.position, this.gameObject.transform.position) > attackRange)
                {
                    chase(playerObject);
                    state = EnemyStateType.Chase;
                    nextBehavior = StartCoroutine(EnemyChase(playerObject));
                    StopCoroutine(EnemyChase(playerObject));
                    yield return nextBehavior;
                }
                stop();
                attack(playerObject);
                yield return new WaitForSeconds(2f);
            }
        }
        
        IEnumerator EnemyDie()
        {
            return null;
        }

    }
}