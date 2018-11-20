using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    public struct EnemyStruct
    {
        public int NumberOfEnemy;
        public ObjectPool EnemyObjectPool;
        public GameObject EnemyParent;
        public Transform[] SpawnAreas;
    }
    public class EnemyObjectManager : Singleton<EnemyObjectManager>
    {
        EnemyStruct[] enemyStruct = new EnemyStruct[3];

        //0:고블린  1:스켈레톤  2:나이트
        int[] enemyNumbers = new int[3] { 0, 0, 0 };
        
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

        int countOfEnemyNumber = 0;
        public List<GameObject> enemyObjects = new List<GameObject>();
        const int enemyObjectsAmount = 5;
        const int LimitOfSpawnedEnemy = 4;
        const int NumberOfAreas = 4;
        
        float countingTime = 0f;
        const float spawnningTime = 3f;
        
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
            if ((countingTime >= spawnningTime))
            {
                int areaNumber = Random.Range(0, 3);
                SpawnEnemy(GoblinSpawnAreas, goblinPool, areaNumber, 0);
                SpawnEnemy(SkeletonSpawnAreas, skeletonPool, areaNumber, 1);
                SpawnEnemy(KnightSpawnAreas, KnightPool, areaNumber, 2);
                countingTime = 0f;
            }
        }

        void RegistObjects(string prefabsPath, int objectsAmount, ObjectPool targetPool, 
            GameObject enemyObject)
        {
            for(int i = 0; i < objectsAmount; i++)
            {
                enemyObject = Instantiate(Resources.Load(prefabsPath) as GameObject);
                targetPool.RegistObjects(enemyObject);
            }
        }

        //스폰지역을 랜덤으로 돌아가며 몬스터 1기씩 소환한다.
        //현재 enemy count가 없음
        //반환형식 게임오브젝트로 지정할 것
        void SpawnEnemy(Transform[] spawnAreas, ObjectPool toSpawnObjectPool, int randomValue, int countIndex)
        {
            toSpawnObjectPool.PopFromPool(spawnAreas[randomValue]);
            enemyNumbers[countIndex]++;
        }
    }
}