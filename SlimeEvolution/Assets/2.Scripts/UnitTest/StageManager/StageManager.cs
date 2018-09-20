using SlimeEvolution.GlobalVariable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SlimeEvolution.GameSystem
{
    public class StageManager : Singleton<StageManager>
    {
        private StageState stageState;
        private Stage currentStage;
        private void Start()
        {
            stageState = new TitleStage();
            stageState.Enter();
            currentStage = Stage.TestTitleScene;
        }

        public void ChangeStage(Stage stage)
        {
            stageState.Exit();
            if(currentStage != Stage.TestLoadingScene)
            {
                stageState = new LoadingStage(stage);
                currentStage = Stage.TestLoadingScene;
                
            }
            else
            {
                switch(stage)
                {
                    case Stage.TestTitleScene:
                        stageState = new TitleStage();
                        break;
                    case Stage.TestVillageScene:
                        stageState = new VillageStage();
                        break;
                }
                currentStage = stage;
            }
            stageState.Enter();
        }






    }
}

