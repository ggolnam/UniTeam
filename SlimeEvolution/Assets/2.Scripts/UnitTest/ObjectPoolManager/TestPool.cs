using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
    private List<Queue<GameObject>> testPoolList;

    public void CreateObject()
    {
        testPoolList = new List<Queue<GameObject>>();
        testPoolList.Add(new Queue<GameObject>());
        testPoolList.Add(new Queue<GameObject>());
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(Resources.Load("HitYellow1") as GameObject);
            GameObject temp2 = Instantiate(Resources.Load("HitRed3") as GameObject);
            temp.name = "HitYellow1";
            testPoolList[0].Enqueue(temp);
            temp.transform.parent = gameObject.transform;
            temp2.name = "HitRed3";
            testPoolList[1].Enqueue(temp2);
            temp2.transform.parent = gameObject.transform;

        }
        Debug.Log("Create");
    }

    public void ResetObject()
    {
        GameObject temp;
        for (int i = 0; i < testPoolList[0].Count; i ++)
        {
            temp = testPoolList[0].Dequeue();
            Destroy(temp);
        }
        for(int i = 0; i < testPoolList[1].Count; i ++)
        {
            temp = testPoolList[1].Dequeue();
            Destroy(temp);
        }
        Debug.Log("Delete");

    }

    public GameObject PopFromPool(int num)
    {
        return testPoolList[num].Dequeue();
    }

    public void PushToPool(GameObject particle, int num)
    {
        particle.SetActive(false);
        particle.transform.rotation = Quaternion.Euler(Vector3.zero);

        testPoolList[num].Enqueue(particle);
    }

}
