using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-20 </para>
    /// <para> 내    용 : FSM의 공격 상태 클래스 </para>
    /// </summary>
    public class DR_State_Attack : DR_FSM_State<DR_Monster>
    {     
        private float attackTimer = 0f;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 공격 상태에 진입했을 때 </para>
        /// </summary>
        public override void EnterState(DR_Monster _character)
        {
            if (_character.target == null)
            {
                return;
            }

            attackTimer = _character.attackCoolTime;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 공격 상태일 때 한 프레임 씩 호출 </para>
        /// </summary>
        public override void UpdateState(DR_Monster _character)
        {
            // 죽음 유무 확인
            if (_character.currentHP <= 0)
            {
                _character.Func_ChangeState(FSM_Die.Instance);
            }

            attackTimer += Time.deltaTime;
            if (_character.Func_CheckRange())
            {
                if (attackTimer >= _character.attackCoolTime)
                {
                    attackTimer = 0;
                    Debug.Log("공격!");
                }
            }
            else
            {
                _character.Func_ChangeState(FSM_Move.Instance);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 공격 상태가 끝났을 때 </para>
        /// </summary>
        public override void ExitState(DR_Monster _character)
        {

        }

    }
}