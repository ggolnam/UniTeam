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
        
        public Skill(PlayerForm playerForm)
        {

            switch(playerForm)
            {
                case PlayerForm.Slime :
                    break;
                case PlayerForm.Goblin :
                    break;
                case PlayerForm.Skeleton :
                    break;
                case PlayerForm.Human :
                    break;
            }
        }

        public void UseAttackSkill()
        {

        }

        public void UseDefendSkill()
        {

        }

        public void UseBuffSkill()
        {

        }

    }      
}
