
namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-20 </para>
    /// <para> 내    용 : FSM을 실행하는 클래스 </para>
    /// </summary>
    public class DR_StateMachine<T> where T : DR_Monster 
    {
        private T Owner;                            // 상태의 주인
        private DR_FSM_State<T> currentState;       // 현재 상태
        private DR_FSM_State<T> previousState;      // 이전 상태

        private DR_FSM_State<T> state_Idle;         // 대기 상태
        private DR_FSM_State<T> state_Follow;       // 적 발견 상태
        private DR_FSM_State<T> state_Hit;          // 맞은 상태
        private DR_FSM_State<T> state_Attack;       // 공격 상태
        private DR_FSM_State<T> state_Die;          // 죽은 상태

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 초기화 </para>
        /// </summary>
        public void Awake()
        {
            currentState = null;
            previousState = null;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 초기 상태 설정 </para>
        /// </summary>    
        public void Initial_Setting(T _owner, 
            DR_FSM_State<T> _idleState, DR_FSM_State<T>  _followState, DR_FSM_State<T> _attackState, DR_FSM_State<T> _hitState, DR_FSM_State<T> _dieState)
        {
            Owner = _owner;                 // 주인 캐싱

            // 각 상태별 캐싱
            state_Idle = _idleState;        // 대기
            state_Follow = _followState;    // 적 발견
            state_Attack = _attackState;    // 공격
            state_Hit = _hitState;          // 맞음
            state_Die = _dieState;          // 죽음

            Func_ChangeState(state_Idle);   // 시작할 때는 대기상태로 시작
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 열거형에 따라 상태를 바꾸는 기능 </para>
        /// </summary>
        public void Func_ChangeState(FSM_MONSTER _state)
        {
            Owner.Func_CheckState(_state);

            switch (_state)
            {
                case FSM_MONSTER.Idle:
                    Func_ChangeState(state_Idle);
                    break;

                case FSM_MONSTER.Follow:
                    Func_ChangeState(state_Follow);
                    break;

                case FSM_MONSTER.Hit:
                    Func_ChangeState(state_Hit);
                    break;

                case FSM_MONSTER.Attack:
                    Func_ChangeState(state_Attack);
                    break;

                case FSM_MONSTER.Die:
                    Func_ChangeState(state_Die);
                    break;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 상태를 바꾸는 기능 </para>
        /// </summary>
        private void Func_ChangeState(DR_FSM_State<T> _newState)
        {
            // 같은 상태를 변경하려하면 리턴
            if (_newState == currentState)
            {
                return;
            }

            previousState = currentState;

            // 현재 상태가 있다면 종료
            if (currentState != null)
            {
                currentState.ExitState(Owner);
            }
            currentState = _newState;

            // 새로 적용된 상태가 null이면 종료
            if (currentState != null)
            {
                currentState.EnterState(Owner);
            }
        }
               
        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 현재 상태의 Update </para>
        /// </summary>    
        public void Func_Update()
        {
            if (currentState != null)
            {
                currentState.UpdateState(Owner);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 이전 상태로 변환 </para>
        /// </summary>   
        public void StateRevert()
        {
            if (previousState != null)
            {
                Func_ChangeState(previousState);
            }
        }
    }
}