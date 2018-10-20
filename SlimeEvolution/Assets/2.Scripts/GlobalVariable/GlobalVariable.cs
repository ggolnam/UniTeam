using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SlimeEvolution.GlobalVariable
{
    public enum Stage
    {
        TitleScene = 0,
        LoadingScene,
        VillageScene,
        DungeonScene,
        
    
    }

    public enum Dungeon
    {
        BaseFeild = 0,
        Goblin,
        Skeleton,
        Human,

    }

    public enum EnemyStateType
    {
        Idle,
        Chase,
        Combat,
        Week,
        Death
    }
    public class GlobalVariable
    {



    }
}
