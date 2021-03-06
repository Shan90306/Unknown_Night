using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{

    public class DR_State_Die : DR_FSM_State<DR_Monster>
    {
        public override void EnterState(DR_Monster _character)
        {
            _character.anim.SetTrigger("Die");
            _character.Func_Die();
        }

        public override void UpdateState(DR_Monster _character)
        {

        }

        public override void ExitState(DR_Monster _character)
        {

        }
    }
}