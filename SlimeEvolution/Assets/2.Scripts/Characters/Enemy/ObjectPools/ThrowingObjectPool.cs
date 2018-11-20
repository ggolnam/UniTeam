using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.EnemyLagacy
{
    public class ThrowingObjectPool : Singleton<ThrowingObjectPool>
    {
        public GameObject itemObject;
        [HideInInspector]
        public List<GameObject> itemObjects = new List<GameObject>();
        
        //public 선언을 해야 오브젝트가 생성되는구나 ......ㅗ
        
        public int NumberOfItemObject;

        private void Awake()
        {
            NumberOfItemObject = 10;
            RegistObjects();
            //이부분은 추후 상의하여 다른 함수로 빼든지 해야될듯
            //매니저라던지...
        }
        void RegistObjects()
        {
            GameObject objectToRegist;
            for (int i = 0; i < NumberOfItemObject; i++)
            {
                objectToRegist = Instantiate(itemObject, gameObject.transform);//리소스로드로 가져올것.. 일단 임시로 이렇게
                itemObjects.Add(objectToRegist);
                itemObjects[i].name = "ThrowingObject";
                itemObjects[i].SetActive(false);
            }
        }
        public GameObject PopFromPool(Transform enemyTransform)
        {
            GameObject objectToPop = null;
            for (int i = NumberOfItemObject-1; i >= 0; i--)
            {
                if (itemObjects[i].activeInHierarchy == false)
                {
                    itemObjects[i].SetActive(true);
                    itemObjects[i].transform.position = transform.position + enemyTransform.forward * 2;
                    objectToPop = itemObjects[i];
                    break;
                }
                if(itemObjects[0].activeInHierarchy == true)
                {
                    Debug.Log("<color=red> Warning!:</color> " + itemObjects[i].name + " pool is empty");
                    return null;
                }
            }
            return objectToPop;
        }

        public void PushToPool(GameObject objectToPush)
        {
            objectToPush.SetActive(false);
            itemObjects.Add(objectToPush);
            
        }
    }
}