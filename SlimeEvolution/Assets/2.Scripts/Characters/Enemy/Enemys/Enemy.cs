using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int hitPoint;
    protected int attackPoint;
    protected float movingSpeed;
    protected EnemyState state;
    protected SpecialSkillIMP skill;
    protected AttackIMP attack1;
    protected AttackIMP attack2;
    protected MovementIMP movement;
    protected Rigidbody rigidbody;
    

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

}
