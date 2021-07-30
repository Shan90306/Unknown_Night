using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-07-27 </para>
    /// <para> 내    용 : 플레이어 캐릭터가 바닥에 닿았는지 체크하는 클래스 </para>
    /// </summary>
    public class DR_PlayerGroundSensor : MonoBehaviour
    {
        [Header("- 플레이어")]
        [SerializeField] private DR_PlayerController player;

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Ground") || other.CompareTag("Block"))
            {
                if (other.CompareTag("Ground"))
                {
                    player.isDownJumpGroundCheck = true;
                }
                else
                {
                    player.isDownJumpGroundCheck = false;
                }

                if (player.m_rigidbody.velocity.y <= 0.5f)
                {
                    player.isGround = true;
                    player.currentJumpCount = 0;
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            player.isGround = false;
        }
    }
}