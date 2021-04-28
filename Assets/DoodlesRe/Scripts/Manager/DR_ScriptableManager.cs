using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-04-28 </para>
    /// <para> 내    용 : 스크립터블 오브젝트를 관리하는 매니져 클래스 </para>
    /// </summary>
    public class DR_ScriptableManager : DR_Singlton<DR_ScriptableManager>
    {
        [Header("- 사용하는 스크립터블 배열")]
        public DR_BaseScriptableObject[] scriptableOBJArr;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            for (int i = 0; i < scriptableOBJArr.Length; i++)
            {
                scriptableOBJArr[i].Func_Init();        // 스크립터블 오브젝트 준비
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-28 </para>
        /// <para> 내    용 : 스크립터블 오브젝트의 기능을 가져오기 위한 메서드 </para>
        /// </summary>
        public T Func_GetScriptable<T>() where T : DR_BaseScriptableObject
        {
            for (int i = 0; i < scriptableOBJArr.Length; i++)
            {
                if (scriptableOBJArr[i] as T)
                {
                    return (T)scriptableOBJArr[i];
                }
            }

            return null;
        }
    }
}