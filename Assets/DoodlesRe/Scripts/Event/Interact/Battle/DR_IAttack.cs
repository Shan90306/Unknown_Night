using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-04 </para>
    /// <para> 내    용 : 공격당할 수 있는 오브젝트의 인터페이스 </para>
    /// </summary>
    public interface DR_IAttack 
    {
        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-04 </para>
        /// <para> 내    용 : 공격당했을 때 호출 </para>
        /// </summary>
        /// <param name="_damage">데미지</param>
        void Func_Attack(int _damage);
    }
}