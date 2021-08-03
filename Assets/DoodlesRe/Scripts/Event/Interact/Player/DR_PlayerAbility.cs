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
        [Header("- 플레이어 세팅")]
        [SerializeField] private SpriteRenderer sprite_Weapon;      // 무기 스프라이트 렌더러

        private void Start()
        {
            Func_InitSetting();      // 플레이어 설정
        }

        #region 기능들

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-02 </para>
        /// <para> 내    용 : 전투에 필요한 플레이어의 능력을 설정하는 기능 </para>
        /// </summary>
        private void Func_InitSetting()
        {
            status = DR_PlayerManager.Instance.detailStatus;        // 스텟 설정
            Func_InitWeapon();      // 무기 이미지 설정

        }

        private void Func_InitWeapon()
        {
            int _weaponID = int.Parse(DR_PlayerManager.Instance.wearingEquipment.weapon);
            sprite_Weapon.sprite = DR_ScriptableManager.Instance.Func_GetScriptable<DR_Setting_Item>().Func_GetIDImage(_weaponID);
        }


        #endregion
    }
}