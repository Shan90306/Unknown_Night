using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-02 </para>
    /// <para> 내    용 : 플레이어의 스텟, 스킬을 가지고 있는 클래스 </para>
    /// </summary>
    public class DR_PlayerAbility : DR_Character
    {
        [Header("- 플레이어 능력")]
        [SerializeField] private int currentHP;     // 현재 HP
        public int CurrentHP
        {
            get
            {
                return currentHP;
            }
        }

        [Header("- 플레이어 세팅")]
        [SerializeField] private SpriteRenderer sprite_Weapon;      // 무기 스프라이트 렌더러

        private DR_PlayerController m_playerController;     // 플레이어 컨트롤러 캐싱

        private void Start()
        {
            Func_InitSetting();      // 플레이어 설정
        }

        #region 상속받은 기능 (아직 개발X)

        protected override void Func_TriggerOn(Collider2D _coll) { }

        #endregion

        #region 초기 설정 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-02 </para>
        /// <para> 내    용 : 전투에 필요한 플레이어의 능력을 설정하는 기능 </para>
        /// </summary>
        private void Func_InitSetting()
        {
            status = DR_PlayerManager.Instance.detailStatus;            // 스텟 설정
            currentHP = status.hp;                                      // 현재 HP 설정
            m_playerController = GetComponent<DR_PlayerController>();   // 플레이어 컨트롤러 캐싱
            Func_InitWeapon();                                          // 무기 이미지 설정
        }

        private void Func_InitWeapon()
        {
            int _weaponID = int.Parse(DR_PlayerManager.Instance.wearingEquipment.weapon);
            sprite_Weapon.sprite = DR_ScriptableManager.Instance.Func_GetScriptable<DR_Setting_Item>().Func_GetIDImage(_weaponID);
        }

        #endregion

        #region 전투 관련 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-04 </para>
        /// <para> 내    용 : 공격당했을 때 호출 </para>
        /// </summary>
        public override void Func_Attacked(int _damage)
        {
            if (currentHP > 0)
            {
                Func_CulculateDamage(_damage);                  // 데미지 계산
                DR_Debug.Func_Log("공격당함 : " + _damage);
            }
        }



        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-04 </para>
        /// <para> 내    용 : 데미지에 따라 HP 설정 </para>
        /// </summary>
        private void Func_CulculateDamage(int _damage)
        {
            int _realDamage = DR_Formula.Func_BattleDamage(_damage, status.defensivePoint);
            currentHP -= _realDamage;

            // HP가 0 이하로 떨어지면 0으로 고정
            if (currentHP < 0)
            {
                currentHP = 0;
            }

            float _percent = currentHP / (float)status.hp;
            m_playerController.Func_Attacked(_percent);
        }



        #endregion

        #region 버프 기능

        public void Func_Resurrection()
        {
            currentHP = status.hp;
        }

        #endregion

    }
}