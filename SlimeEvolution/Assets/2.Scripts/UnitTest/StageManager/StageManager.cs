using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SlimeEvolution.GameSystem
{
    public class StageManager : Singleton<StageManager>
    {
        private StageState stageState; 
        private void Start()
        {
            stageState = new TitleStage();
            stageState.Enter();
        }

        public void ChangeStage()
        {

        }




    }
}

