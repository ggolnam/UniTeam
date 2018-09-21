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
        virtual public void Exit()
        {
            SceneManager.LoadScene("TestLoadingScene");
        }

    }
}
