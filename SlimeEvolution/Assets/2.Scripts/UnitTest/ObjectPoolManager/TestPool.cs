using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
    private Queue<GameObject> testPool;

    void Start()
    {
        testPool = new Queue<GameObject>();
    }

    public void CreateObject()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject cube = Instantiate(Resources.Load("Cube") as GameObject);
            cube.name = "Cube";
            testPool.Enqueue(cube);
            cube.transform.parent = gameObject.transform;
            
        }
        Debug.Log("Create");
    }

    public void ResetObject()
    {
        GameObject temp;
        int Count = testPool.Count;
        for (int i = 0; i < Count; i ++)
        {
            temp = testPool.Dequeue();
            Destroy(temp);
        }
        Debug.Log("Delete");

    }

    public GameObject PopFromPool()
    {
        return testPool.Dequeue();
    }

    public void PushToPool(GameObject cube)
    {
        cube.SetActive(false);
        cube.transform.rotation = Quaternion.Euler(Vector3.zero);

        testPool.Enqueue(cube);
    }

}
