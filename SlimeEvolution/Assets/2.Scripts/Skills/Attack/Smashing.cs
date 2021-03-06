﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeEvolution.GameSystem;

namespace SlimeEvolution.Character.Player
{
    public class Smashing : AttackSkill
    {


        public Smashing(Transform playerTransform, PlayerForm playerForm) : base (playerTransform, playerForm)
        { }

        public override IEnumerator Use(Transform target)
        {
            GameObject temp = ObjectPoolManager.Instance.testPool.PopFromPool(1);
            temp.transform.position = target.position;
            temp.SetActive(true);
            yield return null;
        }
    }
}
