using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeEvolution.Character;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public enum EnemyState
    {
        Idle,
        Chase,
        Combat,
        Death
    }

    //코루틴이나 기타 이벤트함수를 기준으로 몬스터를 움직인다.
    //매개변수를 Awake쪽의 생성부분에서 넣어준다.

    public class Goblin : Character
    {
        AbstractionEnemy goblin;
        NavMeshAgent navMeshAgent;
        Animator goblinAnimator;

        float Timer;
        int newtarget;
        Vector3 target;

        EnemyState enemyState;
        

        private void Awake()
        {
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            goblinAnimator = gameObject.GetComponent<Animator>();
            hp = 10;
            speed = 3.0f;
            damage = 1;
            enemyState = EnemyState.Idle;

            goblin = new NormalEnemy(
                new NormalAttack(damage), new RandomMovement(speed), 
                new Chasing(speed), new StopMovement());
        }


        private void Start()
        {

            StartCoroutine(moveToRandomPosition());
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                enemyState = EnemyState.Chase;
                StopCoroutine(moveToRandomPosition());
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                enemyState = EnemyState.Chase;
                Chase(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                enemyState = EnemyState.Idle;
                StartCoroutine(moveToRandomPosition());
            }
        }

        
        private void Chase(GameObject player)
        {
            goblin.Chase(navMeshAgent, gameObject, player, goblinAnimator);
        }
        
        private void Move()
        {
            goblin.Move(navMeshAgent, gameObject, goblinAnimator);
        }

        private void stopMove()
        {
            goblin.Stop(navMeshAgent, gameObject, goblinAnimator);
        }

        private void Attack()
        {
            goblin.Attack();
        }


        IEnumerator moveToRandomPosition()
        {
            //지금 상황에서 조건을 꼭 넣을필요는 없을듯 
            while(enemyState == EnemyState.Idle)
            {
                Move();
                yield return new WaitForSeconds(2.0f);
                stopMove();
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}