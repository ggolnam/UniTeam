using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeEvolution.Character;

namespace SlimeEvolution.Character.Enemy
{
    public class Goblin : Character
    {
        AbstractionEnemy goblin;

        private void Awake()
        {
            hp = 10;
            speed = 5.0f;
            damage = 1;

            goblin = new NormalEnemy(
                new NormalAttack(damage), new NormalMovement(speed), new Chase(speed)
                );
        }

        private void Update()
        {
            goblin.Chase();
        }

        //코루틴이나 기타 이벤트함수를 기준으로 몬스터를 움직인다.
        //매개변수를 Awake쪽의 생성부분에서 넣어준다.
    }
}