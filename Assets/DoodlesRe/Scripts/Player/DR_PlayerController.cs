using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        [SerializeField] private int moveSpeed;     // 캐릭터 스피드
        [SerializeField] private int maxJumpCount;  // 최대 점프 횟수
        [SerializeField] private int jumpForce;     // 점프 파워

        [Header("- 캐릭터 캐싱")]
        [SerializeField] private Animator anim;     // 애니메이터
        public Rigidbody2D m_rigidbody;             // 강체 캐싱
        public CapsuleCollider2D m_CapsulleCollider;   // 플레이어 콜라이더 캐싱

        [HideInInspector] public int currentJumpCount;          // 현재 점프 숫자
        [HideInInspector] public bool isGround;                 // 
        [HideInInspector] public bool isDownJumpGroundCheck;    // 현재 밑이 블럭인지 땅인지 체크

        private float moveX;
        private bool isSit;
        private bool isDie;
        private bool isAttack;

        // Update is called once per frame
        void Update()
        {
            Func_InputCheck();
        }

        #region 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-28 </para>
        /// <para> 내    용 : 입력 체크하여 해당하는 행동을 하게 하는 기능 </para>
        /// </summary>
        private void Func_InputCheck()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))  //아래 버튼 눌렀을때
            {
                anim.Play("Sit");
                isSit = true;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow)) //아래 버튼 뗐을 때
            {
                anim.Play("Idle");
                isSit = false;
            }

            if (isSit || isDie)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !isDie)
                {
                    if (currentJumpCount < maxJumpCount)
                    {
                        Func_DownJump();
                    }
                }
                return;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (isGround)
                {
                    if (isAttack)
                    {
                        return;
                    }

                    moveX = -1;
                }
                else
                {
                    moveX = Input.GetAxis("Horizontal");
                }

                Func_Flip(true);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (isGround)
                {
                    if (isAttack)
                    {
                        return;
                    }

                    moveX = 1;
                }
                else
                {
                    moveX = Input.GetAxis("Horizontal");
                }

                Func_Flip(false);
            }
            else
            {
                if (isGround)
                {
                    if (isAttack)
                    {
                        return;
                    }

                    moveX = 0;
                }
                else
                {
                    moveX = Input.GetAxis("Horizontal");
                }
            }

            //moveX = Input.GetAxis("Horizontal");
            if (!isAttack)
            {
                if (moveX == 0)
                {
                    anim.Play("Idle");
                }
                else
                {
                    anim.Play("Run");

                }
            }

            if (isGround)
            {
                if (isAttack)
                {
                    return;
                }

                transform.Translate(Vector2.right * moveX * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector3(moveX * moveSpeed * Time.deltaTime, 0, 0));
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isAttack)
                {
                    return;
                }

                if (currentJumpCount < maxJumpCount)
                {
                    if (isSit)
                    {
                        Func_DownJump();
                    }
                    else
                    {
                        Func_Jump();
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DR_Debug.Func_Log("테스트 죽기");
                anim.Play("Die");
            }
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

            anim.Play("Jump");
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
                anim.Play("Jump");

                isGround = false;

                m_CapsulleCollider.enabled = false;
                m_rigidbody.AddForce(-Vector2.up * 10);
                StartCoroutine(Co_GroundColliderTimmerFuc());
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-28 </para>
        /// <para> 내    용 : 밑으로 점프할 때 잠깐의 시간후 플레이어의 콜라이더를 켜는 코루틴 기능 </para>
        /// </summary>
        IEnumerator Co_GroundColliderTimmerFuc()
        {
            yield return new WaitForSeconds(0.3f);
            m_CapsulleCollider.enabled = true;
        }

        #endregion
    }
}