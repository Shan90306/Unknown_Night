using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020-07-15 </para>
    /// <para> 내    용 : 스킬 업그레이드 UI에 대한 클래스 </para>
    /// </summary>
    public class DR_SkillUpgradeUI : DR_Info
    {
        [Header("- 스킬 스크립트")]
        [SerializeField] private DR_Skill skill;

        [Header("- 스킬 이름 텍스트")]
        [SerializeField] private Text text_SkillName;

        [Header("- 스킬 설명 텍스트")]
        [SerializeField] private Text text_SkillExplanation;

        [Header("- 배우기 버튼")]
        [SerializeField] private Button button_Learn;

        private DR_SkillPoint amuletSP;
        private SKILL_AMULET skill_Amulet;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-15 </para>
        /// <para> 내    용 : 업그레이드 UI를 현재 클릭한 스킬에 맞게 설정하는 기능 </para>
        /// </summary>
        public void Func_SetSkillAbility(SKILL_AMULET _skill_Amulet, SKILL_KIND _skillKind, DR_SkillPoint _sp, bool _isUpgradeable)
        {
            text_SkillName.text = _skill_Amulet.ToString() + "의 " + _skillKind;

            skill_Amulet = _skill_Amulet;
            amuletSP = _sp;
            button_Learn.interactable = _isUpgradeable;     // 배우기 버튼 활성화 여부

            gameObject.SetActive(true);
        }


        #region Button 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-15 </para>
        /// <para> 내    용 : 스킬을 배우는 버튼을 클릭했을 때 호출 </para>
        /// </summary>
        public void Button_ClickLearn()
        {
            if (DR_PlayerManager.Instance.sp > 0)
            {
                DR_Debug.Func_Log("배우기");
                amuletSP.skillPoint[(int)skill_Amulet]++;
                DR_PlayerManager.Instance.sp--;
            }
            else
            {
                DR_Debug.Func_Log("SP 부족!");
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-15 </para>
        /// <para> 내    용 : 스킬을 배우는 버튼을 클릭했을 때 호출 </para>
        /// </summary>
        public override void Func_Close()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}