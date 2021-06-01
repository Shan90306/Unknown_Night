using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-01 </para>
    /// <para> 내    용 : Main 씬에 필요한 데이터를 가지고 있는 스크립터블 오브젝트 클래스 </para>
    /// </summary>
    [CreateAssetMenu(fileName = "MainSetting", menuName = "DoodlesRe/MainSetting", order = int.MinValue)]
    public class DR_Setting_Main : DR_BaseScriptableObject
    {
        [Header("- Main Map 스프라이트 배열")]
        public Sprite[] mainMapArr;
    }
}