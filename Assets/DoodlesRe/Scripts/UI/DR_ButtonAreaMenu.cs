using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-05-31 </para>
    /// <para> 내    용 : 지역 버튼 메뉴 클래스 </para>
    /// </summary>
    public class DR_ButtonAreaMenu : MonoBehaviour
    {
        [Header("- 버튼 배열")]
        [SerializeField] private DR_ButtonArea[] buttonArr;

        public void Func_AllDisable()
        {
            for (int i = 0; i < buttonArr.Length; i++)
            {
                buttonArr[i].Func_Init();
            }
        }
    }
}