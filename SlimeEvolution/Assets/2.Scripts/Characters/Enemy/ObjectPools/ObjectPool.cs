<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    [SerializeField]
    GameObject enemyObject;

    const int numberOfObjects = 30;

    public List<GameObject> EnemyObjects = new List<GameObject>();
    public List<GameObject> PopedObjects;

	void RegistGameObject()
    {
        GameObject objectToRegist;
        for(int i = 0; i<numberOfObjects; i++)
        {
            objectToRegist = Instantiate(enemyObject, gameObject.transform);
            objectToRegist.name = enemyObject.name;
            EnemyObjects.Add(objectToRegist);
            EnemyObjects[i].SetActive(false);
        }
        
    }

   
}
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace SlimeEvolution.GameSystem
{
    public class ObjectPool//: Singleton<EnemyObjectPool>//: Singleton<EnemyObjectPool>
    {
        public Queue<GameObject> enemyObjects = new Queue<GameObject>();
        public List<GameObject> PopedObjects = new List<GameObject>();
        public GameObject ObjectToPush;
        public GameObject Parent;
        
       
        public ObjectPool(GameObject targetObject, GameObject parentObject)
        {
            ObjectToPush = targetObject;
            Parent = parentObject;
        }
        
        public void RegistObjects(GameObject toPush)
        {
            toPush.transform.SetParent(Parent.transform);
            enemyObjects.Enqueue(toPush);
            toPush.SetActive(false);
        }

        public GameObject PopFromPool(Transform spawnPosition)
        {
            try
            {
                GameObject toPopObject;
                toPopObject = enemyObjects.Dequeue();
                PopedObjects.Add(toPopObject);
                toPopObject.transform.position = spawnPosition.position;
                toPopObject.SetActive(true);

                return toPopObject;
            }
            catch(InvalidOperationException)
            {
                //catch부분에는 파일스트림으로 기록하거나 서버가 알수 있게 조치한다.
                Debug.Log("ObjectPool의 object가 부족합니다.");
                return null;
            }
        }

        public void PushToPool(GameObject toPushObject)
        {
            if(PopedObjects.Contains(toPushObject))
            {
                PopedObjects.Remove(toPushObject);
                enemyObjects.Enqueue(toPushObject);
                toPushObject.SetActive(false);
            }
            else
            {
                Debug.Log("현재 push된 오브젝트가 풀에 맞지 않습니다.");
            }
        }
    }
}
>>>>>>> 90ad0829ff8104e7225cedc39a1aa62f98352efb
