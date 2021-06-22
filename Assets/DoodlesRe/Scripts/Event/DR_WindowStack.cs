using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-22 </para>
    /// <para> 내    용 : 창 형식을 관리하기 위한 스택을 담당하는 클래스 </para>
    /// </summary>
    public class DR_WindowStack : MonoBehaviour
    {
        private Stack<DR_IWindow> windowStack = new Stack<DR_IWindow>();

        public int Count
        {
            get
            {
                return windowStack.Count;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-15 </para>
        /// <para> 내    용 : 스택에 푸쉬 </para>
        /// </summary>
        public void Func_Push(DR_IWindow _iWindow)
        {
            windowStack.Push(_iWindow);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-15 </para>
        /// <para> 내    용 : 스택의 첫번째 노드 팝 </para>
        /// </summary>
        public DR_IWindow Func_Pop()
        {
            return windowStack.Pop();
        }
    }
}