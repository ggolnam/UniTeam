using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.GameSystem
{
    public class EnemyObjectPool : Singleton<EnemyObjectPool>
    {
        public GameObject enemyObject;
        [HideInInspector]
        public List<GameObject> EnemyObjects = new List<GameObject>();

        public int NumberOfEnemyObjects;


        private void Awake()
        {
            NumberOfEnemyObjects = 30;
            RegistObjects();
        }

        private void Start()
        {
            
        }

        void RegistObjects()
        {
            GameObject objectToRegist;
            for(int i = 0; i<NumberOfEnemyObjects; i++)
            {
                //리소스로드 
                objectToRegist = Instantiate(enemyObject, gameObject.transform);
                objectToRegist.transform.position = this.gameObject.transform.position;
                EnemyObjects.Add(objectToRegist);
                EnemyObjects[i].name = enemyObject.name;
                
                EnemyObjects[i].SetActive(false);
            }
        }

        public GameObject PopFromPool(GameObject spawnArea)
        {
            GameObject objectToPop = null;
            for (int i = NumberOfEnemyObjects - 1; i >= 0; i--) 
            {
                if(EnemyObjects[i].activeInHierarchy == false)
                {
                    EnemyObjects[i].SetActive(true);
                    EnemyObjects[i].transform.position = spawnArea.transform.position;
                    objectToPop = EnemyObjects[i];
                    objectToPop.GetComponent<NavMeshAgent>();
                    break;
                }
                
                if(EnemyObjects[0].activeInHierarchy == true)
                {
                    Debug.Log("<color=red> Warning!:pool is empty.</color>");
                    break;
                }
            }
            return objectToPop;
        }

        public void PushToPool(GameObject objectToPush)
        {
            objectToPush.SetActive(false);
            objectToPush.transform.position = this.gameObject.transform.position;
            //EnemyObjects.Add
        }

        
    }
}