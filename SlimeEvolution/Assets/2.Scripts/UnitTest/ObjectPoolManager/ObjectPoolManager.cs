using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public TestPool testPool;

    void Start()
    {
        GameObject singleton = new GameObject();
        singleton.AddComponent<TestPool>();
        singleton.name = typeof(TestPool).ToString();
        testPool = singleton.GetComponent<TestPool>();
        singleton.transform.parent = gameObject.transform;
    }





}
