using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-04-29 </para>
    /// <para> 내    용 : Save & Load를 관리하는 클래스 </para>
    /// </summary>
    public class DR_SaveLoad : DR_Info
    {
        [Header("- 세이브 로드의 타이틀 텍스트")]
        [SerializeField] private Text text_Title;

        [Header("- 저장 슬롯 배열")]
        [SerializeField] private DR_SaveSlot[] saveSlotArr;

        [Header("- Save Load 종류")]
        public SAVELOAD_KIND kind;

        [Header("- 팝업창")]
        [SerializeField] private DR_SavePopUI popUpUI;

        [Header("- 선택한 슬롯 번호")]
        [SerializeField] private int selectSlotNum;

        private void Start()
        {
            Func_SetTitle(kind);
            StartCoroutine(Co_SetSaveSlot());
        }

        #region 기능

        public override void Func_SetEnable()
        {
            gameObject.SetActive(true);
        }

        public override void Func_Close()
        {
            gameObject.SetActive(false);
            popUpUI.Func_DisableAllPopUp();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : Save & Load창의 타이틀 텍스트를 변경하는 기능</para>
        /// </summary>
        private void Func_SetTitle(SAVELOAD_KIND _kind)
        {
            kind = _kind;
            switch (kind)
            {
                case SAVELOAD_KIND.Save:
                    text_Title.text = DR_DefineSaveLoadTitle.Save;
                    break;

                case SAVELOAD_KIND.Load:
                    text_Title.text = DR_DefineSaveLoadTitle.Load;
                    break;

                case SAVELOAD_KIND.Intro:
                    text_Title.text = DR_DefineSaveLoadTitle.Intro;
                    break;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : 저장 슬롯들을 설정하는 기능 </para>
        /// </summary>
        private IEnumerator Co_SetSaveSlot()
        {
            for (int i = 0; i < saveSlotArr.Length; i++)
            {
                Func_SetSaveSlot(i);
                yield return null;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : 저장 슬롯들을 설정하는 기능 </para>
        /// </summary>
        private void Func_SetSaveSlot(int _slotNum)
        {
            DR_SaveInformation _saveInfo = DR_XML.Instance.Func_LoadSaveSlotXML(_slotNum);

            saveSlotArr[_slotNum].Func_SetSlot(_saveInfo, _slotNum);      // 슬롯 설정
            saveSlotArr[_slotNum].saveLoad = this;

            if (kind == SAVELOAD_KIND.Intro)
            {
                saveSlotArr[_slotNum].Func_IsIntro(true);           // 인트로인지 체크
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : 슬롯을 클릭했을 때 호출되는 기능 </para>
        /// </summary>
        public void Func_ClickSaveSlot(int _slotNum, DR_SaveInformation _saveInfo)
        {
            switch (kind)
            {
                case SAVELOAD_KIND.Save:
                    if (saveSlotArr[_slotNum].isSave)
                    {
                        // 덮어 씌우기
                        popUpUI.Func_SetPopUI(1);       // 생성 팝업 활성화
                    }
                    else
                    {
                        // 현재까지 진행된 스토리 저장
                        DR_XML.Instance.Func_SaveSlotXML(_slotNum, _saveInfo);
                        Func_SetSaveSlot(_slotNum);
                    }
                    break;

                case SAVELOAD_KIND.Load:
                    DR_ProgramManager.Instance.Func_SetSaveInfo(_saveInfo);

                    break;

                case SAVELOAD_KIND.Intro:
                    if (saveSlotArr[_slotNum].isSave)
                    {
                        DR_Debug.Func_Log("게임 시작 : " + _slotNum);
                        DR_ProgramManager.Instance.playSlotNum = _slotNum;
                        DR_ProgramManager.Instance.Func_SetSaveInfo(_saveInfo);
                        DR_ProgramManager.Instance.Func_Fade(FADE.Out, null, () =>
                            DR_SceneManager.Instance.Func_GoLoadingBeforScene(SCENE_KIND.Main));                       
                    }
                    else
                    {
                        selectSlotNum = _slotNum;
                        popUpUI.Func_SetPopUI(0);       // 생성 팝업 활성화
                    }
                    break;
            }
        }

        public void Func_ClickDeleteSlot(int _slotNum)
        {
            popUpUI.Func_SetPopUI(2);
            selectSlotNum = _slotNum;
            DR_ScreenShot.Func_DeleteSlotScreenShot(_slotNum);
        }

        #endregion

        #region Button 메서드

        public void Button_CreateSlot()
        {
            DR_Debug.Func_Log("새로 만들기 : " + selectSlotNum);
            DR_XML.Instance.Func_Create_SaveSlotXML(selectSlotNum);

            Func_SetSaveSlot(selectSlotNum);
            popUpUI.Func_DisableAllPopUp();
        }

        public void Button_DeleteSaveSlot()
        {
            popUpUI.Func_DisableAllPopUp();     // 모든 팝업창 닫기
            saveSlotArr[selectSlotNum].Func_DeleteSaveSlot();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : Save 버튼을 눌렀을 때 세이브 창이 켜지는 버튼 메서드 </para>
        /// </summary>
        public void Button_Save()
        {
            Func_SetTitle(SAVELOAD_KIND.Save);
            gameObject.SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : Load 버튼을 눌렀을 때 로드 창이 켜지는 버튼 메서드 </para>
        /// </summary>
        public void Button_Load()
        {
            Func_SetTitle(SAVELOAD_KIND.Load);
            gameObject.SetActive(true);
        }

        public void Button_DisableSaveUI()
        {
            manager.Func_DontClickESC();
            Func_Close();
        }

        #endregion
    }
}