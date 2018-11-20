using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public abstract class DefendSkill 
    {
        protected int skillnum;
        public abstract void Use();
    }
}
