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
        [Header("- 캐릭터 이미지")]
        [Header("- Left Page"), Space(20)]
        [SerializeField] private Image image_Character;

        [Header("- 캐릭터 이름 텍스트")]
        [SerializeField] private Text text_Name;

        [Header("- 상태 텍스트")]
        [SerializeField] private Text text_State;

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
            gameObject.SetActive(true);
        }

        public override void Func_Close()
        {
            gameObject.SetActive(false);
        }

    }
}