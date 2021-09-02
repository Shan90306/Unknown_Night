
namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-20 </para>
    /// <para> 내    용 : FSM을 실행하는 클래스 </para>
    /// </summary>
    public class DR_StateMachine<T>
    {
        private T Owner;                            // 상태의 주인
        private DR_FSM_State<T> currentState;       // 현재 상태
        private DR_FSM_State<T> previousState;      // 이전 상태

        private DR_FSM_State<T> state_Move;
        private DR_FSM_State<T> state_Attack;
        private DR_FSM_State<T> state_Die;

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
        public void Initial_Setting(T _owner, DR_FSM_State<T> _moveState, DR_FSM_State<T> _attackState, DR_FSM_State<T> _dieState)
        {
            Owner = _owner;
            state_Move = _moveState;
            state_Attack = _attackState;
            state_Die = _dieState;

            Func_ChangeState(state_Move);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 상태를 바꾸는 기능 </para>
        /// </summary>
        public void Func_ChangeState(DR_FSM_State<T> _newState)
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
        public void Update()
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