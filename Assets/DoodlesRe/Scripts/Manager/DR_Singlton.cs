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
                    T[] _instanceArr = FindObjectsOfType<T>();

                    if (_instanceArr.Length == 0)
                    {
                        GameObject _go = new GameObject(typeof(T).ToString(), typeof(T));
                        _instance = _go.GetComponent<T>();
                    }

                    if (_instanceArr.Length > 0)
                    {
                        _instance = _instanceArr[0];
                    }

                    if (_instanceArr.Length > 1)
                    {
                        for (int i = 1; i < _instanceArr.Length; i++)
                        {
                            DR_Debug.Func_RedLog(_instanceArr[i].gameObject.name);
                            Destroy(_instanceArr[i].gameObject);
                        }
                    }
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                Func_Init();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.03 </para>
        /// <para> 내    용 : 싱글톤 초기화 하는 메서드 </para>
        /// </summary>
        protected abstract void Func_Init();
        
    }
}