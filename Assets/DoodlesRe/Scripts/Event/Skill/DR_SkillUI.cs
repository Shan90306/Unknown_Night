using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020-07-08 </para>
    /// <para> 내    용 : 스킬 UI의 클래스 </para>
    /// </summary>
    public class DR_SkillUI : MonoBehaviour
    {
        [Header("- 스킬 스크립트")]
        [SerializeField] private DR_Skill skill;

        [Header("- 스킬 종류")]
        [SerializeField] private SKILL_KIND kind;

        [Header("- 스킬 테두리 이미지")]
        [SerializeField] private Image image_skillFrame;

        [Header("- 스킬 이미지")]
        [SerializeField] private Image image_skill;

        [Header("- 스킬 이미지 배열")]
        [SerializeField] private Sprite[] skillSpriteArr;

        [Header("- 테두리 이미지 배열")]
        [SerializeField] private Sprite[] frameSpriteArr;

        [Header("- 스킬 클릭 못하게 하는 오브젝트")]
        [SerializeField] private GameObject clickDefender;      // SP가 0이거나 하위스킬 마스터가 아닐때 활성화

        [Header("- 부적 별 스킬 SP 업그레이드 배열")]
        [SerializeField] private DR_SkillPoint amuletSkillPoint;

        [Header("- 현재 부적 스킬의 SP")]
        [SerializeField] private int nowSkillSP;

        [Header("- 하위스킬인지 체크")]
        [SerializeField] private bool isLowSkill;

        private bool isUpgradeable;         // 하위 스킬이 마스터가 되어있어서 배울 수 있는지 체크

        //private void Start()
        //{
        //    Func_SetAmuletSkillSP();     // 부적 별 스킬의 SP 업그레이드 설정
        //}

        #region 기능들

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-13 </para>
        /// <para> 내    용 : 부적 별 스킬의 SP 업그레이드 설정 </para>
        /// </summary>
        public void Func_SetAmuletSkillSP(DR_SkillPoint _sp)
        {
            amuletSkillPoint = _sp;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-12 </para>
        /// <para> 내    용 : 현재 부적의 스킬을 설정 </para>
        /// </summary>
        public void Func_SetSkillUIImage(int _amuletNum)
        {
            image_skill.sprite = skillSpriteArr[_amuletNum];
            nowSkillSP = amuletSkillPoint.skillPoint[_amuletNum];

            if (nowSkillSP != 0)
            {
                // 현재 스킬의 테두리 설정
                image_skillFrame.sprite = frameSpriteArr[nowSkillSP - 1];
            }
            else
            {
                image_skillFrame.sprite = frameSpriteArr[0];
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-15 </para>
        /// <para> 내    용 : 현재 부적의 스킬의 마스터 유무 </para>
        /// </summary>
        public bool Func_IsSkillMaster()
        {
            return nowSkillSP == 3;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-15 </para>
        /// <para> 내    용 : 스킬을 잠가야 하는지 체크 </para>
        /// </summary>
        public void Func_SetSkillLock(bool _isLock)
        {
            if (!isLowSkill)
            {
                // 상위스킬일 때
                if (!_isLock)
                {
                    isUpgradeable = false;
                    clickDefender.SetActive(true);
                }
                else
                {
                    isUpgradeable = true;
                    clickDefender.SetActive(false);
                }
            }
            else
            {
                // 하위스킬이면 언제든지 업그레이드 가능
                isUpgradeable = true;
            }
        }

        #endregion

        #region Button 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-15 </para>
        /// <para> 내    용 : 스킬 UI를 클릭했을 때 호출 </para>
        /// </summary>
        public void Button_ClickSkillUI()
        {
            skill.Func_SetUpgradeUI(kind, amuletSkillPoint, isUpgradeable);
        }

        #endregion
    }
}