using System.Collections;
using System.Collections.Generic;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-04 </para>
    /// <para> 내    용 : 게임에 필요한 공식을 가지고 있는 기능</para>
    /// </summary>
    public class DR_Formula
    {
        #region 전투 관련 공식

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-04 </para>
        /// <para> 내    용 : 플레이어를 타격했을 때 </para>
        /// </summary>
        public static int Func_BattleDamage(int _attackPower, int _defencePoint)
        {
            // 공격자 공격력 - 피격자 방어력
            int _damage =  _attackPower - _defencePoint;

            if (_damage < 0)
            {
                _damage = 0;
            }
            return _damage;
        }

        #endregion
    }
}