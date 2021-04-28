using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.03 </para>
    /// <para> 내    용 : 싱글톤 스크립트 </para>
    /// </summary>
    public abstract class DR_Singlton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject _go = new GameObject(typeof(T).ToString(), typeof(T));
                        _instance = _go.GetComponent<T>();
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            Func_Init();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.03 </para>
        /// <para> 내    용 : 싱글톤 초기화 하는 메서드 </para>
        /// </summary>
        protected virtual void Func_Init()
        {
            _instance = this as T;
        }
    }
}