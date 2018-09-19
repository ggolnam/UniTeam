using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    private Goblin()
    {
        movingSpeed = 5.0f;
        movement = new NormalMovement(gameObject, rigidbody, movingSpeed); //매개변수 고민
        attack1 = new NormalAttack();

        state = new Battle(); //이 스테이트를 각각 어떻게 선언해야 하는가 .....
    }

   
}
