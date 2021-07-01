using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-07-01 </para>
    /// <para> 내    용 : 오브젝트 풀의 클래스 </para>
    /// </summary>
    public class DR_ObjectPool: MonoBehaviour 
    {
        [Header("- 초기 오브젝트 개수")]
        [SerializeField] private int initCount;

        [Header("- 생성 할 오브젝트")]
        [SerializeField] private GameObject poolObject;

        [Header("- 오브젝트를 저장할 위치")]
        [SerializeField] private Transform poolParent;

        private Queue<GameObject> poolQueue = new Queue<GameObject>();        // 풀링 큐

        private void Start()
        {
            for (int i = 0; i < initCount; i++)
            {
                Func_CreatObejct();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-01 </para>
        /// <para> 내    용 : 풀에 넣을 오브젝트 생성 </para>
        /// </summary>
        private void Func_CreatObejct()
        {
            GameObject _obj = Instantiate(poolObject, poolParent);
            _obj.SetActive(false);
            poolQueue.Enqueue(_obj);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-01 </para>
        /// <para> 내    용 : 풀에 있는 오브젝트 하나 출력 </para>
        /// </summary>
        public GameObject Func_GetObject(Transform _parent)
        {
            GameObject _obj;
            if (poolQueue.Count == 0)
            {
                Func_CreatObejct();
            }

            _obj = poolQueue.Dequeue();
            _obj.transform.SetParent(_parent);
            _obj.SetActive(true);

            return _obj;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-01 </para>
        /// <para> 내    용 : 오브젝트를 풀에 저장 </para>
        /// </summary>
        public void Func_ReturnOBJ(GameObject _obj)
        {
            _obj.transform.SetParent(poolParent);
            _obj.SetActive(false);
            poolQueue.Enqueue(_obj);
        }
    }
}