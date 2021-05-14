using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-05-10 </para>
    /// <para> 내    용 : SaveUI 팝업창 클래스 </para>
    /// </summary>
    public class DR_SavePopUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] popUIArr;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-10 </para>
        /// <para> 내    용 : 모든 팝업창 비활성화하고 자기자신도 비활성화하는 기능 </para>
        /// </summary>
        public void Func_DisableAllPopUp()
        {
            Func_DisablePopUI();
            gameObject.SetActive(false);
        }


        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-10 </para>
        /// <para> 내    용 : SaveUI 팝업창 클래스 </para>
        /// <para> 0 : 새로 생성하는 팝업 </para>
        /// <para> 1 : 덮어쓰기 팝업 </para>
        /// <para> 2 : 삭제 팝업 </para>
        /// </summary>
        public void Func_SetPopUI(int _popNum)
        {
            gameObject.SetActive(true);
            Func_DisablePopUI();

            popUIArr[_popNum].SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-10 </para>
        /// <para> 내    용 : 모든 팝업창 비활성화하는 기능 </para>
        /// </summary>
        private void Func_DisablePopUI()
        {
            for (int i = 0; i < popUIArr.Length; i++)
            {
                popUIArr[i].SetActive(false);
            }
        }
    }
}