using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character
{
    public struct CharacterStat
    { 
        public int MaxHP;
        public int CurrentHP;
        public int MaxMP;
        public int CurrentMP;
        public int Damage;
        public float Speed;
        public float AttackRange;
    }

    public abstract class Character : MonoBehaviour
    {
        protected CharacterStat characterStat;
        
    }
}