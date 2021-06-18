using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-15 </para>
    /// <para> 내    용 : Info에 관한 클래스의 부모 클래스 </para>
    /// </summary>
    public class DR_Info : MonoBehaviour, DR_IWindow
    {
        [Header("- Main")]
        [SerializeField] private DR_Main main;

        private void OnEnable()
        {
            Func_Init();
        }

        public virtual void Func_Close() { }

        protected void Func_Init()
        {
            main.Func_PushStack(this);
        }

        public virtual void Func_SetEnable() { }
    }
}