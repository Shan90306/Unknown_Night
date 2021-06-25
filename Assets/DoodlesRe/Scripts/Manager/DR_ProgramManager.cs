using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-04-28 </para>
    /// <para> 내    용 : 프로그램을 관리하는 매니져 클래스 </para>
    /// </summary>
    public class DR_ProgramManager : DR_Singlton<DR_ProgramManager>
    {
        [Header("- 프로그램 세팅")]
        public DR_Setting_Program programSetting;

        [Header("- Volume")]
        public DR_Volume soundVolume;

        [Header("- Fade Value")]
        [SerializeField] private Image fadeImage;

        [Header("- Fade Value")]
        public float fadeTime = 1.5f;

        [Header("- 선택한 슬롯 번호")]
        public int playSlotNum;

        [Header("- 선택한 세이브 정보")]
        public DR_SaveInformation saveInfo;

        [Header("- 날씨")]
        public WEATHER_KIND weather;

        [Header("- 시간 대")]
        public TIME_KIND time;

        public string startTime;

        #region CSV Data

        public static List<Dictionary<string, object>> dialogueList;    // 스토리 CSV
        public static List<Dictionary<string, object>> characterList;   // 캐릭터 CSV
        public static List<Dictionary<string, object>> itemList;   // 아이템 CSV

        #endregion


        protected override void Func_Init()
        {
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-28 </para>
        /// <para> 내    용 : Fade 이미지를 설정하고 Fade 시키는 기능 </para>
        /// </summary>
        public void Func_Fade(FADE _fadeKind, Image _fadeImage = null, Action _action = null)
        {
            if (_fadeImage != null)
            {
                fadeImage = _fadeImage;
            }
            fadeImage.gameObject.SetActive(true);

            if (_fadeKind == FADE.In)
            {
                fadeImage.raycastTarget = false;
                fadeImage.DOFade(0f, fadeTime)
                    .OnComplete(() =>
                    {
                        fadeImage.gameObject.SetActive(false);
                        _action?.Invoke();
                    });
            }
            else
            {
                fadeImage.raycastTarget = true;
                fadeImage.DOFade(1f, fadeTime)
                   .OnComplete(() =>
                   {
                       _action?.Invoke();
                   });
            }
        }

        #region CSV 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : 선택한 세이브 정보를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetCSVData()
        {
            if (dialogueList == null)
            {
                DR_Debug.Func_Log("CSV 스토리 캐싱");
                dialogueList = DR_CSV.Func_Read(DR_PathDefine.CSV_StoryPath + DR_PathDefine.CSV_Dialogue);
            }
            if (characterList == null)
            {
                DR_Debug.Func_Log("CSV 캐릭터 캐싱");
                characterList = DR_CSV.Func_Read(DR_PathDefine.CSV_StoryPath + DR_PathDefine.CSV_Character);
            }
            if (itemList == null)
            {
                DR_Debug.Func_Log("CSV 아이템 캐싱");
                itemList = DR_CSV.Func_Read(DR_PathDefine.CSV_ItemPath + DR_PathDefine.CSV_Item);
            }

        }

        public Dictionary<string, object> Func_GetItem(int _id)
        {
            Dictionary<string, object> _dic = null;
            int _right = itemList.Count - 1;
            for (int _left = 0; _left <= _right;)
            {
                int _middle = (_left + _right) / 2;
                int _data = int.Parse(itemList[_middle][DR_PathDefine.XML_Key_ID].ToString());
                if (_id > _data)
                {
                    _left = _middle + 1;
                }
                else if (_id < _data)
                {
                    _right = _middle - 1;
                }
                else
                {
                    _dic = itemList[_middle];
                    return _dic;
                }
            }

            return _dic;
        }

        #endregion

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : 선택한 세이브 정보를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetSaveInfo(DR_SaveInformation _saveInfo)
        {
            saveInfo = _saveInfo;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-23 </para>
        /// <para> 내    용 : 세이브 슬롯 선택 후 게임을 시작하고 얼마나 시간이 지났는지 반환하는 기능 </para>
        /// </summary>
        public string Func_GetPlayTime()
        {
            DateTime _startTime = Convert.ToDateTime(startTime);
            DateTime _SaveTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            DateTime _cumulativeTime = Convert.ToDateTime(saveInfo.playTime);
            TimeSpan _dateDiff = _SaveTime - _startTime;

            _cumulativeTime += _dateDiff;

            return _cumulativeTime.ToString("HH:mm:ss");
        }

        public static void Func_Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();            
#endif
        }
    }
}