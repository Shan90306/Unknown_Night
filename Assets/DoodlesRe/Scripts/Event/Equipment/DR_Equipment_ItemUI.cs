using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-25 </para>
    /// <para> 내    용 : 장비창의 인벤토리 버튼을 담당하는 클래스 </para>
    /// </summary>
    public class DR_Equipment_ItemUI : MonoBehaviour
    {
        [Header("- 인벤토리")]
        [SerializeField] private DR_Equipment_Inventory inventory;

        [Header("- 이름 텍스트")]
        [SerializeField] private Text text_name;

        [Header("- 이름 이미지")]
        [SerializeField] private Image image_BG;

        private int itemID;                         // 아이템 UI의 아이템 아이디

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-25 </para>
        /// <para> 내    용 : 아이템의 아이디로 이름을 설정하는 기능 </para>
        /// </summary>
        public void Func_SetName(int _id, DR_Equipment_Inventory _inventory)
        {
            image_BG.color = Color.white;
            inventory = _inventory;
            itemID = _id;
            text_name.text = DR_ProgramManager.Instance.Func_GetItem(itemID)[DR_PathDefine.CSV_Key_ItemName].ToString();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-06 </para>
        /// <para> 내    용 : 아이템UI가 장착된 아이템일 때 색 변경 </para>
        /// </summary>
        public void Func_Equipment()
        {
            image_BG.color = Color.red;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-25 </para>
        /// <para> 내    용 : 아이템 UI를 클릭했을 때 아이템의 능력치를 보여주는 UI 활성화 </para>
        /// </summary>
        public void Button_SetWatchEquipment()
        {
            inventory.Func_SetEquipmentUI(itemID);
        }
    }
}