using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SlimeEvolution.GameSystem;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class Enemy : Character
    {
        [SerializeField]
        protected GameObject playerObject;
        [SerializeField]
        protected GameObject basePosition;
        
        protected AbstractionEnemy enemy;
        protected NavMeshAgent navMesh;
        protected Animator animator;
        protected EnemyStateType state;

        protected int recoveryAmount;
    }
}
