using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    public class ManagerMaker : MonoBehaviour {

        void Awake()
        {
            //DataManager.Instance.MakeSingleTon();
            StageManager.Instance.MakeSingleTon();
            ObjectPoolManager.Instance.MakeSingleTon();
        }

    }
}
