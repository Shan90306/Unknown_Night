using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-20 </para>
    /// <para> 내    용 : 장비창 클래스 </para>
    /// </summary>
    public class DR_Equipment : MonoBehaviour
    {
        [Header("- 클릭한 장비")]
        [SerializeField] private EQUIPMENT_KIND clickEquipment;

        [Header("- 선택 장비 라인")]
        [SerializeField] private GameObject line;

        [Header("- 오른쪽 페이지")]
        [SerializeField] private GameObject rightPage;

        private void Func_Init()
        {
            line.SetActive(false);
            rightPage.SetActive(false);
        }

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