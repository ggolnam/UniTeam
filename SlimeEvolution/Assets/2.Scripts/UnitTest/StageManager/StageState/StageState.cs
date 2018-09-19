using SlimeEvolution.GlobalVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    public abstract class StageState
    {
        abstract public void Enter();
        abstract public void Progress();
        public void Exit(Stage stage)
        {

        }
    }
}
