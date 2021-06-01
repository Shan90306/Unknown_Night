using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-05-18 </para>
    /// <para> 내    용 : Main 씬을 담당하는 클래스 </para>
    /// </summary>
    public class DR_Main : MonoBehaviour
    {
        [Header("- Main Setting")]
        [SerializeField] private DR_Setting_Main mainSetting;

        [Header("- 대화 기능")]
        [SerializeField] private DR_Communication communication;

        [Header("- Fade 이미지")]
        [Header("UI"), Space(20)]
        [SerializeField] private Image fadeImage;

        [Header("- 메인 맵")]
        [SerializeField] private Image mainMapImage;

        private void Start()
        {
            Func_SetInit();
        }

        

        #region 저장된 정보를 준비

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : 저장되어있는 정보를 화면에 출력 준비해 주는 기능 </para>
        /// </summary>
        private void Func_SetInit()
        {
            if (DR_ProgramManager.Instance.saveInfo.isCommunication)   // 대화중이였으면 대화스크립트 활성화
            {
                communication.Func_Init();
            }

            DR_ProgramManager.Instance.Func_Fade(FADE.In, fadeImage);
        }

        #endregion

        #region Main Map

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-01 </para>
        /// <para> 내    용 : 메인 맵을 설정하는 기능 </para>
        /// </summary>
        public void Func_SetMainMap(MAINMAP_KIND _kind)
        {
            mainMapImage.sprite = mainSetting.mainMapArr[(int)_kind];
        }

        #endregion
    }
}