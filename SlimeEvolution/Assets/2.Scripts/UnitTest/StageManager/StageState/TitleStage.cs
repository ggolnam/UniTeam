using SlimeEvolution.GlobalVariable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    public class TitleStage : StageState
    {
        public override void Enter()
        {
            UnityEngine.Object.Instantiate(Resources.Load("UI/TitleUI") as GameObject);
            Debug.Log("Title Enter");
        }

        public override void Progress()
        {

        }

    }
}
