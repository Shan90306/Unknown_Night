using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{

    public class DR_CheckPlayer : MonoBehaviour
    {
        [Header("- 몬스터")]
        [SerializeField] private DR_Monster monster;

        private void OnTriggerEnter2D(Collider2D _coll)
        {
            if (_coll.CompareTag("Player"))
            {
                monster.Func_FollowPlayer(_coll.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D _coll)
        {
            if (_coll.CompareTag("Player"))
            {
                monster.Func_ExitPlayer();
            }
        }
    }
}