using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-20 </para>
    /// <para> 내    용 : 장비창 클래스 </para>
    /// </summary>
    public class DR_Equipment : DR_Info
    {
        [Header("- 클릭한 장비")]
        [SerializeField] private EQUIPMENT_KIND clickEquipment;

        [Header("- 선택 장비 라인")]
        [SerializeField] private GameObject line;

        [Header("- 오른쪽 페이지")]
        [SerializeField] private GameObject rightPage;


        [Header("- 착용하고 있는 장비의 텍스트 배열")]
        [Header("UI"), Space(20)]
        [SerializeField] private Text[] wornEquipmentArr;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-20 </para>
        /// <para> 내    용 : 장비창을 초기화 하는 기능 </para>
        /// </summary>
        private void Func_ResetEquipment()
        {
            line.SetActive(false);
            rightPage.SetActive(false);
        }

        public override void Func_SetEnable()
        {
            gameObject.SetActive(true);
        }

        public override void Func_Close()
        {
            gameObject.SetActive(false);
            Func_ResetEquipment();          // 초기화
        }

        #region 착용한 장비를 설정하는 기능



        #endregion

        #region Button 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-20 </para>
        /// <para> 내    용 : 장착할 장비템을 클릭했을 때 호출 </para>
        /// </summary>
        public void Button_ClickWorn(int _clickNum)
        {
            clickEquipment = (EQUIPMENT_KIND)_clickNum;
            rightPage.SetActive(true);
        }

        #endregion

    }
}