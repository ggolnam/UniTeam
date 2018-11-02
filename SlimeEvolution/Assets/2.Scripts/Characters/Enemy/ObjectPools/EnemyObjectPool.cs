using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.GameSystem
{
    public class EnemyObjectPool : Singleton<EnemyObjectPool>//: Singleton<EnemyObjectPool>
    {
        //오브젝트 풀 매니저 필요
        public Queue<GameObject> enemyObjects = new Queue<GameObject>();
        public List<GameObject> PopedObjects = new List<GameObject>();
        public GameObject enemyObject;
        public GameObject Parent;

        const int objectsAmount = 50;

       
        private void Start()
        {
            RegistObjects();
        }

        void RegistObjects()
        {
            GameObject toRegist;
            for(int i = 0; i < objectsAmount; i++ )
            {
                toRegist = Instantiate(enemyObject, gameObject.transform);
                enemyObjects.Enqueue(toRegist);
                toRegist.SetActive(false);
            }
        }

        public GameObject PopFromPool(Transform spawnPosition)
        {
            GameObject toPopObject;
            toPopObject = enemyObjects.Dequeue();
            PopedObjects.Add(toPopObject);
            toPopObject.transform.position = spawnPosition.position;
            toPopObject.SetActive(true);
            
            return toPopObject;
        }

        public void PushToPool(GameObject toPushObject)
        {
            //for(int i = 0; i < PopedObjects.Count; i++)
            //{
            if(PopedObjects.Contains(toPushObject))
            {
                PopedObjects.Remove(toPushObject);
                enemyObjects.Enqueue(toPushObject);
                toPushObject.SetActive(false);
                    //break;
            }
            else
            {
                Debug.Log("현재 push된 오브젝트가 풀에 맞지 않습니다.");
            }
           // }
        }

    }
}