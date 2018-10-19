﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SlimeEvolution.GameSystem;
using SlimeEvolution.GlobalVariable;

namespace SlimeEvolution.Character.LagacyEnemy
{
    public abstract class Enemy : Character
    {
        [SerializeField]
        public GameObject playerObject;
        [SerializeField]
        public GameObject basePosition;
        
        protected AbstractionEnemy enemy;
        protected NavMeshAgent navMesh;
        protected Animator animator;
        protected EnemyStateType state;

        protected int recoveryAmount;
        protected const float hpPercentage = 0.1f;
        protected float attackRange;
    }
}