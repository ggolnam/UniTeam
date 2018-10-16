﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.Character.Enemy
{
    public class NamedEnemy : AbstractionEnemy
    {
        
        public NamedEnemy(EnemyAttack attack, EnemySkill skill1,
            EnemySkill skill2, EnemyMovement movement, EnemyMovement chase, EnemyMovement stop)
            : base(attack, skill1,skill2, movement, chase, stop)
        { }

        public override void Attack(GameObject gameObject, GameObject EnemyObject, Animator animator, NavMeshAgent navMeshAgent)
        {
            attack.Attack(gameObject, EnemyObject, animator, navMeshAgent);
        }

        public override int RecoveryHP(int currentHP, Animator animator)
        {
            return skill1.ActivateSkill(currentHP, animator);
        }

        public override void Skill1(GameObject playerObject, GameObject EnemyObject,
            Animator animator, NavMeshAgent navMeshAgent)
        {
            skill2.ActivateSkill(playerObject, EnemyObject, animator, navMeshAgent);
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
