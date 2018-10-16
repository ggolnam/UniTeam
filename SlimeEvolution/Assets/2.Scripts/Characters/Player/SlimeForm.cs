using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public class SlimeForm : FormState
    {


        public SlimeForm(Transform playerTransform,  Rigidbody rigidbody, Animator animator, ref CharacterStat characterStat) : base(playerTransform, rigidbody, animator)
        {
            speed = 5;
            attackrange = 3;
            characterStat.MaxHP += 5;
            characterStat.Damage += 2;
            characterStat.Speed += 5;
            characterStat.AttackRange += 3;
        }

        public override void ResetStat(ref CharacterStat characterStat)
        {
            characterStat.MaxHP -= 5;
            characterStat.Damage -= 2;
            characterStat.Speed -= 5;
            characterStat.AttackRange -= 3;
        }



        //public override IEnumerator Attack(Transform target)
        //{
        //    animator.SetBool("IsAttack", true);
        //    while (true)
        //    {
        //        if (!animator.GetBool("IsAttack"))
        //            break;

        //        movement.Set(target.position.x - playerTransform.position.x, 0, target.position.z - playerTransform.position.z);
        //        if (Vector3.Distance(playerTransform.position, target.position) > attackrange)
        //        {
        //            Move(movement, true);                   
        //        }
        //        else
        //        {
        //            LookAt(movement);
        //            animator.SetTrigger("Attack");
        //            Debug.Log("Attack");
        //            yield return new WaitForSeconds(2);
        //        }
        //        yield return null;
        //    }
        //}
    }
}
