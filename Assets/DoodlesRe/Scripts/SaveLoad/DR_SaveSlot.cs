using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-04-29 </para>
    /// <para> 내    용 : Save & Load의 슬롯 클래스 </para>
    /// </summary>
    public class DR_SaveSlot : MonoBehaviour
    {
        [HideInInspector]
        public DR_SaveLoad saveLoad;        // 세이브 로드 관리 스크립트

        [Header("- 타이틀 이미지")]
        [SerializeField] private Image image_Title;

        [Header("- 저장 날짜 텍스트")]
        [SerializeField] private Text text_SaveTime;

        [Header("- 플레이 타임 텍스트")]
        [SerializeField] private Text text_PlayTime;

        [Header("- 챕터 텍스트")]
        [SerializeField] private Text text_Chapter;

        [Header("- 골드 텍스트")]
        [SerializeField] private Text text_Gold;

        [Header("- 삭제 버튼")]
        [SerializeField] private GameObject button_Delete;

        [Header("- 세이브 유무 오브젝트 배열")]
        [SerializeField] private GameObject[] existenceArr;     // 세이브가 없다면 NoData UI 활성화

        [Header("- 세이브 유무 체크")]
        public bool isSave;

        [Header("- 세이브 슬롯 번호")]
        [SerializeField] private int slotNum;

        [Header("- 세이브 정보")]
        [SerializeField] private DR_SaveInformation saveInfo;

        #region 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : 슬롯을 채우는 기능 </para>
        /// </summary>
        public void Func_SetSlot(DR_SaveInformation _saveSlot, int _slotNum)
        {
            slotNum = _slotNum;     // 슬롯 번호 저장

            if (_saveSlot != null)
            {
                saveInfo = _saveSlot;
                isSave = true;
                existenceArr[0].SetActive(false);
                existenceArr[1].SetActive(true);        // Data UI 활성화

                DateTime _firstTime = Convert.ToDateTime(_saveSlot.firstStartTime);
                DateTime _SaveTime = Convert.ToDateTime(_saveSlot.saveTime);
                TimeSpan _dateDiff = _SaveTime - _firstTime;

                image_Title.sprite = DR_ScreenShot.Func_GetSlotScreenShot(slotNum);
                text_SaveTime.text = _saveSlot.saveTime;         // 저장 시간 설정
                text_PlayTime.text = _dateDiff.ToString();       // 플레이 타임 설정
                text_Chapter.text = _saveSlot.chapter;           // 챕터 설정
                text_Gold.text = _saveSlot.gold.ToString();      // 소지 골드 설정
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-10 </para>
        /// <para> 내    용 : Intro인지 체크 후 삭제 버튼을 활성화시키는 기능 </para>
        /// </summary>
        public void Func_IsIntro(bool _isIntro)
        {
            if (_isIntro)
            {
                button_Delete.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-10 </para>
        /// <para> 내    용 : 슬롯에 있는 데이터를 NoData로 바꾸는 기능 </para>
        /// </summary>
        public void Func_DeleteSaveSlot()
        {
            existenceArr[1].SetActive(false);
            existenceArr[0].SetActive(true);

            DR_XML.Func_DeleteXML(slotNum);
            isSave = false;
        }

        #endregion

        #region Button 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : Save 슬롯을 클릭했을 때 호출되는 버튼 메서드 </para>
        /// </summary>
        public void Button_ClickSaveSlot()
        {
            DR_ProgramManager.Instance.Func_SetSaveInfo(saveInfo);
            saveLoad.Func_ClickSaveSlot(slotNum);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : 삭제 버튼 메서드. 세이브 된 파일을 지우고 빈 데이터 칸으로 만드는 기능 </para>
        /// </summary>
        public void Button_ClickDelete()
        {
            saveLoad.Func_ClickDeleteSlot(slotNum);            
        }

        #endregion
    }
}