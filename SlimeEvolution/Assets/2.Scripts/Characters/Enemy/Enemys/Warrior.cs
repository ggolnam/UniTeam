using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Enemy
{
    //상위 클래스에서 선언된 implement관련 상위클래스(인터페이스)를 이 곳(concrete enemy)에서 
    //new 해줘야 한다.
    //상위 클래스에서 선언된 bool을 concrete class에 생성자로 넘겨준다(실시간으로 넘겨줘야하나..? 그렇겠지?)
    Warrior()
    {
        //movement = new NormalMovement(gameObject); //매개변수 고민
        //attack1 = new NormalAttack();
        //attack2 = new ChargeAttack();
        //skill = new RecoverHP();
    }

}
