using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    public class EnemyObjectManager : Singleton<EnemyObjectManager>
    {
        [HideInInspector]
        public GameObject GoblinObject;//List사용
        [HideInInspector]
        public GameObject SkeletonObject;
        [HideInInspector]
        public GameObject KnightObject;

        public ObjectPool goblinPool;
        public ObjectPool skeletonPool;
        public ObjectPool KnightPool;

        //배열로 설정해서 인덱스로 관리 고려하기
        public GameObject GoblinParent;
        public GameObject SkeletonParent;
        public GameObject KnightParent;

        public Transform[] GoblinSpawnAreas = new Transform[NumberOfAreas];
        public Transform[] SkeletonSpawnAreas = new Transform[NumberOfAreas];
        public Transform[] KnightSpawnAreas = new Transform[NumberOfAreas];


        public List<GameObject> enemyObjects = new List<GameObject>();
        const int enemyObjectsAmount = 5;
        const int NumberOfAreas = 4;

        float countingTime = 0f;
        const float spawnningTime = 3f;

        int[] enemyCounts = new int[3]{ 0, 0, 0 };
        //0: 고블린 1: 스켈레톤 2: 나이트

        //스폰 리미트 걸어놓기
       
        void Start()
        {
            goblinPool = new ObjectPool(GoblinObject, GoblinParent);
            skeletonPool = new ObjectPool(SkeletonObject, SkeletonParent);
            KnightPool = new ObjectPool(KnightObject, KnightParent);
            
            RegistObjects("EnemyPrefabs/Goblin", enemyObjectsAmount, goblinPool, GoblinObject);
            RegistObjects("EnemyPrefabs/Skeleton", enemyObjectsAmount, skeletonPool, SkeletonObject);
            RegistObjects("EnemyPrefabs/Knight", enemyObjectsAmount, KnightPool, KnightObject);

            
        }

        void Update()
        {
            //timer 모듈화 필요
            countingTime += Time.deltaTime;
            if (countingTime >= spawnningTime)
            {
                //Random함수를 따로 뺄순없나
                SpawnEnemy(GoblinSpawnAreas, goblinPool, Random.Range(0, 3),0);
                SpawnEnemy(SkeletonSpawnAreas, skeletonPool, Random.Range(0, 3), 1);
                SpawnEnemy(KnightSpawnAreas, KnightPool, Random.Range(0, 3), 2);
                countingTime = 0f;
            }
        }

        void RegistObjects(string prifabPath, int objectsAmount, ObjectPool targetPool, 
            GameObject enemyObject)
        {
            for(int i = 0; i < objectsAmount; i++)
            {
                enemyObject = Instantiate(Resources.Load(prifabPath) as GameObject);
                targetPool.RegistObjects(enemyObject);
            }
        }

        //스폰지역을 랜덤으로 돌아가며 몬스터 1기씩 소환한다.
        //현재 enemy count가 없음
        //반환형식 게임오브젝트로 지정할 것
        void SpawnEnemy(Transform[] spawnAreas, ObjectPool toSpawnObjectPool, int randomValue, int countIndex)
        {
            if (enemyCounts[countIndex] < enemyObjectsAmount)
            {
                toSpawnObjectPool.PopFromPool(spawnAreas[randomValue]);
                enemyCounts[countIndex]++;
                
            }
            else
            {
                Debug.Log("해당 몬스터의 개채 수가 최대치에 도달했습니다.");
            }
        }
    }
}