using System.Collections.Generic;
using UnityEngine;

namespace ProjectB.UI.Minimap
{
    public class Radar : MonoBehaviour
    {
        public List<GameObject> Enemys = new List<GameObject>();
        //몬스터 사망 시 해당 주석부분에서 몬스터의 상태를 받아와야하기때문에 문제가 있을듯
        //애당초에 레이더로 하는거 자체가 맞는건가 ? 
        //private void OnEnable()
        //{
        //    Monster.NoticeToRader += RemoveFromList;
        //}
        
        void OnTriggerEnter(Collider other)
        {
            if (!(Enemys.Contains(other.gameObject)) && other.CompareTag("Monster"))
            {
                Enemys.Add(other.gameObject);
            }
        }

        void OnTriggerExit(Collider other) 
        {
            RemoveFromList(other.gameObject);
        }

        void RemoveFromList(GameObject monster)
        {
            if (Enemys.Contains(monster))
            {
                Enemys.Remove(monster);
            }
        }

        public void ClearEnemyList()
        {
            Enemys.Clear();
        }
    }
}
