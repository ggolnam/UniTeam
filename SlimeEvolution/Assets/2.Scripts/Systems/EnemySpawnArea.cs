using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    //더이상 필요없는 스크립트
    /// <summary>
    /// EnemySpawnArea, EnemyObjectPool을 어디서 관리할건지 설계를 해야함
    /// </summary>
    public class EnemySpawnArea : MonoBehaviour
    {
        protected float countingTime = 0;
        protected const float spawnningTime = 5f;
        //게임 컨트롤러에 들어갈 내용

        protected const int numberOfSpawnArea = 10;
        protected const int limitOfSpawnedEnemy = 2;
        protected int countingEnemy = 0;
        public Transform[] SpawnPositions = new Transform[numberOfSpawnArea];

        void Update()
        {
            if (countingEnemy < limitOfSpawnedEnemy)
            {
<<<<<<< HEAD
                toSpawnObject = EnemyObjectPool.Instance.PopFromPool(gameObject.transform.position);
                toSpawnObject.transform.position = gameObject.transform.position;
=======
                countingTime += Time.deltaTime;
                if (countingTime >= spawnningTime)
                {
                    Spawn();
                    countingTime = 0f;
                }
>>>>>>> 90ad0829ff8104e7225cedc39a1aa62f98352efb
            }
        }


        protected void Spawn()
        {
            GameObject testSpawn;
            //testSpawn = ObjectPool.Instance.PopFromPool(gameObject.transform);
            //testSpawn.transform.position = gameObject.transform.position;
            countingEnemy++;
            
        }
    }
}