using System.Collections;
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
