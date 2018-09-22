using SlimeEvolution.GlobalVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeEvolution.GameSystem
{
    public class LoadingStage : StageState
    {
        Stage nextStage;

        public LoadingStage(Stage stage)
        {
            nextStage = stage;
        }
        public override void Enter()
        {
            GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("UI/LoadingUI") as GameObject);
            gameObject.transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;
            Debug.Log("Loding Enter");
            StageManager.Instance.LoadStage(nextStage);
        }

        public override void Progress()
        {
            
        }

        public override IEnumerator Exit()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(nextStage.ToString());
            op.allowSceneActivation = false;
            
            int frame = 0;
            float timer = 0.0f;
            while (frame < 100)
            {


                timer = Time.deltaTime;
                frame++;

                yield return null;
            }
            Debug.Log("Loading Exit");
            yield return Exit2();
            op.allowSceneActivation = true;
        }

        public  IEnumerator Exit2()
        {
            yield return new WaitForSeconds(2);
            ObjectPoolManager.Instance.testPool.ResetObject();
            Debug.Log("Loading Exit2");
            yield return null;

        }
    }
}
