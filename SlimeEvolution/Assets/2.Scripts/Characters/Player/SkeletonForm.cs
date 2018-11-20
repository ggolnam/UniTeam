using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public class SkeletonForm : FormState
    {
        public SkeletonForm(Transform playerTransform, Rigidbody rigidbody, Animator animator, ref CharacterStat characterStat) : base(playerTransform, rigidbody, animator)
        {
            speed = 15;
            attackrange = 2;
            characterStat.MaxHP += 4;
            characterStat.Damage += 4;
            characterStat.Speed += 15;
            characterStat.AttackRange += 2;
            characterStat.AttackSpeed += 3;
        }

        public override void ResetStat(ref CharacterStat characterStat)
        {
            characterStat.MaxHP -= 4;
            characterStat.Damage -= 4;
            characterStat.Speed -= 15;
            characterStat.AttackRange -= 2;
            characterStat.AttackSpeed -= 3;
        }
    }
}
