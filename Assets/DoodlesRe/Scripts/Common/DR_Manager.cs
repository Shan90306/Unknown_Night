using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-01 </para>
    /// <para> 내    용 : 모든 지역 버튼을 초기화하는 기능 </para>
    /// </summary>
    public class DR_Manager : MonoBehaviour
    {
        [Header("- Window Stack")]
        [SerializeField] protected DR_WindowStack windowStack;

        #region Stack 메서드

        public void Func_PushStack(DR_IWindow _iWindow)
        {
            windowStack.Func_Push(_iWindow);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-15 </para>
        /// <para> 내    용 : ESC를 누르지 않고 기능을 창형식을 껐을 때 호출 </para>
        /// </summary>
        public void Func_DontClickESC()
        {
            windowStack.Func_Pop();
        }

        #endregion
    }
}