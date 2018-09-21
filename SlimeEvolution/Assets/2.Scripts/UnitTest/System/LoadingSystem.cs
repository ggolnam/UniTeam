using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SlimeEvolution.GlobalVariable;

namespace SlimeEvolution.GameSystem
{
    public class LoadingSystem : MonoBehaviour
    {
        public void OnClickButton()
        {
            StageManager.Instance.ChangeStage(Stage.TestVillageScene);
        }

   

        

        
    }
}