using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-20 </para>
    /// <para> 내    용 : 설명창 클래스 </para>
    /// </summary>
    public class DR_Explanation : MonoBehaviour
    {
        [Header("- 설명의 위치")]
        [SerializeField] private Transform explanation;

        [Header("- 설명의 위치")]
        [SerializeField] private Transform explanationPos;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-20 </para>
        /// <para> 내    용 : 설명창을 위치하게 하는 버튼을 눌렀을 때 호출 </para>
        /// </summary>
        public void Button_Explanation()
        {
            explanation.position = explanationPos.position;
            explanation.gameObject.SetActive(true);
        }
    }
}