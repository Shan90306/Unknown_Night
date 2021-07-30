using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-07-30 </para>
    /// <para> 내    용 : 플레이어 캐릭터가 벽에 붙었는지 체크하는 클래스 </para>
    /// </summary>
    public class DR_PlayerWallSensor : MonoBehaviour
    {
        [Header("- 플레이어")]
        [SerializeField] private DR_PlayerController player;

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                player.isWall = true;
            }
        }
        void OnTriggerExit2D(Collider2D other)
        {
            player.isWall = false;
        }
    }
}