using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-04-28 </para>
    /// <para> 내    용 : 프로그램을 관리하는 매니져 클래스 </para>
    /// </summary>
    public class DR_ProgramManager : DR_Singlton<DR_ProgramManager>
    {
        [Header("- Volume")]
        public MD_Volume soundVolume;

        [Header("- Fade Value")]
        public float fadeTime = 1.5f;

        protected override void Func_Init()
        {
            base.Func_Init();
            DontDestroyOnLoad(gameObject);
        }

        public static void Func_Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();            
#endif
        }
    }
}