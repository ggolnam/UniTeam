using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    //현재 Vector3.Distance로 Enemy움직임을 조정할 수 있는 법을 생각중
    public class Skeleton : Enemy
    {
        Random random;
        Coroutine nextBehavior;
        public new int maxHP;
        public new int currentHP;
        private void Awake()
        {
            navMesh = gameObject.GetComponent<NavMeshAgent>();
            animator = gameObject.GetComponent<Animator>();
            maxHP = 40;
            recoveryAmount = 20;
            currentHP = maxHP;
            speed = 1.5f;
            damage = 2;
            state = EnemyStateType.Idle;
            //patrolCo = StartCoroutine("EnemyChase", 0.5f);
            enemy = new NamedEnemy(
                new NormalAttack(damage), new RecoverHP(recoveryAmount), 
                new Throwing(), new Patrol(speed),new Chasing(speed), new StopMovement());
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
            enemy.Throw();
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
            if (state != EnemyStateType.Chase)
            {
                nextBehavior = StartCoroutine(MonsterBehavior());
                yield return nextBehavior;
            }
            chase();
            yield return new WaitForSeconds(0.5f);
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
            yield return new WaitForSeconds(2.0f);
        }
        IEnumerator Recovery()
        {
            if (state == EnemyStateType.Dying)
            {
                useRecovering();
                yield return new WaitForSeconds(1f);
                animator.SetBool("isRecovering", false); //왜 이샛기만 들어가면 중첩합 버그나 날까 ... ?
                StopCoroutine(Recovery());
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