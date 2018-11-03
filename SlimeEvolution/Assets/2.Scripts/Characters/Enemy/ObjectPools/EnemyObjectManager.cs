using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    

    public class EnemyObjectManager : Singleton<EnemyObjectManager>
    {
        public GameObject GoblinObject;//List사용
        public ObjectPool goblinPool;// "
        public ObjectPool skeletonPool;
        public ObjectPool KnightPool;
        public GameObject ParentObject;
        public List<GameObject> enemyObjects = new List<GameObject>();
        const int objectsAmount = 10;
        public int testnumber = 10;
       
        private void Start()
        {
            goblinPool = new ObjectPool(GoblinObject, ParentObject);
        

            for (int i = 0; i < objectsAmount; i++)
            {
                GoblinObject = Instantiate(Resources.Load("EnemyPrefabs/Goblin") as GameObject);
                goblinPool.RegistObjects(GoblinObject);
            }
        }
    }
}