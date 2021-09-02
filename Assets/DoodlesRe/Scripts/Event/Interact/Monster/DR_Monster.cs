using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-16 </para>
    /// <para> 내    용 : 몬스터 클래스 </para>
    /// </summary>
    public class DR_Monster : DR_Character
    {
        [Header("- 몬스터 능력")]
        [SerializeField] private FSM_MONSTER monsterState;
        public int currentHP;                           // 현재 HP
        [SerializeField] private int moveSpeed;         // 몬스터 스피드
        [SerializeField] private float attackRange;     // 공격 사거리
        public float attackCoolTime;                    // 공격 쿨타임

        [Header("- 몬스터 캐싱")]
        public Animator anim;
        [SerializeField] private Rigidbody2D m_rigidbody2D;

        [HideInInspector] public Transform target;          // 공격 타겟
        private DR_StateMachine<DR_Monster> stateMachine;   // FSM
        private float moveX;                                // 방향 스칼라

        public int CurrentHP
        {
            get
            {
                return currentHP;
            }
        }
        private void Awake()
        {
            Func_SetInit();
        }

        private void Update()
        {
            stateMachine.Func_Update();
        }

        protected void FixedUpdate()
        {

            m_rigidbody2D.velocity = new Vector2(moveX * moveSpeed, m_rigidbody2D.velocity.y);
        }

        #region 초기 설정

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-09-02 </para>
        /// <para> 내    용 : FSM 초기 설정 </para>
        /// </summary>
        protected virtual void Func_SetInit()
        {
            DR_FSM_State<DR_Monster> _idleState = new DR_State_Idle();
            DR_FSM_State<DR_Monster> _followState = new DR_State_Follow();
            DR_FSM_State<DR_Monster> _attackState = new DR_State_Attack();
            DR_FSM_State<DR_Monster> _hitState = new DR_State_Hit();
            DR_FSM_State<DR_Monster> _dieState = new DR_State_Die();

            stateMachine = new DR_StateMachine<DR_Monster>();
            stateMachine.Initial_Setting(this, _idleState, _followState, _attackState, _hitState, _dieState);
        }

        #endregion

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-02 </para>
        /// <para> 내    용 : 캐릭터에 닿았을 때 호출 </para>
        /// </summary>
        protected override void Func_TriggerOn(Collider2D _coll)    { }


        #region Monster 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : DR_CheckPlayer에서 플레이어를 찾았을 때 호출되는 기능 </para>
        /// </summary>
        public void Func_FollowPlayer(Transform _targetTr)
        {
            target = _targetTr;
            stateMachine.Func_ChangeState(FSM_MONSTER.Follow);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 플레이어가 발견 사거리 밖으로 나갈 때 호출되는 기능 </para>
        /// </summary>
        public void Func_ExitPlayer()
        {
            target = null;
            moveX = 0;
            stateMachine.Func_ChangeState(FSM_MONSTER.Idle);
        }

        private void Func_MoveX(bool _isLeft)
        {
            moveX = (_isLeft) ? 1f : -1f;

            Func_Flip(_isLeft);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-29 </para>
        /// <para> 내    용 : 캐릭터 몸을 뒤집는 기능 </para>
        /// </summary>
        private void Func_Flip(bool _isLeft)
        {

            transform.localScale = new Vector3((_isLeft) ? 1f : -1f, 1f, 1f);

        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-09-02 </para>
        /// <para> 내    용 : 주변을 탐색하는 기능 </para>
        /// </summary>
        public virtual void Func_SearchArea()
        {

        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 공격당했을 때 데미지를 주는 기능. 공격한쪽에서 호출</para>
        /// </summary>
        public override void Func_Hit(int _damage)
        {
            currentHP -= _damage;

            if (currentHP >= 0)
            {
                stateMachine.Func_ChangeState(FSM_MONSTER.Hit);
            }
            else
            {
                currentHP = 0;
                stateMachine.Func_ChangeState(FSM_MONSTER.Die);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-26 </para>
        /// <para> 내    용 : 타겟을 공격할 수 있는 사거리인지 체크</para>
        /// </summary>
        public bool Func_CheckRange()
        {
            if (target == null)
                return false;

            return Vector2.Distance(target.position, transform.position) <= attackRange;
        }

        #endregion

        #region FSM

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-09-02 </para>
        /// <para> 내    용 : FSM을 바꾸는 기능 </para>
        /// </summary>
        public void Func_ChangeState(FSM_MONSTER _state)
        {
            monsterState = _state;
            stateMachine.Func_ChangeState(_state);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-09-02 </para>
        /// <para> 내    용 : 현재 상태가 무엇인지 체크 </para>
        /// </summary>
        public void Func_CheckState(FSM_MONSTER _state)
        {
            monsterState = _state;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 대기중일 때 </para>
        /// </summary>
        protected virtual void Func_Idle()
        {
            moveX = 0;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 일반적으로 플레이어를 따라가는 기능 </para>
        /// </summary>
        public virtual void Func_Follow()
        {
            if (target == null)
                return;

            Func_MoveX((transform.position - target.position).x < 0);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-18 </para>
        /// <para> 내    용 : 사거리에 따라 공격하는 기능</para>
        /// </summary>
        public virtual void Func_Attack()
        {
            moveX = 0;
            anim.SetTrigger("Attack");
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-18 </para>
        /// <para> 내    용 : 죽었을 때 호출되는 기능</para>
        /// </summary>
        public virtual void Func_Die()
        {
            enabled = false;        // FSM 안돌게 비활성화
        }

        #endregion


    }
}