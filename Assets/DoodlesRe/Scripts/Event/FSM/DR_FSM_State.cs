
namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-20 </para>
    /// <para> 내    용 : FSM의 부모 클래스 </para>
    /// </summary>
    public abstract class DR_FSM_State<T>
    {
        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 상태 진입 </para>
        /// </summary>
        public abstract void EnterState(T _character);

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 상태 진입 중 일때 </para>
        /// </summary>
        public abstract void UpdateState(T _character);

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-20 </para>
        /// <para> 내    용 : 상태가 끝났을 때</para>
        /// </summary>
        public abstract void ExitState(T _character);
    }
}