using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SlimeEvolution.GameSystem;

namespace TestLee
{
    /// <summary>
    /// 게임 컨트롤러가 해야 할 일
    /// 1. 아이템 떨구기
    /// 2. deathcounting
    /// 3. 
    /// </summary>
    public class TestMediator
    {
     
        Vector3 goblinsPosition;

        
        
        public Vector3 GetGoblinsPosition()
        {
            goblinsPosition = new Vector3(1, 2, 3);
            
            return goblinsPosition;
        }
        
    }
}

