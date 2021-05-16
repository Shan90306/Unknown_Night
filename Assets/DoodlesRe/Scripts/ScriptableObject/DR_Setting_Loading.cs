using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-04-29 </para>
    /// <para> 내    용 : 로딩 씬에 필요한 데이터를 가지고 있는 스크립터블 오브젝트 클래스 </para>
    /// </summary>
    [CreateAssetMenu(fileName = "LoadingSetting", menuName = "DoodlesRe/LoadingSetting", order = int.MinValue)]
    public class DR_Setting_Loading : DR_BaseScriptableObject
    {
        [Header("- Tip 배열")]
        public string[] tipArr;

        [Header("- 로딩 텍스트 시간")]
        public float text_LoadingTime;

        [Header("- 텍스트를 읽게 기다리는 시간")]
        public float waitReadTextTime;
    }
}