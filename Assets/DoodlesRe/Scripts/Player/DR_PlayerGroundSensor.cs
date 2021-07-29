using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{

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

                if (player.m_rigidbody.velocity.y <= 0)
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