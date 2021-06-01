using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-05-31 </para>
    /// <para> 내    용 : 지역 버튼 클래스 </para>
    /// </summary>
    public class DR_ButtonArea : MonoBehaviour
    {
        [Header("- 맵 버튼 관리")]
        [SerializeField] private DR_ButtonAreaMenu buttonMenu;

        [Header("- 맵 종류")]
        [SerializeField] private MAINMAP_KIND mapKind;

        [Header("- 버튼 스프라이트 배열")]
        [SerializeField] private Sprite[] spriteArr;    // 0: 비활성화  1: 활성화

        [Header("- 버튼 이미지")]
        [SerializeField] private Image buttonImage;    // 0: 비활성화  1: 활성화

        private bool isClick;

        private void Reset()
        {
            buttonImage = GetComponent<Image>();
        }

        #region 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-31 </para>
        /// <para> 내    용 : 버튼을 초기화하는 기능 </para>
        /// </summary>
        public void Func_Init()
        {
            isClick = false;
            buttonImage.sprite = spriteArr[0];
        }

        #endregion

        #region 버튼 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-31 </para>
        /// <para> 내    용 : 버튼을 눌렀을 때 호출되는 버튼 메서드 </para>
        /// </summary>
        public void Button_ClickArea()
        {
            buttonMenu.Func_InitAllButton();        // 버튼들 모두 초기화
            buttonMenu.Func_MapSellect(mapKind);    // 맵 설정

            buttonImage.sprite = spriteArr[1];      // 버튼 이미지 활성화
        }

        #endregion
    }
}