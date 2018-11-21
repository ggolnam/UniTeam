using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.EnemyLagacy
{
    public abstract class AbstractionEnemy
    {
        protected EnemySkill skill1;
        protected EnemySkill skill2;
        protected EnemyAttack attack;
        protected EnemyMovement movement;
        protected EnemyMovement chase;
        protected EnemyMovement stopMovement;
        
        protected int AttackPoint;

        //Normal Enemy
        public AbstractionEnemy(EnemyAttack attack, EnemyMovement movement, 
            EnemyMovement chase, EnemyMovement stopMovement)
        {
            this.attack = attack;
            this.movement = movement;
            this.chase = chase;
            this.stopMovement = stopMovement;
        }

        //Named Enemy
        public AbstractionEnemy(EnemyAttack attack, EnemySkill skill1, EnemySkill skill2,
            EnemyMovement movement, EnemyMovement chase, EnemyMovement stopMovement):this(attack, movement, chase, stopMovement)
        {
            this.attack = attack;
            this.skill1 = skill1;
            this.skill2 = skill2;
            this.movement = movement;
            this.chase = chase;
            this.stopMovement = stopMovement;
        }
        

        public abstract int RecoveryHP(int currentHP, Animator animator);
        public abstract void Skill1(Vector3 playerPosition, Transform enemyTransform,
            Animator animator, NavMeshAgent navMeshAgent);

        public abstract void Attack(Vector3 playerPosition, Transform enemyTransform, 
            Animator animator, NavMeshAgent navMeshAgent);
        public abstract void Move(NavMeshAgent navMeshAgent, Transform enemyTransform, 
            Animator animator);
        public abstract void Chase(NavMeshAgent navMeshAgent, Transform enemyTransform, 
            Vector3 playerPosition, Animator animator);
        public abstract void Stop(NavMeshAgent navMeshAgent, Transform enemyTransform, 
            Animator animator);
       
    }
}