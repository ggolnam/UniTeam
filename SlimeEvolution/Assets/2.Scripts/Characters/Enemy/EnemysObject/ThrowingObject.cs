using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public class ThrowingObject : MonoBehaviour
    {
        //있어야 할 멤버변수: 속도
        //직선으로 나아간다. (논타겟)
        //몬스터가 있는 곳에서 생성(?)된다. //생성부분은 enemyskill에서
        //몬스터가 보고있는 방향으로 날아간다.
        //일정거리(혹은 시간)동안 날아가거나 플레이어에 부딪히면 오브젝트풀로 반환된다.
        public Transform enemy;//임시
        public Transform player;//임시
        DungeonMediator dungeonMediator;
        Rigidbody objectRigidbody;
        
        Vector3 target;
        public Transform E;
        public Transform P;
        
        float speed;
        int damage;
        
        void Awake()
        {
            //오브젝트풀에서 생성되어있기 때문에 참고하는 enemy의 좌표나 로테이션값이 변하지 않은 상태로 있는거같다
            
            
        }
        
        void FixedUpdate()
        {
           
        }
        void Move()
        {
            
        }
        void pushToPool()
        {
            ThrowingObjectPool.Instance.PushToPool(this.gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            //이부분은.. 충돌스크립트를 따로 둬야하나
            //if(other.CompareTag("player"))
            //{
                //pushToPool();
            //}
        }
    }
}