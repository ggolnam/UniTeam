using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public class Human : Enemy
    {
        Coroutine nextBehavior;

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
       
        private void Start()//OnEnable로 쓸지를 고려
        {
            StartCoroutine(EnemyIdle());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                state = EnemyStateType.Chase;
                StopCoroutine(EnemyIdle());
                StartCoroutine(EnemyChase(other.gameObject));
            }
        }

        //ontriggerstay를 쓰는방향으로 오늘안에 enemy마무리합시다.
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
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

        IEnumerator EnemyIdle()
        {
            while (state == EnemyStateType.Idle)
            {
                patrol();
                yield return new WaitForSeconds(1f);
                stop();
                yield return new WaitForSeconds(2f);
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
                yield return new WaitForSeconds(1f);
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
                yield return new WaitForSeconds(1.5f);
                if (Random.Range(0, 1) == 0)
                {
                    useSmeshing(playerObject);
                }
                //yield return new WaitForSeconds(1f);
                //여기서부터시작 . 유즈 스매시 컨트롤하기
                animator.SetBool("isSmeshAttacking", false);
                animator.SetBool("isAttacking", true);
                if ((characterStat.CurrentHP <= characterStat.MaxHP * hpPercentage)
                    && (Random.Range(0, 100) == 0))
                {
                    useRecoveringHP();
                }
            }
        }

        IEnumerator EnemyDie()
        {
            return null;
        }

    }
}
