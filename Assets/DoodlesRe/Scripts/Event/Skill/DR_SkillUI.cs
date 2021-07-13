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
        [SerializeField] private int[] spUpgradeArr;

        [Header("- 부적 별 스킬 SP 업그레이드 배열")]
        [SerializeField] private int nosSkillSP;

        private void Start()
        {
            Func_SetAmuletSkillSP();     // 부적 별 스킬의 SP 업그레이드 설정
        }

        #region 기능들

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-13 </para>
        /// <para> 내    용 : 부적 별 스킬의 SP 업그레이드 설정 </para>
        /// </summary>
        private void Func_SetAmuletSkillSP()
        {
            Dictionary<int, int> _dic = DR_XML.Instance.Func_GetLoadSkill((int)kind);
            int _num = 0;
            foreach (var _item in _dic)
            {
                spUpgradeArr[_num++] = _item.Value;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-12 </para>
        /// <para> 내    용 : 현재 부적의 스킬을 설정 </para>
        /// </summary>
        public void Func_SetSkillUIImage(int _amuletNum)
        {
            image_skill.sprite = skillSpriteArr[_amuletNum];

            if (spUpgradeArr[_amuletNum] != 0)
            {
                // 현재 스킬의 테두리 설정
                image_skillFrame.sprite = frameSpriteArr[_amuletNum];
            }
            else
            {
                clickDefender.SetActive(true);
            }
        }


        #endregion

        #region Button 메서드

        public void Button_ClickSkillUI()
        {

        }

        #endregion
    }
}