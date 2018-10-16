using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public class HumanForm : FormState
    {
        public HumanForm(Transform playerTransform, Rigidbody rigidbody, Animator animator, ref CharacterStat characterStat) : base(playerTransform, rigidbody, animator)
        {
            speed = 20;
            attackrange = 2;
            characterStat.MaxHP += 4;
            characterStat.Damage += 5;
            characterStat.Speed += 20;
            characterStat.AttackRange += 3;
        }

        public override void ResetStat(ref CharacterStat characterStat)
        {
            characterStat.MaxHP -= 4;
            characterStat.Damage -= 5;
            characterStat.Speed -= 20;
            characterStat.AttackRange -= 3;
        }
    }
}
