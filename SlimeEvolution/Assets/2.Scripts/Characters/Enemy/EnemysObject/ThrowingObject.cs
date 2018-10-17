using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.Character.Enemy
{
    public class ThrowingObject : MonoBehaviour
    {
        Rigidbody objectRigidbody;
        
        Vector3 target;
        public Transform E;
        public Transform P;

        private void Start()
        {
            objectRigidbody = gameObject.GetComponent<Rigidbody>();
        }
        private void Update()
        {
            Invoke("pushToPool", 3);
        }

        void FixedUpdate()
        {
           
        }
        void Move()
        {
            
        }
        void pushToPool()
        {
            objectRigidbody.velocity = Vector3.zero;
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