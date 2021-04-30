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
        [Header("- 타이틀 이미지")]
        [SerializeField] private Image image_Title;

        [Header("- 저장 날짜 텍스트")]
        [SerializeField] private Text text_SaveTime;

        [Header("- 플레이 타임 텍스트")]
        [SerializeField] private Text text_PlayTime;

        [Header("- 챕터 텍스트")]
        [SerializeField] private Text text_Chapter;

        [Header("- 돈 텍스트")]
        [SerializeField] private Text text_Gold;

        [Header("- 세이브 유무 오브젝트 배열")]
        [SerializeField] private GameObject[] existenceArr;     // 세이브가 없다면 NoData UI 활성화

        #region 메서드

        public void Func_SetSlot(DR_SaveInformation _saveSlot)
        {
            if (_saveSlot != null)
            {
                existenceArr[0].SetActive(false);
                existenceArr[1].SetActive(true);        // Data UI 활성화

                DateTime _firstTime = Convert.ToDateTime(_saveSlot.firstStartTime);
                DateTime _SaveTime = Convert.ToDateTime(_saveSlot.saveTime);
                TimeSpan _dateDiff = _SaveTime - _firstTime;

                text_SaveTime.text = _saveSlot.saveTime;         // 저장 시간 설정
                text_PlayTime.text = _dateDiff.ToString();         // 플레이 타임 설정
                text_Chapter.text = _saveSlot.chapter;           // 챕터 설정
                text_Gold.text = _saveSlot.gold.ToString();      // 소지 골드 설정
            }
        }

        public void Func_SetSlot(Sprite _title, string _saveTime, string _playTime, string _chapter, string _gold)
        {
            existenceArr[0].SetActive(false);
            existenceArr[1].SetActive(true);        // Data UI 활성화

            image_Title.sprite = _title;            // 타이틀 이미지 설정
            text_SaveTime.text = _saveTime;         // 저장 시간 설정
            text_PlayTime.text = _playTime;         // 플레이 타임 설정
            text_Chapter.text = _chapter;           // 챕터 설정
            text_Gold.text = _gold;                 // 소지 골드 설정
        }

        

        #endregion
    }
}