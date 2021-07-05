using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020-06-25 </para>
    /// <para> 내    용 : 장비의 능력치를 UI로 나타내는 클래스 </para>
    /// </summary>
    public class DR_EquipmentUI : DR_Info
    {
        [Header("- 장비의 이름 텍스트")]
        [SerializeField] private Text text_name;

        [Header("- 장비의 능력치 텍스트")]
        [SerializeField] private Text text_Ability;

        [Header("- ESC로 창을 끄게 할 것인지 체크")]
        [SerializeField] private bool isESC;

        [Header("- ESC로 창을 끄고 다른것을 활성화 할 때")]
        [SerializeField] private GameObject activeOBJ;

        #region 상속 메서드

        protected override void Func_Init()
        {
            if (isESC)
            {
                manager.Func_PushStack(this);
            }
        }

        public override void Func_Close()
        {
            activeOBJ.SetActive(true);
            gameObject.SetActive(false);
        }

        #endregion


        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-06-25 </para>
        /// <para> 내    용 : 장비의 아이디로 해당 이름과 능력치를 설정 </para>
        /// </summary>
        public void Func_SetEquipmentUI(int _itemID)
        {
            Dictionary<string, object> _dic = DR_ProgramManager.Instance.Func_GetItem(_itemID);
            bool _isSecond = false;

            text_name.text = string.Empty;
            text_Ability.text = string.Empty;

            text_name.text = _dic[DR_PathDefine.CSV_Key_ItemName].ToString();

            if (int.Parse(_dic[DR_PathDefine.CSV_Key_ItemStrength].ToString()) != 0)
            {
                int _power = int.Parse(_dic[DR_PathDefine.CSV_Key_ItemStrength].ToString());
                text_Ability.text += "힘 " + _power;
                _isSecond = true;
            }

            if (int.Parse(_dic[DR_PathDefine.CSV_Key_ItemDexterity].ToString()) != 0)
            {
                if (_isSecond)
                {
                    text_Ability.text += "\n";
                }

                int _dex = int.Parse(_dic[DR_PathDefine.CSV_Key_ItemDexterity].ToString());
                text_Ability.text += "민첩 " + _dex;
            }

            gameObject.SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-02 </para>
        /// <para> 내    용 : 장비끼리 비교하여 어느것의 능력치가 더 좋은지 체크하는 기능 </para>
        /// </summary>
        public void Func_ComparisonEquipmentUI(EQUIPMENT_KIND _wearingItem, int _itemID)
        {
            int _wearingItemID = 0;
            switch (_wearingItem)
            {
                case EQUIPMENT_KIND.Weapon:
                    _wearingItemID = Func_IsEmpty(DR_PlayerManager.Instance.wearingEquipment.weapon);
                    break;
                case EQUIPMENT_KIND.Ring:
                    _wearingItemID = Func_IsEmpty(DR_PlayerManager.Instance.wearingEquipment.ring);
                    break;
                case EQUIPMENT_KIND.Necklace:
                    _wearingItemID = Func_IsEmpty(DR_PlayerManager.Instance.wearingEquipment.necklace);
                    break;
                case EQUIPMENT_KIND.Wristband:
                    _wearingItemID = Func_IsEmpty(DR_PlayerManager.Instance.wearingEquipment.wristband);
                    break;
                case EQUIPMENT_KIND.Amulet:
                    _wearingItemID = Func_IsEmpty(DR_PlayerManager.Instance.wearingEquipment.amulet);
                    break;
            }

            if (_wearingItemID == 0)
            {
                Func_SetEquipmentUI(_itemID);
            }
            else
            {
                Func_ComparisonEquipmentUI(_wearingItemID, _itemID);
            }

            gameObject.SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-06 </para>
        /// <para> 내    용 : 장착한 아이템 아이디가 비어있는지 체크하는 기능 </para>
        /// </summary>
        private int Func_IsEmpty(string _idStr)
        {
            int _id = 0;
            if (_idStr != string.Empty)
            {
                _id = int.Parse(_idStr);
            }

            return _id;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020-07-02 </para>
        /// <para> 내    용 : 장비끼리 비교하여 어느것의 능력치가 더 좋은지 체크하는 기능 </para>
        /// </summary>
        private void Func_ComparisonEquipmentUI(int _wearingItemID, int _itemID)
        {
            Dictionary<string, object> _wearingDic = DR_ProgramManager.Instance.Func_GetItem(_wearingItemID);
            Dictionary<string, object> _dic = DR_ProgramManager.Instance.Func_GetItem(_itemID);
            bool _isSecond = false;

            text_Ability.text = string.Empty;

            text_name.text = _dic[DR_PathDefine.CSV_Key_ItemName].ToString();

            int _wearingPower = int.Parse(_wearingDic[DR_PathDefine.CSV_Key_ItemStrength].ToString());
            int _power = int.Parse(_dic[DR_PathDefine.CSV_Key_ItemStrength].ToString());
            if (Func_ComparisonAbility(_wearingPower, _power, "힘 ", _isSecond))
            {
                _isSecond = true;
            }

            int _wearingDex = int.Parse(_wearingDic[DR_PathDefine.CSV_Key_ItemDexterity].ToString());
            int _dex = int.Parse(_dic[DR_PathDefine.CSV_Key_ItemDexterity].ToString());
            if (Func_ComparisonAbility(_wearingDex, _dex, "민첩 ", _isSecond))
            {
                _isSecond = true;
            }

        }

        private bool Func_ComparisonAbility(int _wearing, int _item, string _abilityString, bool _isLineChange)
        {
            if (_wearing != 0 || _item != 0)
            {
                if (_isLineChange)
                {
                    text_Ability.text += "\n";
                }

                text_Ability.text += _abilityString + _item;

                int _dif = _item - _wearing;
                if (_dif > 0)
                {
                    // 빨강
                    text_Ability.text += "(<color=#FF0000>+" + _dif + "</color>)";
                }
                else if (_dif == 0)
                {
                    text_Ability.text += " (" + _dif + ")";
                }
                else
                {
                    // 파랑
                    text_Ability.text += "(<color=#0000FF>-" + _dif + "</color>)";
                }

                return true;
            }

            return false;
        }
    }
}