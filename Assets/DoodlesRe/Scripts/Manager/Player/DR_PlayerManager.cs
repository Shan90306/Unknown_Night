using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-24 </para>
    /// <para> 내    용 : 플레이어를 담당하는 클래스 </para>
    /// </summary>
    public class DR_PlayerManager : DR_Singlton<DR_PlayerManager>
    {
        [Header("- 플레이어 스텟")]
        public DR_DefineStatus status;

        [Header("- 플레이어 착용 장비")]
        public DR_WearingEquipment wearingEquipment;

        protected override void Func_Init()
        {
            DontDestroyOnLoad(gameObject);
        }

        #region 기능들

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-24 </para>
        /// <para> 내    용 : 플레이어를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetPlayer()
        {
            Func_SetStatus();               // 스텟 설정
            Func_SetWearingEquipment();     // 장비 설정
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-24 </para>
        /// <para> 내    용 : 플레이어의 스텟을 설정하는 기능 </para>
        /// </summary>
        private void Func_SetStatus()
        {
            status = DR_XML.Instance.Func_GetLoadStatus(DR_ProgramManager.Instance.playSlotNum);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-24 </para>
        /// <para> 내    용 : 플레이어의 장비를 설정하는 기능 </para>
        /// </summary>
        private void Func_SetWearingEquipment()
        {
            wearingEquipment = DR_XML.Instance.Func_GetLoadWearingEquipment(DR_ProgramManager.Instance.playSlotNum);
        }

        #endregion
    }
}