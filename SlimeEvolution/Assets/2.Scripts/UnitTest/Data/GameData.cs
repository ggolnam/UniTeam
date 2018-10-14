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
        public StatData statData;
        public PlayerData(int slotNumber)
        {
            Level = 1;
            SlotNumber = slotNumber;
            statData.HealthPoint = 100;
            statData.ManaPoint = 50;
            statData.SkillPoint = 1;
            statData.StrikingPower = 10;
            statData.DefensivePower = 5;
            statData.Critical = 5;
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

