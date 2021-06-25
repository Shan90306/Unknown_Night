using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-25 </para>
    /// <para> 내    용 : 장비창의 인벤토리를 담당하는 클래스 </para>
    /// </summary>
    public class DR_Equipment_Inventory : MonoBehaviour
    {
        [Header("- 인벤토리에 표시할 장비 종류")]
        [SerializeField] private EQUIPMENT_KIND kind;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-25 </para>
        /// <para> 내    용 :  </para>
        /// </summary>
        public void Func_SetInventory(Dictionary<int, int> itemDic)
        {
            foreach (var item in itemDic)
            {
                Dictionary<string, object> _dic = DR_ProgramManager.Instance.Func_GetItem(item.Key);
                int _type = int.Parse(_dic[DR_PathDefine.CSV_Key_ItemType].ToString());
                
                // 무기 인벤토리일 때
                if (kind == EQUIPMENT_KIND.Sword || kind == EQUIPMENT_KIND.Spear || kind == EQUIPMENT_KIND.Axe)
                {
                    if (_type < 3)
                    {

                    }
                }
                else
                {

                }
            }
        }
    }
}