using SlimeEvolution.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public abstract class AttackSkill 
    {
        protected int skillLevel;
        protected Transform playerTransform;


        public AttackSkill(Transform playerTransform, PlayerForm playerForm)
        {
            this.playerTransform = playerTransform;
            skillLevel = DataManager.Instance.GameData.PlayerList[DataManager.Instance.playerNumber].SkillLevels[(int)playerForm].AttackSkillLevel;

        }

        public abstract void Use(Transform target);
    }
}
