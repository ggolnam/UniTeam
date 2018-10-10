using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public class ThrowingObjectPool : Singleton<ThrowingObjectPool>
    {
        GameObject itemObject;
        GameObject parentObject;
        List<GameObject> itemObjects = new List<GameObject>();

        private void Awake()
        {
            RegistObjects();
            //이부분은 추후 상의하여 다른 함수로 빼든지 해야될듯
            //매니저라던지...
        }
        void RegistObjects()
        {
            GameObject objectToRegist;
            for (int i = 0; i < itemObjects.Count; i++)
            {
                objectToRegist = Instantiate(itemObject);
                itemObjects.Add(objectToRegist);
                itemObjects[i].name = "ThrowingObject";
                itemObjects[i].SetActive(false);
                itemObjects[i].transform.SetParent(parentObject.transform);//SetParent를 해야하나?
            }
        }

        public GameObject PopFromPool(Transform enemyTransform)
        {
            GameObject objectToPop = new GameObject();
            for (int i = itemObjects.Count; i >= 0; i++)
            {
                if (itemObjects[i] != null)
                {
                    itemObjects[i].transform.position = enemyTransform.position;
                    itemObjects[i].transform.rotation = enemyTransform.rotation;
                    itemObjects[i].SetActive(true);
                    objectToPop = itemObjects[i];
                    break;
                }
                else if ((i == 0) && (itemObjects == null))
                {
                    Debug.Log("<color=red> Warning!: " + itemObjects[i].name + " pool is empty</color>");
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