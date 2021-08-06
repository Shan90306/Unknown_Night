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
        [SerializeField] protected float attackCoolTime;                // 공격당하고 다음 공격때까지 쿨타임

        protected void OnTriggerEnter2D(Collider2D _coll)
        {
            Func_TriggerOn(_coll);
        }

        #region 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-02 </para>
        /// <para> 내    용 : 캐릭터에 닿았을 때 호출 </para>
        /// </summary>
        protected virtual void Func_TriggerOn(Collider2D _coll) { }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-04 </para>
        /// <para> 내    용 :  공격당했을 때 데미지를 주는 기능. 공격한쪽에서 호출</para>
        /// </summary>
        public virtual void Func_Attacked(int _damage) { }

        #endregion
    }
}