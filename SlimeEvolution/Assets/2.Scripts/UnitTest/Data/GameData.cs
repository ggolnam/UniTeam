using System.Collections.Generic;
using System;

namespace SlimeEvolution.GameSystem
{
    [Serializable]
    public struct StatData
    {
        public int HealthPoint;
        public int ManaPoint;
        public int SkillPoint;
        public int StrikingPower;
        public int DefensivePower;
        public int Critical;
        public int Experience;
    }

    [Serializable]
    public struct SkillData
    {
        public int AttackSkillLevel;
        public int DefendSkillLevel;
        public int BuffSkillLevel;
    }

    public struct ItemData
    {
        
    }

    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        //인벤토리 슬롯넘 --> 아이템//
        //장비 슬롯넘 --> 아이템//
        
        public int SlotNumber;
        public int Level;
        public int Gold;
        public StatData Stat;
        public SkillData[] SkillLevels = new SkillData[4];
        public PlayerData(int slotNumber)
        {
            Level = 1;
            SlotNumber = slotNumber;
            Stat.HealthPoint = 100;
            Stat.ManaPoint = 50;
            Stat.SkillPoint = 1;
            Stat.StrikingPower = 10;
            Stat.DefensivePower = 5;
            Stat.Critical = 5;
            for(int i = 0; i < SkillLevels.Length; i ++)
            {
                SkillLevels[i].AttackSkillLevel = 1;
                SkillLevels[i].DefendSkillLevel = 1;
                SkillLevels[i].BuffSkillLevel = 1;
            }
        }

        public PlayerData()
        { }
    }

    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    [Serializable]
    public class GameData
    {
        public string UserId;
        public string UserPassword;
        public PlayerData[] PlayerList = new PlayerData[3];

    }
}

