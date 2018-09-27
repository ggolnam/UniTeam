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

                Attack(other.gameObject, gameObject);
                ///EnemyAttack
                //if (Vector3.Distance(other.gameObject.transform.position, this.transform.position) < 10)
                //{
                //    Vector3 direction = other.gameObject.transform.position - this.transform.position;
                //    direction.y = 0;
                //    this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                //        Quaternion.LookRotation(direction), 1.0f);
                //    goblinAnimator.SetBool("isAttcking", true);
                //}
                ///
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

        private void Attack(GameObject gameObject, GameObject EnemyObject)
        {
            goblin.Attack(gameObject, EnemyObject, goblinAnimator, navMeshAgent);
        }


        IEnumerator moveToRandomPosition()
        {
            //지금 상황에서 조건을 꼭 넣을필요는 없을듯 
            while(enemyState == EnemyState.Idle)
            {
                stopMove();
                yield return new WaitForSeconds(1.0f);
                
                Move();
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}