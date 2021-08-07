using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-02 </para>
    /// <para> 내    용 : 인터렉션 가능한 오브젝트의 기초 클래스 </para>
    /// </summary>
    public class DR_InteractObject : DR_Interact
    {
        [Header("- 오브젝트 종류")]
        [SerializeField] private OBJECT_KIND kind;

        private void Start()
        {
            Func_CheckObject();
        }

        private void Func_CheckObject()
        {
            switch (kind)
            {
                case OBJECT_KIND.Attack_Static:
                    break;

                case OBJECT_KIND.Attack_Move:
                    Func_Move();
                    break;

                case OBJECT_KIND.Box:
                    break;

                case OBJECT_KIND.Collider:
                    break;
            }
        }

        protected virtual void Func_Move() {    }
    }
}