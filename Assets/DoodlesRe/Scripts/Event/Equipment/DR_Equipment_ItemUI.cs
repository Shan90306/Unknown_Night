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
        [Header("- 이름 텍스트")]
        [SerializeField] private DR_Equipment_Inventory inventory;

        [Header("- 이름 텍스트")]
        [SerializeField] private Text text_name;

        private int itemID;

        public void Func_SetName(int _id, DR_Equipment_Inventory _inventory)
        {
            inventory = _inventory;
            itemID = _id;
            text_name.text = DR_ProgramManager.Instance.Func_GetItem(itemID)[DR_PathDefine.CSV_Key_ItemName].ToString();
        }

        public void Button_SetWatchEquipment()
        {
            inventory.Func_SetEquipmentUI(itemID);
        }
    }
}