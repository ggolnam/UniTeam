using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
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
                //itemObjects[i].transform.position = gameObject.transform.position;
                //objectToRegist.GetComponent<Rigidbody>();
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
                    itemObjects[i].transform.position = new Vector3(enemyTransform.position.x, 0.5f, enemyTransform.position.z);
                    itemObjects[i].transform.rotation = new Quaternion(0,0,0,0);
                    itemObjects[i].SetActive(true);
                    objectToPop = itemObjects[i];
                    Debug.Log("오브젝트나옴");
                    break;
                }
                if ((i == 0) && (itemObjects == null))
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
            objectToPush.transform.position = this.gameObject.transform.position;
            itemObjects.Add(objectToPush);
        }
    }
}