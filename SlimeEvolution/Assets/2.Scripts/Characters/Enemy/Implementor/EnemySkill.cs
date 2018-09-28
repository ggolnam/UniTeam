using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemySkill
    {
        public GameObject enemy;
        public abstract void ActivateSkill();
    }
    


    public class RecoverHP : EnemySkill
    {
        int recoveryAmount;

        public RecoverHP()
        {
            recoveryAmount = 10;
        }
        
        public override void ActivateSkill()
        {
            //스킬 구현부
        }
    }
    public class Defence : EnemySkill
    {
        public Defence()
        {

        }

        public override void ActivateSkill()
        {
            //스킬 구현부
            //일정 확률로 해당 콜라이더를 무효화한다
        }
    }
    public class Throw : EnemySkill
    {
        public Throw()
        {

        }

        public override void ActivateSkill()
        {
            //실제 스킬 구현부
        }
    }
}
