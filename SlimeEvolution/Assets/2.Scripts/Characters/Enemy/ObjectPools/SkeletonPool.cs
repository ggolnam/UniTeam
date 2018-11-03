using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    public class SkeletonPool : ObjectPool
    {
        public SkeletonPool(GameObject objectToPush, GameObject parentObject) : base(objectToPush, parentObject)
        {
            ObjectToPush = objectToPush;
            Parent = parentObject;
        }
    }
}