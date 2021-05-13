using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-04-29 </para>
    /// <para> 내    용 : Save & Load를 관리하는 클래스 </para>
    /// </summary>
    public class DR_SaveLoad : MonoBehaviour
    {
        [Header("- 저장 슬롯 배열")]
        [SerializeField] private DR_SaveSlot[] saveSlotArr;

        [Header("- Save Load 종류")]
        public SAVELOAD_KIND kind;

        [Header("- 팝업창")]
        [SerializeField] private DR_SavePopUI popUpUI;

        [Header("- 선택한 슬롯 번호")]
        [SerializeField] private int selectSlotNum;


        private void OnEnable()
        {
            Func_SetSaveSlot();
        }

        #region 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : 저장 슬롯들을 설정하는 기능 </para>
        /// </summary>
        private void Func_SetSaveSlot()
        {
            for (int i = 0; i < saveSlotArr.Length; i++)
            {
                Func_SetSaveSlot(i);
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

        public void Func_ClickSaveSlot(int _slotNum)
        {
            switch (kind)
            {
                case SAVELOAD_KIND.Save:
                    break;

                case SAVELOAD_KIND.Load:
                    break;

                case SAVELOAD_KIND.Intro:
                    if (saveSlotArr[_slotNum].isSave)
                    {
                        Debug.Log("게임 시작");
                    }
                    else
                    {
                        Debug.Log("새로 만들기 : " + _slotNum);
                        DR_XML.Instance.Func_Create_SaveSlotXML(_slotNum);

                        Func_SetSaveSlot(_slotNum);
                    }
                    break;
            }
        }

        public void Func_ClickDeleteSlot(int _slotNum)
        {
            popUpUI.Func_SetPopUI(2);
            selectSlotNum = _slotNum;
        }

        #endregion

        #region Button 메서드

        public void Button_DeleteSaveSlot()
        {
            popUpUI.Func_DisableAllPopUp();     // 모든 팝업창 닫기
            saveSlotArr[selectSlotNum].Func_DeleteSaveSlot();
        }

        #endregion
    }
}