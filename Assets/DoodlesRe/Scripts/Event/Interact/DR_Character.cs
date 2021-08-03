using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-07-30 </para>
    /// <para> 내    용 : 캐릭터의 기초 클래스 </para>
    /// </summary>
    public class DR_Character : DR_Interact
    {
        [Header("- 캐릭터 세팅")]
        [SerializeField] protected DR_DefineDetailStatus status;        // 디테일 스텟

        protected void OnTriggerEnter2D(Collider2D _coll)
        {
            Func_TriggerOn();
        }

        #region 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-02 </para>
        /// <para> 내    용 : 캐릭터에 닿았을 때 호출 </para>
        /// </summary>
        protected virtual void Func_TriggerOn() { }

        #endregion
    }
}