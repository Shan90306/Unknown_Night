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
        [Header("- 선택 장비 라인")]
        [SerializeField] private GameObject line;

        [Header("- 오른쪽 페이지")]
        [SerializeField] private GameObject rightPage;


        [Header("- 착용하고 있는 장비의 텍스트 배열")]
        [Header("UI"), Space(20)]
        [SerializeField] private Text[] wornEquipmentArr;

        [Header("- 착용중인 아이템 UI")]
        [SerializeField] private DR_EquipmentUI wearingEquipment;

        [Header("- 착용중인 아이템 UI")]
        [SerializeField] private DR_Equipment_Inventory[] inventoryArr;

        private Dictionary<int, int> itemDic;
        private string[] wearingEqipArr = new string[5];

        #region 상속 메서드

        protected override void Func_Init()
        {
            base.Func_Init();
            Func_ResetEquipment();

            itemDic = DR_XML.Instance.Func_GetLoadItem(DR_ProgramManager.Instance.playSlotNum);

            DR_WearingEquipment _wearingEquipment = DR_PlayerManager.Instance.wearingEquipment;
            if (_wearingEquipment != null)
            {
                Func_SetWearingEquipment(0, _wearingEquipment.weapon);
                Func_SetWearingEquipment(1, _wearingEquipment.ring);
                Func_SetWearingEquipment(2, _wearingEquipment.necklace);
                Func_SetWearingEquipment(3, _wearingEquipment.wristband);
                Func_SetWearingEquipment(4, _wearingEquipment.amulet);

                wearingEqipArr[0] = _wearingEquipment.weapon;
                wearingEqipArr[1] = _wearingEquipment.ring;
                wearingEqipArr[2] = _wearingEquipment.necklace;
                wearingEqipArr[3] = _wearingEquipment.wristband;
                wearingEqipArr[4] = _wearingEquipment.amulet;
            }
        }

        #endregion

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

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-25 </para>
        /// <para> 내    용 : 장착한 아이템의 코드로 이름을 가져와서 텍스트 출력 </para>
        /// </summary>
        private void Func_SetWearingEquipment(int _textNum, string _id)
        {
            if (_id != string.Empty)
            {
                wornEquipmentArr[_textNum].text = DR_ProgramManager.Instance.Func_GetItem(int.Parse(_id))
                    [DR_PathDefine.CSV_Key_ItemName].ToString();
            }
            else
            {
                wornEquipmentArr[_textNum].text = string.Empty;
            }
        }

        #endregion

        #region Button 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-20 </para>
        /// <para> 내    용 : 장착할 장비템을 클릭했을 때 호출 </para>
        /// </summary>
        public void Button_ClickWorn(int _clickNum)
        {
            rightPage.SetActive(true);

            // 착용한 아이템 능력 UI 설정
            if (wearingEqipArr[_clickNum] != string.Empty)
            {
                wearingEquipment.Func_SetEquipmentUI(int.Parse(wearingEqipArr[_clickNum]));
            }
            else
            {
                wearingEquipment.gameObject.SetActive(false);
            }

            // 해당 인벤토리 설정
            inventoryArr[_clickNum].Func_SetInventory(itemDic);
        }

        #endregion

    }
}