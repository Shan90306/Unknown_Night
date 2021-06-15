using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-03 </para>
    /// <para> 내    용 : 맵의 이벤트 포인트 클래스 </para>
    /// </summary>
    public class DR_EventPoint : MonoBehaviour
    {
        [Header("- Main")]
        [SerializeField] private DR_Main main;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-03 </para>
        /// <para> 내    용 : 이벤트 포인트를 클릭했을 때 호출 </para>
        /// </summary>
        public void Button_SellectEvent()
        {
            if (!main.isEventInfo)
            {
                main.Func_SetEventInfo(transform.position);       // 맵 정보창 설정
            }
        }
    }
}