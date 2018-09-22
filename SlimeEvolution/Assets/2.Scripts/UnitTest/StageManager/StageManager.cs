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
            currentStage = Stage.TitleScene;
        }

        public void LoadStage(Stage stage)
        {
            StartCoroutine(ChangeStage(stage));
        }

        IEnumerator ChangeStage(Stage stage)
        {
            yield return stageState.Exit();

            if (currentStage != Stage.LoadingScene)
            {
                stageState = new LoadingStage(stage);
                currentStage = Stage.LoadingScene;

            }
            else
            {
                switch (stage)
                {
                    case Stage.TitleScene:
                        stageState = new TitleStage();
                        break;
                    case Stage.VillageScene:
                        stageState = new VillageStage();
                        break;
                }
                currentStage = stage;
            }
            stageState.Enter();

            yield return null;
        }

      






    }
}

