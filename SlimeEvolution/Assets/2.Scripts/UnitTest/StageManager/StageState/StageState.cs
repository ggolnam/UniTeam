using SlimeEvolution.GlobalVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeEvolution.GameSystem
{
    public abstract class StageState
    {
        abstract public void Enter();
        abstract public void Progress();
        virtual public IEnumerator Exit()
        {
            SceneManager.LoadScene("LoadingScene");
            ObjectPoolManager.Instance.testPool.ResetObject();
            Debug.Log("Title Exit");
            yield return null;
            
        }

    }
}
