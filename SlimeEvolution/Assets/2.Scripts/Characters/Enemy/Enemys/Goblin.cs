using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public class Goblin : Enemy
    {
        public Goblin(EnemySkill skill, EnemySkill skill2)
        {
            this.skill = skill;
            this.skill2 = skill2;
        }
        
        public void UseSkill()
        {
            skill.UseSkill();
        }
    }
}