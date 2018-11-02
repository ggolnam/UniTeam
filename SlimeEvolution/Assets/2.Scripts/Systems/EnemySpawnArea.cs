using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    /// <summary>
    /// EnemySpawnArea, EnemyObjectPool을 어디서 관리할건지 설계를 해야함
    /// </summary>
    public class EnemySpawnArea : MonoBehaviour
    {
        float countingTime = 0;
        const float spawnningTime = 5f;
        //게임 컨트롤러에 들어갈 내용
        
        const int numberOfSpawnArea = 10;
        const int limitOfSpawnedEnemy = 2;
        int countingEnemy = 0;
        public Transform[] SpawnPositions = new Transform[numberOfSpawnArea];

        void Update()
        {
            if (countingEnemy < limitOfSpawnedEnemy)
            {
                countingTime += Time.deltaTime;
                if (countingTime >= spawnningTime)
                {
                    Spawn();
                    countingTime = 0f;
                }
            }
        }

        
        void Spawn()
        {
            GameObject testSpawn;
            testSpawn = EnemyObjectPool.Instance.PopFromPool(gameObject.transform);
            testSpawn.transform.position = gameObject.transform.position;
            countingEnemy++;
        }

        
    }
}