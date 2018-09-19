﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemySkill : MonoBehaviour
    {
        public GameObject enemy;
        public abstract void UseSkill();
    }



    public class RecoverHP : EnemySkill
    {
        public int recoveryAmount;

        public RecoverHP(int hp)
        {
            recoveryAmount = hp;
        }


        public override void UseSkill()
        {
            Debug.Log(recoveryAmount.ToString());
        }
    }





    public class Defend : EnemySkill
    {
        public override void UseSkill()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Throw : EnemySkill
    {
        public override void UseSkill()
        {

        }
    }
}
