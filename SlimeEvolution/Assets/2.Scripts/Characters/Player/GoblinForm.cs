using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public class GoblinForm : FormState
    {
        public GoblinForm(Transform playerTransform, Rigidbody rigidbody, Animator animator, ref CharacterStat characterStat) : base(playerTransform, rigidbody, animator)
        {
            speed = 10;
            attackrange = 2;
            characterStat.MaxHP += 2;
            characterStat.Damage += 3;
            characterStat.Speed += 10;
            characterStat.AttackRange += 3;
        }

        public override void ResetStat(ref CharacterStat characterStat)
        {
            characterStat.MaxHP -= 2;
            characterStat.Damage -= 3;
            characterStat.Speed -= 10;
            characterStat.AttackRange -= 3;
        }
    }
}
