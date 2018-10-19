using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPattern
{
    //실제사용부분
    public class TestBridge : MonoBehaviour
    {
        Enemy imp;
        Enemy Goblin;

        private void Start()
        {
            imp = new WanderingEnemy(new IMP());
            Goblin = new WanderingEnemy(new Goblin());

            imp.Attack();
            Goblin.Attack();
        }
    }

   
    //구현부
    public abstract class AttackAPI
    {
        protected string name;
        protected int attackPower;

        public abstract void attackImplementation();
    }

    public class IMP : AttackAPI
    {
        public IMP()
        {
            name = "IMP";
            attackPower = 1;
        }

        public override void attackImplementation()
        {
            Debug.Log(name);
        }
    }

    public class Goblin: AttackAPI
    {
        public Goblin()
        {
            name = "Goblin";
            attackPower = 2;
        }

        public override void attackImplementation()
        {
            Debug.Log(name);
        }
    }

    //추상부
    public abstract class Enemy
    {
        protected AttackAPI attackAPI;

        protected Enemy(AttackAPI atkApi)
        {
            this.attackAPI = atkApi;
        }

        public abstract void Attack();
    }

    public class WanderingEnemy : Enemy
    {
        public WanderingEnemy(AttackAPI api) : base(api)
        {

        }

        public override void Attack()
        {
            attackAPI.attackImplementation();
        }
    }
}


