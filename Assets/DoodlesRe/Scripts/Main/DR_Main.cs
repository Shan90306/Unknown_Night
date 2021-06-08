﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        [SerializeField] private Image image_Fade;

        [Header("- 메인 맵")]
        [SerializeField] private Image image_MainMap;

        [Header("- 날씨 이미지")]
        [SerializeField] private Image image_Weather;

        [Header("- 시간 텍스트")]
        [SerializeField] private Text text_Time;

        [Header("- 이벤트 정보 창")]
        [SerializeField] private DR_EventInfo eventInfo;

        [Header("- 이벤트 정보 창이 움직여야 할 위치")]
        [SerializeField] private Transform eventInfoPoint;

        [Header("- 이벤트 클릭 시 이벤트가 와야 할 자리")]
        [SerializeField] private Transform eventMovePoint;

        private Transform minimapRoot;      // 미니맵 부모

        private void Start()
        {
            minimapRoot = image_MainMap.transform.parent;
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

            Func_SetDay();

            DR_ProgramManager.Instance.Func_Fade(FADE.In, image_Fade);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-02 </para>
        /// <para> 내    용 : 해당 일을 설정하는 기능 </para>
        /// *** 추후 매개변수를 스토리 CSV의 해당날짜를 가져와서 사용할 예정
        /// </summary>
        public void Func_SetDay()
        {
            image_Weather.sprite = mainSetting.weatherArr[(int)DR_ProgramManager.Instance.weather];
            text_Time.text = mainSetting.timeArr[(int)DR_ProgramManager.Instance.time];
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
            image_MainMap.sprite = mainSetting.mainMapArr[(int)_kind];
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-03 </para>
        /// <para> 내    용 : 이벤트 정보창을 설정하는 기능 </para>
        /// </summary>
        public void Func_SetEventInfo(Vector3 _eventPoint)
        {
            eventInfo.Func_SetEnable(eventInfoPoint.position);      // 정보창 활성화
            Func_SetEnlargement(true, _eventPoint);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-03 </para>
        /// <para> 내    용 : 맵 이벤트를 확대 축소 하는 기능 </para>
        /// </summary>
        public void Func_SetEnlargement(bool _enlargement, Vector3 _eventPoint = new Vector3())
        {
            if (_enlargement)       // 확대 시
            {
                minimapRoot.DOScale(new Vector3(2f, 2f, 2f), eventInfo.backTime);
                Vector3 _pos = eventMovePoint.position - (_eventPoint * 2f);
                minimapRoot.DOMove(_pos, eventInfo.backTime);
            }
            else                    // 축소 시
            {
                minimapRoot.DOScale(Vector3.one, eventInfo.backTime);
                minimapRoot.DOLocalMove(Vector3.zero, eventInfo.backTime);
            }
        }

        #endregion
    }
}