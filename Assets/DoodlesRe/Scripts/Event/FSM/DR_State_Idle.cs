using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{

    public class DR_State_Idle : DR_FSM_State<DR_Monster>
    {
        private float minTime = 2f;
        private float maxTime = 5f;
        private float changeTime;
        private float timer = 0;

        public override void EnterState(DR_Monster _character)
        {
            _character.anim.SetTrigger("Idle");
            changeTime = Random.Range(minTime, maxTime);
            timer = changeTime;
        }

        public override void UpdateState(DR_Monster _character)
        {
            if (_character.target != null)
            {
                _character.Func_ChangeState(FSM_MONSTER.Follow);
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= changeTime)
                {
                    timer = 0f;
                    changeTime = Random.Range(minTime, maxTime);
                    bool _isRest = (Random.Range(1, 12) % 3 == 0) ? true : false;
                    DR_Debug.Func_Log("트리거");

                    if (_isRest)
                    {
                        // 쉬기
                        _character.anim.SetTrigger("Idle");
                        DR_Debug.Func_Log("쉬기");
                    }
                    else
                    {
                        // 탐색
                        _character.Func_SearchArea();
                        DR_Debug.Func_Log("탐색");
                    }
                }
            }
        }

        public override void ExitState(DR_Monster _character)
        {
            timer = 0f;
        }
    }
}