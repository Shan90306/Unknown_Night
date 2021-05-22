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

        #region CSV Data

        public static List<Dictionary<string, object>> dialogueList;    // 스토리 CSV
        public static List<Dictionary<string, object>> characterList;   // 캐릭터 CSV

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

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : 선택한 세이브 정보를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetCSVData()
        {
            if (dialogueList == null)
            {
                Debug.Log("CSV 스토리 캐싱");
                dialogueList = DR_CSV.Func_Read(DR_PathDefine.CSV_StoryPath + DR_PathDefine.CSV_Dialogue);
            }
            if (characterList == null)
            {
                Debug.Log("CSV 캐릭터 캐싱");
                characterList = DR_CSV.Func_Read(DR_PathDefine.CSV_StoryPath + DR_PathDefine.CSV_Character);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : 선택한 세이브 정보를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetSaveInfo(DR_SaveInformation _saveInfo)
        {
            saveInfo = _saveInfo;
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