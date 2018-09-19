using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int HP;
    protected int attackPoint;
    protected float movingSpeed;
    protected EnemyState state;
    public EnemySkill skill;
    
    //protected Rigidbody rigidbody;
    

    private void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
    }

}
