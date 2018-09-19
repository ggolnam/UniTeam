using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    private Goblin(EnemySkill skill)
    {
       HP = 10;
       movingSpeed = 5.9f;
       skill = new RecoverHP(10);
    }

    private void Awake()
    {
        //HP = 10;
        //movingSpeed = 5.0f;
        
    }

    private void Update()
    {
        skill.UseSkill();
    }
}
