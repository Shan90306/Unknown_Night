using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-15 </para>
    /// <para> 내    용 : 캐릭터 정보창을 관리하는 클래스 </para>
    /// </summary>
    public class DR_CharacterInfo : DR_Info, DR_IWindow
    {
        [Header("- Info Window 배열")]
        [SerializeField] private DR_Info[] infoWindowArr;

        private Action closeAction;

        #region 캐릭터 정보창 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-15 </para>
        /// <para> 내    용 : 캐릭터 정보창을 활성화 하는 기능 </para>
        /// </summary>
        public void Func_SetCharacterInfo(Action _closeAction)
        {
            // 연출
            closeAction = _closeAction;
            gameObject.SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-15 </para>
        /// <para> 내    용 : 캐릭터 정보창을 닫는 기능 </para>
        /// </summary>
        public override void Func_Close()
        {
            closeAction?.Invoke();
            closeAction = null;
            gameObject.SetActive(false);
        }

        #endregion

        #region 버튼 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-15 </para>
        /// <para> 내    용 : 캐릭터 정보창을 여는 버튼 메서드 </para>
        /// </summary>
        public void Button_Status()
        {
            infoWindowArr[0].Func_SetEnable();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-22 </para>
        /// <para> 내    용 : 장비창을 여는 버튼 메서드 </para>
        /// </summary>
        public void Button_Equipment()
        {
            infoWindowArr[1].Func_SetEnable();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-22 </para>
        /// <para> 내    용 : 스킬창을 여는 버튼 메서드 </para>
        /// </summary>
        public void Button_Skill()
        {
            infoWindowArr[2].Func_SetEnable();
        }
        #endregion
    }
}