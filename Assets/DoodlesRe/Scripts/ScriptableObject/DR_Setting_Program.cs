using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    [CreateAssetMenu(fileName = "ProgramSetting", menuName = "DoodlesRe/ProgramSetting", order = int.MinValue)]
    public class DR_Setting_Program : DR_BaseScriptableObject
    {
        [Header("- Save XML File 이름")]
        public List<string> saveXMLNameList;
    }
}