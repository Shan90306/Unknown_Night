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

        [Header("- 장비 능력치 UI")]
        [SerializeField] private DR_EquipmentUI equipmentUI;

        [Header("- 아이템 UI가 생성될 트랜스폼")]
        [SerializeField] private DR_ScrollView inventoryView;

        [Header("- 아이템 UI")]
        [SerializeField] private GameObject itemUI;

        [Header("- 오브젝트 풀")]
        [SerializeField] private DR_ObjectPool objectPool;

        public bool asd;

        private Dictionary<int, int> itemDic;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-25 </para>
        /// <para> 내    용 : 소지한 아이템 아이디 딕셔너리를 받아서 해당 개수만큼 인벤토리 활성화 </para>
        /// </summary>
        public void Func_SetInventory(int _inventoryNum)
        {
            if (_inventoryNum == 0)
            {
                kind = EQUIPMENT_KIND.Weapon;
            }
            else
            {
                kind = (EQUIPMENT_KIND)_inventoryNum + 2;
            }

            Func_DisableInventoryView();
            StartCoroutine(Co_SetInventory());
        }

        private IEnumerator Co_SetInventory()
        {
            int _num = 0;

            if (itemDic == null)
            {
                // 초기 설정
                itemDic = DR_XML.Instance.Func_GetLoadItem(DR_ProgramManager.Instance.playSlotNum);
            }

            if (asd)
            {
                foreach (var _item in itemDic)
                {
                    Dictionary<string, object> _dic = DR_ProgramManager.Instance.Func_GetItem(_item.Key);
                    int _type = int.Parse(_dic[DR_PathDefine.CSV_Key_ItemType].ToString());

                    if (kind == EQUIPMENT_KIND.Weapon)
                    {
                        if (_type < 3)
                        {
                            Func_SetItemUI(_item, _dic);
                        }
                    }
                    else
                    {
                        if (_type == (int)kind)
                        {
                            Func_SetItemUI(_item, _dic);
                        }
                    }

                    if (++_num > 10)
                    {
                        _num = 0;
                        yield return null;
                    }
                }

            }
            inventoryView.Func_SetRect();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-01 </para>
        /// <para> 내    용 : 인벤토리를 모두 비활성화 하는 기능 </para>
        /// </summary>
        private void Func_DisableInventoryView()
        {
            List<Transform> _list = new List<Transform>();
            foreach (Transform _item in inventoryView.transform)
            {
                _list.Add(_item);
            }

            for (int i = 0; i < _list.Count; i++)
            {
                objectPool.Func_ReturnOBJ(_list[i].gameObject);     // 오브젝트 풀에 넣기
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-01 </para>
        /// <para> 내    용 : 아이템 UI를 설정하는 기능 </para>
        /// </summary>
        private void Func_SetItemUI(KeyValuePair<int, int> _item, Dictionary<string, object> _dic)
        {
            for (int i = 0; i < _item.Value; i++)
            {
                DR_Equipment_ItemUI _itemUI = objectPool.Func_GetObject(inventoryView.transform).GetComponent<DR_Equipment_ItemUI>();
                _itemUI.Func_SetName(int.Parse(_dic[DR_PathDefine.CSV_Key_ItemID].ToString()), this);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-29 </para>
        /// <para> 내    용 : 해당 장비의 능력치를 보여주는 UI 활성화 </para>
        /// </summary>
        public void Func_SetEquipmentUI(int _id)
        {
            DR_Debug.Func_Log("능력치 보여주기 : " + _id);
        }
    }
}