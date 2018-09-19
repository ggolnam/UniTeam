using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementIMP 
{
    protected GameObject enemyObject;
    protected Rigidbody rigidbody;
    protected float enemySpeed;

    protected abstract void move();
}

public class NormalMovement: MovementIMP
{

    public NormalMovement(GameObject enemy, Rigidbody rigidbody, float speed)
    {
        enemyObject = enemy;
        this.rigidbody = rigidbody;
        enemySpeed = speed;
    }

    protected override void move()
    {
        //이동 구현
        //chase 클래스가 MovementIMP하위 클래스로 와야 할 것 같다.
    }
}
