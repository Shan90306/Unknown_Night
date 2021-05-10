using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-05-10 </para>
    /// <para> 내    용 :  클래스 </para>
    /// </summary>
    public class DR_SavePopUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] popUIArr;

        public void Func_DisableAllPopUp()
        {
            Func_DisablePopUI();
            gameObject.SetActive(false);
        }

        public void Func_SetPopUI(int _popNum)
        {
            gameObject.SetActive(true);
            Func_DisablePopUI();

            popUIArr[_popNum].SetActive(true);
        }

        private void Func_DisablePopUI()
        {
            for (int i = 0; i < popUIArr.Length; i++)
            {
                popUIArr[i].SetActive(false);
            }
        }
    }
}