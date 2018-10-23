using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    public class EnemySpawnArea : MonoBehaviour
    {
        [SerializeField]
        GameObject goblinSpawnArea;
        [SerializeField]
        GameObject skeletonSpawnArea;
        [SerializeField]
        GameObject knightSpawnArea;
        
        //EnemyObjectPool enemyObjectPool;

        int aliveEnemyCount;
        int maxAliveEnemyCount;

        
        private void Start()
        {
            maxAliveEnemyCount = EnemyObjectPool.Instance.NumberOfEnemyObjects; //생성자
            EnemySpawn("");
        }

        void EnemySpawn(string enemyName)
        {
            GameObject toSpawnObject;
            for (int i = 0; i < EnemyObjectPool.Instance.NumberOfEnemyObjects * 0.2 ; i++)
            {
                toSpawnObject = EnemyObjectPool.Instance.PopFromPool(gameObject);
                toSpawnObject.transform.position = gameObject.transform.position;
            }
        }

        void EnemyCount()
        {

        }



    }
}