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
            hp = 10;
            speed = 1.5f;
            damage = 1;
            enemyState = EnemyState.Idle;

            goblin = new NormalEnemy(
                new NormalAttack(damage), new IdleMovement(speed), new Chasing(speed));
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
            goblin.Chase(navMeshAgent, gameObject, player);
        }
        
        private void Move()
        {
            goblin.Move(navMeshAgent, gameObject);
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
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}