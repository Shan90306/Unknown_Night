using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-15 </para>
    /// <para> 내    용 : 스테이터스창을 관리하는 클래스 </para>
    /// </summary>
    public class DR_Status : DR_Info
    {

        public override void Func_SetEnable()
        {
            gameObject.SetActive(true);
        }

        public override void Func_Close()
        {
            gameObject.SetActive(false);
        }
    }
}