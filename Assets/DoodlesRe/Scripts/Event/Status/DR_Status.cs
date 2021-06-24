using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-15 </para>
    /// <para> 내    용 : 스테이터스창을 관리하는 클래스 </para>
    /// </summary>
    public class DR_Status : DR_Info
    {
        // ****************************** 왼쪽 페이지 ***************************
        [Header("- 캐릭터 이미지")]
        [Header("- Left Page"), Space(20)]
        [SerializeField] private Image image_Character;

        [Header("- 캐릭터 이름 텍스트")]
        [SerializeField] private Text text_Name;

        [Header("- 상태 텍스트")]
        [SerializeField] private Text text_State;

        // ****************************** 오른쪽 페이지 ***************************
        [Header("- 레벨")]
        [Header("- Right Page"), Space(20)]
        [SerializeField] private Text text_Level;

        [Header("- 경험치 바")]
        [SerializeField] private Slider slider_Exe;

        [Header("- 메인 스텟 텍스트 배열")]
        [SerializeField] private Text[] text_MainStateArr;

        [Header("- 디테일 스텟 텍스트 배열")]
        [SerializeField] private Text[] text_DetailStateArr;

        [Header("- 패시브 텍스트")]
        [SerializeField] private Text text_Passive;

        public override void Func_SetEnable()
        {
            Func_SetMainStatus();           // 메인 스테이터스 설정
            gameObject.SetActive(true);
        }

        public override void Func_Close()
        {
            gameObject.SetActive(false);
        }

        #region 기능들

        private void Func_SetMainStatus()
        {
            DR_DefineStatus _status = DR_PlayerManager.Instance.status;
            text_Level.text = _status.level.ToString();     // 레벨
            //slider_Exe.value =                            // 경험치

            text_MainStateArr[0].text = _status.power.ToString();       // 힘
            text_MainStateArr[1].text = _status.dex.ToString();         // 민첩
            text_MainStateArr[2].text = _status.health.ToString();      // 생명력
            text_MainStateArr[3].text = _status.patience.ToString();    // 인내
        }

        #endregion

    }
}