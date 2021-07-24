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

        [Header("- 스킬의 현재 레벨 텍스트")]
        [SerializeField] private Text text_NowSkillLevel;

        [Header("- 스킬의 다음 레벨 텍스트")]
        [SerializeField] private Text text_NextSkillLevel;

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

            Func_UpdateSkillAbility();

            gameObject.SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-23 </para>
        /// <para> 내    용 : 스킬의 능력을 업데이트하는 기능 </para>
        /// </summary>
        private void Func_UpdateSkillAbility()
        {
            text_NowSkillLevel.text = amuletSP.skillPoint[(int)skill_Amulet].ToString();        // 스킬의 현재레벨 텍스트
            if (amuletSP.skillPoint[(int)skill_Amulet] < 3) // 스킬의 현재 레벨이 3 미만이면
            {
                text_NextSkillLevel.transform.parent.gameObject.SetActive(true);                    // 다음레벨 텍스트 활성화
                text_NextSkillLevel.text = (amuletSP.skillPoint[(int)skill_Amulet] + 1).ToString(); // 다음레벨 텍스트 +1
            }
            else
            {
                // 스킬의 현재레벨 텍스트
                text_NowSkillLevel.text = amuletSP.skillPoint[(int)skill_Amulet].ToString() + " (Master)";   
                text_NextSkillLevel.transform.parent.gameObject.SetActive(false);
            }
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
                if (amuletSP.skillPoint[(int)skill_Amulet] < 3)
                {
                    DR_Debug.Func_Log("배우기");
                    amuletSP.skillPoint[(int)skill_Amulet]++;       // 스킬의 SP  +1
                    DR_PlayerManager.Instance.sp--;                 // 플레이어의 SP -1
                    skill.Func_SetSkillUI((int)skill_Amulet);       // 스킬 UI 설정

                    Func_UpdateSkillAbility();                      // UI 업데이트
                }
                else
                {
                    DR_Debug.Func_Log("스킬레벨 최대치");
                }
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