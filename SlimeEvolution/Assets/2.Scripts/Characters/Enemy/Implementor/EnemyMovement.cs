using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemyMovement
    {
        protected float speed;

        public abstract void Move();
       
    }

    public class NormalMovement : EnemyMovement
    {
        public NormalMovement(float speed)
        {
            this.speed = speed;
        }

        public override void Move()
        {
            //Move구현
        }

        
    }

    public class Chase : EnemyMovement
    {

        public Chase(float speed)
        {
            this.speed = speed;
        }

        public override void Move()
        {
            //Move구현
            Debug.Log(speed.ToString() + "의 속도로 쫒아감");
        }
    }
}