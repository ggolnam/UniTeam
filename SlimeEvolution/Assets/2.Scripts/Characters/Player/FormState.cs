using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public abstract class FormState
    {
        protected Rigidbody rigidbody;
        protected float speed;
        protected Animator animator;
        protected float attackrange;
        protected Vector3 movement;
        protected Transform playerTransform;

        public FormState(Transform playerTransform, Rigidbody rigidbody, Animator animator)
        {
            this.rigidbody = rigidbody;
            this.animator = animator;
            this.playerTransform = playerTransform;
        }

        public void Move(Vector3 movement)
        {
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsMove", true);
            movement = movement.normalized;
            LookAt(movement);
            movement = movement * speed * Time.deltaTime;
            rigidbody.MovePosition(playerTransform.position + movement);
                  
        }

        public void LookAt(Vector3 movement)
        {
            Quaternion dir = Quaternion.LookRotation(movement);
            playerTransform.rotation = dir;
        }

        public void Stop()
        {
            animator.SetBool("IsMove", false);
        }

        public void Attack(Transform target)
        {
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsMove", false);
        }

        public abstract void ResetStat(ref CharacterStat characterStat);
    }
}
