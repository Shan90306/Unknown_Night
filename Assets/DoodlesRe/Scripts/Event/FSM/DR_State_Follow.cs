using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{

    public class DR_State_Follow : DR_FSM_State<DR_Monster>
    {
        public override void EnterState(DR_Monster _character)
        {
            _character.anim.SetTrigger("Move");
        }

        public override void UpdateState(DR_Monster _character)
        {
            if (_character.Func_CheckRange())     // 공격 사거리 안일 때
            {
                _character.Func_ChangeState(FSM_MONSTER.Attack);
            }
            else
            {
                if (_character.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;

                // 따라가는 기능
                _character.Func_Follow();
            }
        }

        public override void ExitState(DR_Monster _character)
        {

        }
    }
}