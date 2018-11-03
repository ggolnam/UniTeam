using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    public class KnightPool : ObjectPool
    {
        public KnightPool(GameObject objectToPush, GameObject parentObject) : base(objectToPush, parentObject)
        {
            ObjectToPush = objectToPush;
            Parent = parentObject;
        }
    }
}