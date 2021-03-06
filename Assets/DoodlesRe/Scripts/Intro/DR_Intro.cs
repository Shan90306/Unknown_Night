using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-04-28 </para>
    /// <para> 내    용 : 인트로를 관리하는 클래스 </para>
    /// </summary>
    public class DR_Intro : DR_Manager
    {
        [Header("- Fade 이미지")]
        [SerializeField] private Image fadeImage;

        [Header("- 옵션 UI")]
        [SerializeField] private GameObject optionUI;

        [Header("- 저장슬롯 UI")]
        [SerializeField] private DR_SaveLoad saveSlotUI;

        private void Start()
        {
            DR_ProgramManager.Instance.Func_Fade(FADE.In, fadeImage);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (windowStack.Count != 0)
                {
                    windowStack.Func_Pop().Func_Close();
                }
                else
                {
                    DR_Debug.Func_Log("옵션창 열기");
                }
            }
        }

        #region 버튼 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-28 </para>
        /// <para> 내    용 : 프로그램을 종료하는 버튼 메서드 </para>
        /// </summary>
        public void Button_ActiveSaveSlotUI(bool _isActive)
        {
            saveSlotUI.kind = SAVELOAD_KIND.Intro;
            saveSlotUI.gameObject.SetActive(_isActive);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-28 </para>
        /// <para> 내    용 : 프로그램을 종료하는 버튼 메서드 </para>
        /// </summary>
        public void Button_ActiveOptionUI(bool _isActive)
        {
            optionUI.SetActive(_isActive);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-28 </para>
        /// <para> 내    용 : 프로그램을 종료하는 버튼 메서드 </para>
        /// </summary>
        public void Button_Quit()
        {
            DR_ProgramManager.Instance.Func_Fade(FADE.Out, fadeImage, () => DR_ProgramManager.Func_Quit());
        }

        #endregion
    }
}