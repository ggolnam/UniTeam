using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public class TestMonster : MonoBehaviour
    {
        public Enemy goblin;

        void Start()
        {
            goblin = new Goblin(new RecoverHP(10), new Defend());
        }

        // Update is called once per frame
        void Update()
        {
            goblin.skill.UseSkill();
        }
    }
}
