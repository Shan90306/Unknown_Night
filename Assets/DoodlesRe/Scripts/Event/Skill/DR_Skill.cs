using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020-07-06 </para>
    /// <para> 내    용 : 스킬창에 대한 클래스 </para>
    /// </summary>
    public class DR_Skill : DR_Info
    {
        [Header("- 플레이어 스킬")]
        public DR_PlayerSellectSkill skill;

        [Header("- 부적 배열")]
        [SerializeField] private Button[] amulletArr;

        [Header("- 부적 부모")]
        [SerializeField] private Transform amulletParent;

        [Header("- 부적 위치 배열")]
        [SerializeField] private Transform[] amulletPosArr;

        [Header("- 스킬UI 배열")]
        [SerializeField] private DR_SkillUI[] skillUIArr;

        #region 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-08 </para>
        /// <para> 내    용 : 스킬 UI를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetSkillUI(int _amuletNum)
        {
            for (int i = 0; i < skillUIArr.Length; i++)
            {
                skillUIArr[i].Func_SetSkillUIImage(_amuletNum);
            }
        }

        #endregion

        #region Button 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-07 </para>
        /// <para> 내    용 : 클릭한 부적을 가장 위로 끌어올리는 기능 </para>
        /// </summary>
        public void Button_ClickAmulet(int _num)
        {
            skill.skill_Amulet = (SKILL_AMULET)_num;
            amulletArr[_num].transform.position = amulletPosArr[0].position;

            for (int i = 1; i < 3; i++)
            {
                amulletArr[(_num + i) % 3].transform.position = amulletPosArr[i].position;
            }

            Func_SetSkillUI(_num);
        }
             
        #endregion
    }
}