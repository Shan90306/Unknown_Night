using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-07-27 </para>
    /// <para> 내    용 : 플레이어 캐릭터를 컨트롤하는 클래스 </para>
    /// </summary>
    public class DR_PlayerController : MonoBehaviour
    {
        [Header("- 설정")]
        [SerializeField] private FSM fsm;           // 현재 행동
        [SerializeField] private int moveSpeed;     // 캐릭터 스피드
        [SerializeField] private int maxJumpCount;  // 최대 점프 횟수
        [SerializeField] private int jumpForce;     // 점프 파워

        [Header("- 캐릭터 캐싱")]
        [SerializeField] private Animator anim;     // 애니메이터
        public Rigidbody2D m_rigidbody;             // 강체 캐싱
        public Collider2D playerCollider;           // 플레이어 콜라이더 캐싱
        public DR_HitSensor attackedSensor;        // 플레이어 피격 센서 캐싱
        public Slider slider_HP;                    // HP 슬라이더 캐싱

        [HideInInspector] public int currentJumpCount;          // 현재 점프 숫자
        [HideInInspector] public bool isGround;                 // 캐릭터가 바닥에 있는지 체크
        [HideInInspector] public bool isWall;                   // 플레이어가 가는 방향에 벽이 있는지 체크
        [HideInInspector] public bool isDownJumpGroundCheck;    // 현재 밑이 블럭인지 땅인지 체크

        private DR_PlayerAbility playerAbility;     // 플레이어 능력 캐싱
        private float moveX;                        // 방향 스칼라
        private bool isSit;                         // 앉았는지 체크
        private bool isDie;                         // 죽었는지 체크
        //private bool isFirstDie;                    // 죽음 애니메이션을 한번 했는지 체크
        private bool isAttack;                      // 공격중인지 체크

        private void Start()
        {
            playerAbility = GetComponent<DR_PlayerAbility>();
        }

        // Update is called once per frame
        void Update()
        {
            Func_InputCheck();
            Func_FSM();
        }

        private void FixedUpdate()
        {
            if (isGround && isAttack)
            {
                return;
            }

            if (isWall || isDie)
            {
                moveX = 0;
            }

            m_rigidbody.velocity = new Vector2(moveX * moveSpeed, m_rigidbody.velocity.y);
        }

        #region 이동 관련 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-28 </para>
        /// <para> 내    용 : 입력 체크하여 해당하는 행동을 하게 하는 기능 </para>
        /// </summary>
        private void Func_InputCheck()
        {
            if (!isDie)
            {
                // 땅에 있을 때
                if (isGround)
                {
                    if (Input.GetKey(KeyCode.DownArrow))  //아래 버튼 눌렀을때
                    {
                        fsm = FSM.Sit;
                        isSit = true;
                    }
                    else if (Input.GetKeyUp(KeyCode.DownArrow)) //아래 버튼 뗐을 때
                    {
                        fsm = FSM.Idle;
                        isSit = false;
                    }

                    if (Input.GetKey(KeyCode.Space))
                    {
                        if (isAttack)
                        {
                            return;
                        }

                        if (currentJumpCount < maxJumpCount)
                        {
                            fsm = FSM.Jump;
                        }

                        return;
                    }

                    if (isSit)
                    {
                        moveX = 0;
                        return;
                    }
                    else
                    {
                        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                        {
                            if (Input.GetKey(KeyCode.Z))
                            {
                                isAttack = true;
                                fsm = FSM.Attack;

                            }
                            else
                            {
                                isAttack = false;
                            }
                        }
                    }

                    if (!isAttack)
                    {
                        if (Input.GetKey(KeyCode.LeftArrow))
                        {
                            fsm = FSM.Move;
                            Func_Move(true);
                        }
                        else if (Input.GetKey(KeyCode.RightArrow))
                        {
                            fsm = FSM.Move;
                            Func_Move(false);
                        }
                        else
                        {
                            fsm = FSM.Idle;
                            moveX = 0;
                        }
                    }
                }
                // 공중일 때
                else
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    {
                        if (Input.GetKey(KeyCode.Z))
                        {
                            isAttack = true;
                            fsm = FSM.Attack;
                        }
                        else
                        {
                            isAttack = false;
                            anim.SetTrigger("Jump");
                            fsm = FSM.Jump;
                        }
                    }

                    if (Input.GetKeyUp(KeyCode.DownArrow)) //아래 버튼 뗐을 때
                    {
                        anim.SetTrigger("Jump");
                        isSit = false;
                    }
                    else if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        Func_Move(true);
                    }
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        Func_Move(false);
                    }
                    else
                    {
                        moveX = Input.GetAxis("Horizontal");
                    }
                }
            }
            else
            {
                fsm = FSM.Die;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DR_Debug.Func_Log("테스트 죽기");
                isDie = true;
                fsm = FSM.Die;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                DR_Debug.Func_Log("테스트 살리기");
                Func_Resurrection();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-05 </para>
        /// <para> 내    용 : 입력 값으로 행동하는 기능 </para>
        /// </summary>
        private void Func_FSM()
        {
            switch (fsm)
            {
                case FSM.Attack:
                    Func_Attack_Nomal();
                    break;

                case FSM.Jump:
                    if (isSit)
                    {
                        Func_DownJump();
                    }
                    else
                    {
                        Func_Jump();
                    }
                    break;

                case FSM.Move:
                    anim.SetTrigger("Move");
                    break;

                case FSM.Sit:
                    anim.SetTrigger("Sit");
                    break;

                case FSM.Die:
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
                    {
                        DR_Debug.Func_Log("죽음");
                        anim.SetTrigger("Die");
                    }
                    break;

                case FSM.Idle:
                    anim.SetTrigger("Idle");
                    break;
            }
        }

        private void Func_Move(bool _isLeft)
        {
            if (isAttack)
            {
                return;
            }
            if (isGround)
            {
                moveX = _isLeft ? -1 : 1;
            }
            else
            {
                moveX = Input.GetAxis("Horizontal");
            }

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
        /// <para> 작 성 일 : 2021-07-28 </para>
        /// <para> 내    용 : 위로 점프하는 기능 </para>
        /// </summary>
        private void Func_Jump()
        {
            if (!isGround)
                return;

            isGround = false;
            currentJumpCount++;

            anim.SetTrigger("Jump");
            m_rigidbody.velocity = new Vector2(0, 0);
            m_rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-28 </para>
        /// <para> 내    용 : 밟고있는 땅을 체크하고 밑으로 점프하는 기능 </para>
        /// </summary>
        private void Func_DownJump()
        {
            if (!isGround)
            {
                return;
            }

            if (!isDownJumpGroundCheck)
            {
                isGround = false;

                anim.SetTrigger("Jump");
                playerCollider.enabled = false;                     // 플레이어 콜라이더 끄기
                m_rigidbody.AddForce(-Vector2.up * 10);
                StartCoroutine(Co_GroundColliderTimmer());       // 일정시간후에 플레이어 콜라이더 켜기
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-28 </para>
        /// <para> 내    용 : 밑으로 점프할 때 잠깐의 시간후 플레이어의 콜라이더를 켜는 코루틴 기능 </para>
        /// </summary>
        IEnumerator Co_GroundColliderTimmer()
        {
            yield return new WaitForSeconds(0.3f);
            playerCollider.enabled = true;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-06 </para>
        /// <para> 내    용 : 살아났을 때  코루틴 기능 </para>
        /// </summary>
        IEnumerator Co_AttackSensorColliderTimmer()
        {
            attackedSensor.Func_IsAttackedable(false);
            
            yield return new WaitForSeconds(1f);
            attackedSensor.Func_IsAttackedable(true);
        }

        #endregion

        #region 전투 관련 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-29 </para>
        /// <para> 내    용 : 일반 공격 기능 </para>
        /// </summary>
        private void Func_Attack_Nomal()
        {
            anim.SetTrigger("Attack");
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-05 </para>
        /// <para> 내    용 : 피격당했을 때 호출 기능 </para>
        /// </summary>
        public void Func_Attacked(float _percent)
        {
            slider_HP.value = _percent;

            if (_percent <= 0)
            {
                DR_Debug.Func_Log("DIE");
                isDie = true;
            }
        }

        public void Func_Boom()
        {
            moveX = -5f;
            m_rigidbody.AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);
        }

        #endregion

        #region 버프 관련 메서드

        public void Func_Resurrection()
        {
            isDie = false;
            playerAbility.Func_Resurrection();
            slider_HP.value = 1f;
            StartCoroutine(Co_AttackSensorColliderTimmer());       // 일정시간 후에 플레이어 피격 센서 켜기
        }

        #endregion

    }
}