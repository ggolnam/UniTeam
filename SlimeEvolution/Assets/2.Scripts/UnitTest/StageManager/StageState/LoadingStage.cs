using SlimeEvolution.GlobalVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeEvolution.GameSystem
{
    public class LoadingStage : StageState
    {
        string nextSceneName;
        AsyncOperation op;
        public LoadingStage(Stage stage)
        {
            nextSceneName = stage.ToString();     
        }

        public override void Enter()
        {

        }

        public override void Progress()
        {

        }

        public override void Exit()
        {
            MonoBehaviour mono = new MonoBehaviour();
            mono.StartCoroutine(LoadScene());
        }

        public IEnumerator LoadScene()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(nextSceneName);
            op.allowSceneActivation = false;
            int frame = 0;
            float timer = 0.0f;
            while (frame < 100)
            {
                

                timer = Time.deltaTime;
                frame++;

                yield return null;
            }
            Debug.Log("finish");

            op.allowSceneActivation = true;
            yield return null;
        }

    }
}
