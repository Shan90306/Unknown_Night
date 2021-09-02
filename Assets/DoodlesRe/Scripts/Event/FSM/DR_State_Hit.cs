using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{

    public class DR_State_Hit : DR_FSM_State<DR_Monster>
    {
        private float hitTimer = 0.5f;      // 맞은 애니메이션 재생을 위한 잠시 대기 시간
        private float timer = 0f;

        public override void EnterState(DR_Monster _character)
        {
            _character.anim.SetTrigger("Hit");
            DR_Debug.Func_Log("맞음");
        }

        public override void UpdateState(DR_Monster _character)
        {
            timer += Time.deltaTime;
            if (timer >= hitTimer)
            {
                timer = 0;
                if (!_character.anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
                {
                    _character.Func_ChangeState(FSM_MONSTER.Idle);
                }
            }
        }

        public override void ExitState(DR_Monster _character)
        {

        }
    }
}