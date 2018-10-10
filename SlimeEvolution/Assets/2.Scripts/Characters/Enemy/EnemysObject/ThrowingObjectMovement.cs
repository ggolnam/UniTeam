using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public class ThrowingObjectMovement : MonoBehaviour
    {
        //있어야 할 멤버변수: 속도
        //직선으로 나아간다. (논타겟)
        //몬스터가 있는 곳에서 생성(?)된다. //생성부분은 enemyskill에서
        //몬스터가 보고있는 방향으로 날아간다.
        //일정거리(혹은 시간)동안 날아가거나 플레이어에 부딪히면 오브젝트풀로 반환된다.
        Rigidbody objectRigidbody;
        float speed;
        int damage;
        

        void Awake()
        {
            damage = 5;
            objectRigidbody = GetComponent<Rigidbody>();
        }
        void FixedUpdate()
        {
            Move();
        }
        void Move()
        {
            
            //앞쪽으로 전진
            //있어야 할 정보: EnemyObject의 rotation정보
        }
        void pushToPool()
        {
            ThrowingObjectPool.Instance.PushToPool(this.gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            //이부분은.. 충돌스크립트를 따로 둬야하나
            if(other.CompareTag("player"))
            {
                pushToPool();
            }
        }

    }
}