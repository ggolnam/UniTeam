using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeEvolution.Character;

namespace SlimeEvolution.Character.Enemy
{
    public enum EnemyState
    {
        Idle,
        Combat,
        Death,
    }

    public class Goblin : Character
    {
        AbstractionEnemy goblin;

        private void Awake()
        {
            //임시 수치
            hp = 10;
            speed = 5.0f;
            damage = 1;

            goblin = new NormalEnemy(
                new NormalAttack(), new IdleMovement(speed), new Chase()
                );
        }

        private void Start()
        {
            StartCoroutine(randomMove());
        }

        private void Update()
        {
            //goblin.Chase();
        }

        private void Move()
        {
            goblin.Move();
        }

        IEnumerator randomMove()
        {
            while(true)
            {
                Move();
                yield return new WaitForSeconds(0.1f);
            }
        }

        //코루틴이나 기타 이벤트함수를 기준으로 몬스터를 움직인다.
        //매개변수를 Awake쪽의 생성부분에서 넣어준다.
    }
}