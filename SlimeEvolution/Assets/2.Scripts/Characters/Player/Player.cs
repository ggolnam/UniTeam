﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Player
{
    public enum PlayerForm
    {
        Slime,
        Goblin,
        Skeleton,
        Human,
    }


    public class Player : Character 
    {
        [SerializeField]
        GameObject[] formList;
        [SerializeField]
        float checkradius;
        [SerializeField]
        LayerMask checkLayer;


        Skill playerSkill;
        Rigidbody rigidbody;
        Vector3 movement;
        PlayerForm currentForm;
        FormState formState;
        Transform target;
        AttackAreaActivator attackAreaActivator;
        bool isDeath;
        bool isUsingSkill;

        void Start()
        {          
            rigidbody = GetComponent<Rigidbody>();
            currentForm = PlayerForm.Slime;
            formState  = new SlimeForm(transform ,rigidbody, formList[(int)PlayerForm.Slime].GetComponent<Animator>(), ref characterStat);
            attackAreaActivator = formList[(int)PlayerForm.Slime].GetComponent<AttackAreaActivator>();
            playerSkill = new Skill(currentForm, transform);
            
        }


        void FixedUpdate()
        {
            if (!isDeath)
            {
                float h = Input.GetAxisRaw("Horizontal"); //좌우 입력. -1이 왼쪽. 1이 오른쪽
                float v = Input.GetAxisRaw("Vertical"); //상하 입력. -1이 아래, 1이 위  
                if (!(h == 0 && v == 0))
                {
                    target = null;
                    movement.Set(h, 0, v);
                    formState.Move(movement);
                    attackAreaActivator.EndAttackHit();
                }
                else 
                {
                    formState.Stop();
                }
            }
        }
        
        IEnumerator AttackCoroutine()
        {
            while (true)
            {
                if (target == null && !isUsingSkill)
                    break;
                movement.Set(target.position.x - transform.position.x, 0, target.position.z - transform.position.z);
                if (Vector3.Distance(transform.position, target.position) > characterStat.AttackRange)
                {
                    formState.Move(movement);
                }
                else
                {
                    formState.LookAt(movement);
                    formState.Attack();
                    break;
                }
                yield return null;
            }
            yield return null;
        }



        public void OnClickedChangeButton(int form)
        {
            switch(form)
            {
                case 0:
                    ChangeFormState(PlayerForm.Slime);
                    break;
                case 1:
                    ChangeFormState(PlayerForm.Skeleton);
                    break;
                case 2:
                    ChangeFormState(PlayerForm.Goblin);
                    break;
                case 3:
                    ChangeFormState(PlayerForm.Human); 
                    break;
            }
        }

        public void OnClickAttackSkillButton()
        {

            FindTarget(checkradius);
            if (target != null)
            {
                isUsingSkill = true;

                formState.LookAt(movement);
                playerSkill.UseAttackSkill(target);
            }
        }

        public void OnClickDefensSkillButton()
        {
            isUsingSkill = true;
        }

        public void OnClickBuffSkillButton()
        {
            isUsingSkill = true;
        }

        public void OnClickedAttackButton()
        {
            if (isUsingSkill)
                return; 
            FindTarget(checkradius);
            if (target != null)
            {
                StartCoroutine(AttackCoroutine());
            }
        }

        void ChangeFormState(PlayerForm form)
        {
            if (currentForm != form)
            {
                formState.ResetStat(ref characterStat);
                switch(form)
                {
                    case PlayerForm.Slime:
                        formState = new SlimeForm(transform ,rigidbody , formList[(int)form].GetComponent<Animator>(), ref characterStat);
                        break;
                    case PlayerForm.Goblin:
                        formState = new GoblinForm(transform, rigidbody, formList[(int)form].GetComponent<Animator>(), ref characterStat);
                        break;
                    case PlayerForm.Skeleton:
                        formState = new SkeletonForm(transform, rigidbody, formList[(int)form].GetComponent<Animator>(), ref characterStat);
                        break;
                    case PlayerForm.Human:
                        formState = new HumanForm(transform, rigidbody, formList[(int)form].GetComponent<Animator>(), ref characterStat);
                        break;
                }
                formList[(int)currentForm].SetActive(false);
                formList[(int)form].SetActive(true);
                currentForm = form;
                attackAreaActivator = formList[(int)form].GetComponent<AttackAreaActivator>();
            }
        }


        void FindTarget(float radius)
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, radius, checkLayer);
            if (targets.Length != 0)
            {
                float min = 10;
                float distance;
                for (int i = 0; i < targets.Length; i++)
                {
                    distance = Vector3.Distance(transform.position, targets[i].transform.position);
                    Debug.Log(distance);
                    if (min > distance)
                    {
                        min = distance;
                        target = targets[i].transform;
                    }

                }
            } 
        }

        public void HitPlayer(int damage)
        {
            characterStat.CurrentHP -= damage;
            if(characterStat.CurrentHP <= 0)
            {
                isDeath = true;
                formState.Die();              
            }
            else
                formState.Hit();
        }

        
    }
}

