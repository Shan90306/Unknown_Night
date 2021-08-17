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
        [SerializeField] private FSM_MONSTER monsterFSM;
        [SerializeField] private int currentHP;     // 현재 HP
        [SerializeField] private int moveSpeed;     // 몬스터 스피드
        [SerializeField] private float attackRange; // 공격 사거리

        [Header("- 몬스터 캐싱")]
        [SerializeField] private Animator anim;
        [SerializeField] private Rigidbody2D m_rigidbody2D;

        private Transform target;
        private float moveX;                        // 방향 스칼라
        private bool isAttack;                      // 공격중인지 체크
        private bool isDie;                         // 죽었는지 체크

        public int CurrentHP
        {
            get
            {
                return currentHP;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-02 </para>
        /// <para> 내    용 : 캐릭터에 닿았을 때 호출 </para>
        /// </summary>
        protected override void Func_TriggerOn(Collider2D _coll) 
        {
            //if (_coll.CompareTag(""))
            //{

            //}
        }

        private void Update()
        {
            Func_CheckFSM();
            Func_FSM();
        }

        protected void FixedUpdate()
        {

            m_rigidbody2D.velocity = new Vector2(moveX * moveSpeed, m_rigidbody2D.velocity.y);
        }

        #region FSM

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : FSM을 체크하는 기능 </para>
        /// </summary>
        private void Func_CheckFSM()
        {
            if (!isDie)     // 죽지 않았을 때
            {
                if (currentHP < 0)
                {
                    isDie = true;
                    return;
                }

                if (monsterFSM != FSM_MONSTER.Follow)
                {
                    // Idle, Hit, Attack 상태일 때

                }
                else
                {

                }

            }
            else  // 죽었을 때
            {
                monsterFSM = FSM_MONSTER.Die;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : FSM을 실행하는 기능 </para>
        /// </summary>
        private void Func_FSM()
        {
            switch (monsterFSM)
            {
                case FSM_MONSTER.Idle:
                    Func_Move();
                    break;

                case FSM_MONSTER.Follow:
                    Func_Follow();
                    break;

                case FSM_MONSTER.Hit:
                    break;

                case FSM_MONSTER.Attack:
                    break;

                case FSM_MONSTER.Die:
                    Func_Die();
                    break;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 플레이어를 찾았을 때 호출되는 기능 </para>
        /// </summary>
        public void Func_FollowPlayer(Transform _targetTr)
        {
            monsterFSM = FSM_MONSTER.Follow;
            target = _targetTr;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 플레이어를 찾았을 때 호출되는 기능 </para>
        /// </summary>
        public void Func_ExitPlayer()
        {
            monsterFSM = FSM_MONSTER.Idle;
        }

        private void Func_MoveX(bool _isLeft)
        {

        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 일반적으로 움직이는 기능 </para>
        /// </summary>
        protected virtual void Func_Move()
        {

        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 일반적으로 플레이어를 따라가는 기능 </para>
        /// </summary>
        protected virtual void Func_Follow()
        {
            if(Vector2.Distance(transform.position, target.position) <= attackRange)     // 공격 사거리 안일 때
            {

            }
            else
            {

            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 공격당했을 때 데미지를 주는 기능. 공격한쪽에서 호출</para>
        /// </summary>
        public override void Func_Hit(int _damage)
        {
            anim.SetTrigger("Hit");
            DR_Debug.Func_Log("맞음");
        }

        private void Func_Die()
        {
            anim.SetTrigger("Die");
            enabled = false;        // FSM 안돌게 비활성화

        }
        #endregion

    }
}