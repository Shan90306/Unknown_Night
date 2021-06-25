namespace DoodlesRe
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.04.04</para>
    /// <para>내    용 : 경로를 정의하는 구조체</para>
    /// </summary>
    public struct DR_PathDefine
    {
        #region Save Path

        public const string XML_SavePath = "/Resources/XML/";
        public const string XML_SavePathName = "/Resources/XML";
        public const string CSV_SavePath = "/Resources/CSV/";
        public const string CSV_StoryPath = "/Story/";
        public const string CSV_ItemPath = "/Item/";
        public const string ScreenShot_SavePath = "/Resources/ScreenShot/";
        public const string ScreenShot_SavePathName = "/Resources/ScreenShot";

        #endregion

        #region XML

        // ******************************************************************************************************
        // XML
        // ******************************************************************************************************
        public const string XML_ProgramInformation = "Program";
        public const string XML_SaveName = "Save";
        public const string ScreenShot_SaveName = "Save";

        public const string XML_Key_Item = "Item";
        public const string XML_Key_ID = "ID";
        public const string XML_Key_Count = "Count";
        

        public const string XML_Node_Setting = "SettingInfo/Setting";
        public const string XML_Node_SaveSlot = "SaveInfo/Slot";
        public const string XML_Node_Status = "SaveInfo/Status";
        public const string XML_Node_WearingEquipment = "SaveInfo/WearingEquipment";
        public const string XML_Node_Inventory = "SaveInfo/Inventory";

        // ******************************************************************************************************
        // SaveInformation
        public const string XML_NodeName_SaveInformation_1 = "SaveTime";
        public const string XML_NodeName_SaveInformation_2 = "PlayTime";
        public const string XML_NodeName_SaveInformation_3 = "CSVReadLine";
        public const string XML_NodeName_SaveInformation_4 = "Chapter";
        public const string XML_NodeName_SaveInformation_5 = "Gold";
        public const string XML_NodeName_SaveInformation_6 = "CaptureName";
        public const string XML_NodeName_SaveInformation_7 = "IsCommunication";

        // Status
        public const string XML_NodeName_Status_1 = "Level";
        public const string XML_NodeName_Status_2 = "EXE";
        public const string XML_NodeName_Status_3 = "Power";
        public const string XML_NodeName_Status_4 = "Dex";
        public const string XML_NodeName_Status_5 = "Health";
        public const string XML_NodeName_Status_6 = "Patience";


        // Wearing Equipment
        public const string XML_NodeName_WearingEquip_1 = "Weapon";
        public const string XML_NodeName_WearingEquip_2 = "Ring";
        public const string XML_NodeName_WearingEquip_3 = "Necklace";
        public const string XML_NodeName_WearingEquip_4 = "Wristband";
        public const string XML_NodeName_WearingEquip_5 = "Amulet";


        #endregion

        #region CSV

        // ******************************************************************************************************
        // CSV
        // ******************************************************************************************************
        public const string CSV_Dialogue = "Story_Dialogue.csv";
        public const string CSV_Character = "Story_Character.csv";
        public const string CSV_Item = "Test_Item.csv";

        public const string CSV_Key_ItemName = "Korea Name";
        public const string CSV_Key_ItemType = "Type";
        public const string CSV_Key_ItemStrength = "Strength";
        public const string CSV_Key_ItemDexterity = "Dexterity";

        #endregion

        #region Audio

        // ******************************************************************************************************
        // Audio Path
        // ******************************************************************************************************
        public const string Audio_BGMPath = "Audio/BGM";
        public const string Audio_EffectPath = "Audio/Effect";

        // ******************************************************************************************************
        // BGM
        // ******************************************************************************************************
        public const string Audio_BGM_Space = "PlayBGM";

        // ******************************************************************************************************
        // Effect
        // ******************************************************************************************************
        public const string Audio_EffectButtonClick = "ButtonClick";

        #endregion
    }
}