﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
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
        public AbstractionEnemy(EnemyAttack attack, EnemySkill skill,
            EnemyMovement movement, EnemyMovement chase, EnemyMovement stopMovement)
        {
            this.attack = attack;
            this.skill1 = skill;
            this.movement = movement;
            this.chase = chase;
            this.stopMovement = stopMovement;
        }
        

        public abstract void UseSkill();
        public abstract void Attack(GameObject gameObject, GameObject EnemyObject, Animator animator, NavMeshAgent navMeshAgent);
        public abstract void Move(NavMeshAgent navMeshAgent, GameObject gameObject, Animator animator);
        public abstract void Chase(NavMeshAgent navMeshAgent, GameObject gameObject, GameObject player, Animator animator);
        public abstract void Stop(NavMeshAgent navMeshAgent, GameObject gameObject, Animator animator);
       
    }
}