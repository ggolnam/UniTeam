using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public class Skill
    {
        AttackSkill attackSkill;
        DefendSkill defendSkill;
        BuffSkill buffSkill;
        Transform playerTransform;

        public Skill(PlayerForm playerForm, Transform playerTransform)
        {
            this.playerTransform = playerTransform;
            switch (playerForm)
            {
                case PlayerForm.Slime :
                    attackSkill = new Smashing(playerTransform);
                    break;
                case PlayerForm.Goblin :
                    break;
                case PlayerForm.Skeleton :
                    break;
                case PlayerForm.Human :
                    break;
            }
        }

        public void UseAttackSkill(Transform target)
        {
            attackSkill.Use(target);
        }

        public void UseDefendSkill()
        {

        }

        public void UseBuffSkill()
        {

        }

    }      
}
