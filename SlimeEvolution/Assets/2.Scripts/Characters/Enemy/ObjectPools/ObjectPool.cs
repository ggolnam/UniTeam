using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    GameObject itemObject;
    GameObject parentObject;
    List<GameObject> itemObjects = new List<GameObject>();

    private void Awake()
    {
        RegistObjects();
        //이부분은 추후 상의하여 다른 함수로 빼든지 해야될듯
        //매너저라던지...
    }
    void RegistObjects()
    {
        GameObject objectToPush;
        for(int i = 0; i < itemObjects.Count; i++)
        {
            objectToPush = Instantiate(itemObject);
            itemObjects.Add(objectToPush);
            itemObjects[i].name = "ThrowingObject" + i.ToString();
            itemObjects[i].SetActive(false);
            itemObjects[i].transform.parent = parentObject.transform;
        }
    }

    GameObject PopFromPool(/*이부분에는 검색키 파라미터가 오면 될듯싶은데 필요할라나....*/)
    {
        GameObject objectToPop = new GameObject();
        for (int i = itemObjects.Count; i >= 0; i++) 
        {
            if(itemObjects[i] != null)
            {
                objectToPop = itemObjects[i];
                break;
            }
            else if((i==0) && (itemObjects[i] ==null))
            {
                Debug.Log("<color=red> Warning!: This pool is empty</color>");
                return null;
            }
        }
        return objectToPop;
    }

    void PushToPool(GameObject objectToPush)
    {
        //stack구조로 들어가게 만들 것
    }
}
