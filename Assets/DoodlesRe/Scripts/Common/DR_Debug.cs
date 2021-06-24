using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020-06-25 </para>
    /// <para> 내    용 : 디버그를 위한 클래스 </para>
    /// </summary>
    public class DR_Debug : MonoBehaviour
    {
        [Header("- 로그를 출력할 지 체크")]
        [SerializeField] private static bool isLog;

        private void Awake()
        {
            isLog = GetComponent<DR_ProgramManager>().programSetting.isLog;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-06-25 </para>
        /// <para> 내    용 : 일반 로그를 출력하는 기능 </para>
        /// </summary>
        public static void Func_Log(string _log)
        {
            if (isLog)
            {
                Debug.Log(_log);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-06-25 </para>
        /// <para> 내    용 : 붉은색 로그를 출력하는 기능 </para>
        /// </summary>
        public static void Func_RedLog(string _redLog, string _log = null)
        {
            if (isLog)
            {
                Debug.Log("<color=#FF0000><" + _redLog + "></color>\n" + _log);
            }
        }
    }
}