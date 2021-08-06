using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-04 </para>
    /// <para> 내    용 : 공격을 당했는지 체크하는 기능</para>
    /// </summary>
    public class DR_AttackSensor : MonoBehaviour, DR_IAttack
    {
        [Header("- 몸체")]
        [SerializeField] private DR_Character character;

        [Header("- 피격 후 다음 피격까지의 시간")]
        [SerializeField] private float attackedTime;

        public bool isAttackedable = true;                   // 피격 가능한지 체크
        private IEnumerator coAttackedCoolTime;

        // 공격 당했을 때 호출
        public void Func_Attack(int _damage)
        {
            if (isAttackedable)
            {
                character.Func_Attacked(_damage);
                coAttackedCoolTime = Co_AttackedCoolTime();          // 무적시간 설정
                StartCoroutine(coAttackedCoolTime);
            }
            else
            {
                DR_Debug.Func_Log("피격 쿨타임");
            }
        }

        public void Func_IsAttackedable(bool _isAble)
        {
            if (!_isAble)
            {
                StopCoroutine(coAttackedCoolTime);
                isAttackedable = false;
            }
            else
            {
                isAttackedable = true;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-04 </para>
        /// <para> 내    용 : 공격당하고 일정시간동안 피격 안되게 하는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_AttackedCoolTime()
        {
            isAttackedable = false;
            yield return new WaitForSecondsRealtime(attackedTime);

            isAttackedable = true;
        }
    }
}