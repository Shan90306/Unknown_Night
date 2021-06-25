﻿using System.Collections;
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
    public class DR_EquipmentUI : MonoBehaviour
    {
        [Header("- 장비의 이름 텍스트")]
        [SerializeField] private Text text_name;

        [Header("- 장비의 능력치 텍스트")]
        [SerializeField] private Text text_Ability;

        public void Func_SetEquipmentUI(int _itemID)
        {
            Dictionary<string, object> _dic = DR_ProgramManager.Instance.Func_GetItem(_itemID);
            bool _isPower = false;

            text_name.text = string.Empty;
            text_Ability.text = string.Empty;

            text_name.text = _dic[DR_PathDefine.CSV_Key_ItemName].ToString();

            if (int.Parse(_dic[DR_PathDefine.CSV_Key_ItemStrength].ToString()) != 0)
            {
                text_Ability.text += "힘 " + int.Parse(_dic[DR_PathDefine.CSV_Key_ItemStrength].ToString());
                _isPower = true;
            }

            if (int.Parse(_dic[DR_PathDefine.CSV_Key_ItemDexterity].ToString()) != 0)
            {
                if (_isPower)
                {
                    text_Ability.text += "\n";
                }
                text_Ability.text += "민첩 " + int.Parse(_dic[DR_PathDefine.CSV_Key_ItemDexterity].ToString());
            }

            gameObject.SetActive(true);
        }
    }
}