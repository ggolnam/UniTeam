using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : Singleton<Timer>
{
    public bool Count(float TimeLimit)
    {
        bool isCompletedCount = false;
        float countingTime = 0f;
        while(!isCompletedCount)
        {
            countingTime = Time.deltaTime;
            if(countingTime <= TimeLimit)
            {
                isCompletedCount = true;
            }
        }
        return isCompletedCount;
    }
}
