using SlimeEvolution.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public abstract class AttackSkill 
    {
        protected int skillLevel;
        protected float coolTime;
        protected Transform playerTransform;


        public AttackSkill(Transform playerTransform, PlayerForm playerForm)
        {
            this.playerTransform = playerTransform;
            Debug.Log(TestDataManager.Instance.playerNumber);
            skillLevel = TestDataManager.Instance.GameData.PlayerList[TestDataManager.Instance.playerNumber].SkillLevels[(int)playerForm].AttackSkillLevel;
            
        }

        public abstract IEnumerator Use(Transform target);
    }
}
