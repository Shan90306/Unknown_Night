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

        [Header("- 아이템 인벤토리")]
        [SerializeField] private DR_Equipment_Inventory inventory;

        [Header("- 인벤토리 아이템 장착 버튼 배열")]
        [SerializeField] private GameObject[] inventoryButtonArr;

        private Dictionary<int, int> itemDic;
        private string[] wearingEqipArr = new string[5];

        #region 상속 메서드

        protected override void Func_Init()
        {
            base.Func_Init();
            Func_ResetEquipment();                  // 장비창 초기화
            Func_SetWearingEquipment();             // 착용 장비 설정
            //StartCoroutine(Co_SetInventory());      // 인벤토리 설정
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

        #region 인벤토리 설정

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-06 </para>
        /// <para> 내    용 : 특정 부위의 아이템을 장착하는 기능 </para>
        /// </summary>
        public void Func_SetEquipmentPart(int _partNum, string _id)
        {
            switch (_partNum)
            {
                case 0:
                    DR_PlayerManager.Instance.wearingEquipment.weapon = _id;
                    break;

                case 1:
                    DR_PlayerManager.Instance.wearingEquipment.ring = _id;
                    break;

                case 2:
                    DR_PlayerManager.Instance.wearingEquipment.necklace = _id;
                    break;

                case 3:
                    DR_PlayerManager.Instance.wearingEquipment.wristband = _id;
                    break;

                case 4:
                    DR_PlayerManager.Instance.wearingEquipment.amulet = _id;
                    break;
            }
            Func_ResetEquipment();                  // 장비창 초기화
            Func_SetWearingEquipment(_partNum);     // 특정 부위 설정
        }
        
        #endregion

        #region 착용한 장비를 설정하는 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-25 </para>
        /// <para> 내    용 : 장착한 아이템을 설정 </para>
        /// </summary>
        private void Func_SetWearingEquipment()
        {
            DR_WearingEquipment _wearingEquipment = DR_PlayerManager.Instance.wearingEquipment;
            if (_wearingEquipment != null)
            {
                Func_SetWearingEquipment_Text(0, _wearingEquipment.weapon);
                Func_SetWearingEquipment_Text(1, _wearingEquipment.ring);
                Func_SetWearingEquipment_Text(2, _wearingEquipment.necklace);
                Func_SetWearingEquipment_Text(3, _wearingEquipment.wristband);
                Func_SetWearingEquipment_Text(4, _wearingEquipment.amulet);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-06 </para>
        /// <para> 내    용 : 특정 부위 장착한 아이템 설정 </para>
        /// </summary>
        private void Func_SetWearingEquipment(int _partNum)
        {
            DR_WearingEquipment _wearingEquipment = DR_PlayerManager.Instance.wearingEquipment;
            if (_wearingEquipment != null)
            {
                switch (_partNum)
                {
                    case 0:
                        Func_SetWearingEquipment_Text(0, _wearingEquipment.weapon);
                        break;

                    case 1:
                        Func_SetWearingEquipment_Text(1, _wearingEquipment.ring);
                        break;

                    case 2:
                        Func_SetWearingEquipment_Text(2, _wearingEquipment.necklace);
                        break;

                    case 3:
                        Func_SetWearingEquipment_Text(3, _wearingEquipment.wristband);
                        break;

                    case 4:
                        Func_SetWearingEquipment_Text(4, _wearingEquipment.amulet);
                        break;
                }
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-25 </para>
        /// <para> 내    용 : 장착한 아이템의 코드로 이름을 가져와서 텍스트 출력 </para>
        /// </summary>
        private void Func_SetWearingEquipment_Text(int _textNum, string _id)
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

            wearingEqipArr[_textNum] = _id;
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

            for (int i = 0; i < inventoryButtonArr.Length; i++)
            {
                inventoryButtonArr[i].SetActive(false);
            }


            // 착용한 아이템 능력 UI 설정
            if (wearingEqipArr[_clickNum] != string.Empty)
            {
                wearingEquipment.Func_SetEquipmentUI(int.Parse(wearingEqipArr[_clickNum]));
                inventoryButtonArr[1].SetActive(true);
            }
            else
            {
                wearingEquipment.gameObject.SetActive(false);
                inventoryButtonArr[0].SetActive(true);
            }

            // 해당 인벤토리 설정
            inventory.Func_SetInventory(_clickNum, wearingEqipArr[_clickNum]);
        }

        #endregion

    }
}