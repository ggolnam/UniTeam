using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public abstract class EnemySkill
    {
        public GameObject enemy;
        public abstract int ActivateSkill(int currentHP, Animator animator);
        public abstract void ActivateSkill();
    }
    


    public class RecoverHP : EnemySkill
    {
        int recoveryAmount;

        public RecoverHP(int recoveryAmount)
        {
            this.recoveryAmount = recoveryAmount;
        }
        public override int ActivateSkill(int currentHP, Animator animator)
        {
            animator.SetBool("isRecovering", true);
            currentHP = currentHP + recoveryAmount;
            Debug.Log(recoveryAmount);
            //animator.SetBool("isRecovering", false);
            return currentHP;
        }
        public override void ActivateSkill()
        {
            
        }
    }
    public class Throwing : EnemySkill
    {
        public Throwing()
        {

        }

        public override void ActivateSkill()
        {
            
        }

        public override int ActivateSkill(int currentHP, Animator animator)
        {
            throw new System.NotImplementedException();
        }
    }
}
