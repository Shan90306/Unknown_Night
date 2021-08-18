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
        [SerializeField] private int currentHP;         // 현재 HP
        [SerializeField] private int moveSpeed;         // 몬스터 스피드
        [SerializeField] private float attackRange;     // 공격 사거리
        [SerializeField] private float attackCoolTime;  // 공격 쿨타임

        [Header("- 몬스터 캐싱")]
        [SerializeField] private Animator anim;
        [SerializeField] private Rigidbody2D m_rigidbody2D;

        private Transform target;
        private float moveX;                        // 방향 스칼라
        private bool isAttack;                      // 공격중인지 체크
        private bool isAttackCoolTime = true;       // 공격중인지 체크
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

                if (monsterFSM == FSM_MONSTER.Idle)
                {

                }
                else
                {
                    // Follow, Hit, Attack 상태일 때

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
                    Func_Attack();
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
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 일반적으로 움직이는 기능 </para>
        /// </summary>
        protected virtual void Func_Move()
        {
            moveX = 0;
            //anim.SetTrigger("Idle");

        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-16 </para>
        /// <para> 내    용 : 일반적으로 플레이어를 따라가는 기능 </para>
        /// </summary>
        protected virtual void Func_Follow()
        {
            if (Vector2.Distance(transform.position, target.position) <= attackRange)     // 공격 사거리 안일 때
            {
                monsterFSM = FSM_MONSTER.Attack;
            }
            else
            {
                // 따라가는 기능
                anim.SetTrigger("Move");
                Func_MoveX((transform.position - target.position).x < 0);
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

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-18 </para>
        /// <para> 내    용 : 사거리에 따라 공격하는 기능</para>
        /// </summary>
        protected virtual void Func_Attack()
        {
            if (Vector2.Distance(transform.position, target.position) <= attackRange)     // 공격 사거리 안일 때
            {
                if (isAttackCoolTime)
                {
                    StartCoroutine(Co_AttackCoolTime());
                    moveX = 0;
                    DR_Debug.Func_Log("공격");
                    anim.SetTrigger("Attack");
                }
            }
            else
            {
                monsterFSM = FSM_MONSTER.Follow;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-18 </para>
        /// <para> 내    용 : 공격 쿨타임을 재는 코루틴 기능</para>
        /// </summary>
        private IEnumerator Co_AttackCoolTime()
        {
            isAttackCoolTime = false;
            yield return new WaitForSeconds(attackCoolTime);

            isAttackCoolTime = true;
        }

        private void Func_Die()
        {
            anim.SetTrigger("Die");
            enabled = false;        // FSM 안돌게 비활성화

        }
        #endregion

    }
}