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
        [Header("- Main")]
        [SerializeField] private DR_Main main;

        [Header("- 버튼 배열")]
        [SerializeField] private DR_ButtonArea[] buttonArr;

        private void Start()
        {
            buttonArr[0].Button_ClickArea();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-01 </para>
        /// <para> 내    용 : 모든 지역 버튼을 초기화하는 기능 </para>
        /// </summary>
        public void Func_InitAllButton()
        {
            for (int i = 0; i < buttonArr.Length; i++)
            {
                buttonArr[i].Func_Init();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-01 </para>
        /// <para> 내    용 : 맵을 설정하는 기능 </para>
        /// </summary>
        public void Func_MapSellect(MAINMAP_KIND _kind)
        {
            main.Func_SetMainMap(_kind);
        }
    }
}