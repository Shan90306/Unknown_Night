using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-04 </para>
    /// <para> 내    용 : 데미지를 주는 공격 기능</para>
    /// </summary>
    public class DR_AttackAbility : MonoBehaviour
    {
        [Header("- SETTING")]
        [SerializeField] private int damage;

        private void OnTriggerEnter2D(Collider2D _coll)
        {
            if (_coll.CompareTag("Ground") || _coll.CompareTag("Block") || _coll.CompareTag("Wall"))
            {
                DR_Debug.Func_Log("벽이나 땅에 닿음");
            }
            else
            {
                _coll.GetComponent<DR_AttackSensor>()?.Func_Attack(damage);
            }
        }
    }
}