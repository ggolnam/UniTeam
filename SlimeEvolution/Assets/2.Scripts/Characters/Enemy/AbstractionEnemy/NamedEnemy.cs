﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public class NamedEnemy:AbstractionEnemy
    {
        
        public NamedEnemy(EnemyAttack attack, EnemySkill skill,
            EnemySkill skill2, EnemyMovement movement, EnemyMovement chase, EnemyMovement stop)
            : base(attack, skill, movement, chase, stop)
        { }

        public override void Attack()
        {
            attack.Attack();
        }

        public override void UseSkill()
        {
            skill1.ActivateSkill();
        }

        public void UseSkill2()
        {
            skill2.ActivateSkill();
        }

        public override void Move(NavMeshAgent meshAgent, GameObject gameObject, Animator animator)
        {
            movement.Move(meshAgent, gameObject, animator);
        }

        public override void Chase(NavMeshAgent meshAgent, GameObject gameObject, GameObject player, Animator animator)
        {
            chase.Chase(meshAgent, gameObject, player, animator);
        }

        public override void Stop(NavMeshAgent navMeshAgent, GameObject gameObject, Animator animator)
        {
            stopMovement.Move(navMeshAgent, gameObject, animator);
        }
    }
}
