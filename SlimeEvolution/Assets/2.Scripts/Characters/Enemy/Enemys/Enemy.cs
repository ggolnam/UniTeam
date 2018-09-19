using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SlimeEvolution.Character.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public int HP;
        public int attackPoint;
        public float movingSpeed;
        //protected EnemyState state;
        public EnemySkill skill;
        public EnemySkill skill2;

        //protected Rigidbody rigidbody;


        private void Start()
        {
            //rigidbody = GetComponent<Rigidbody>();
        }

    }
}