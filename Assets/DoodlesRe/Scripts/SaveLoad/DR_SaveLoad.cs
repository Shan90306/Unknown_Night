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

        private void Start()
        {
            //DR_XML.Instance.Func_LoadSaveSlotXML(0);
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

            }
        }

        #endregion
    }
}