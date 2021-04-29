namespace DoodlesRe
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.04.04</para>
    /// <para>내    용 : 경로를 정의하는 구조체</para>
    /// </summary>
    public struct DR_PathDefine
    {

        #region XML

        // ******************************************************************************************************
        // XML
        // ******************************************************************************************************
        public const string XML_SavePath = "Assets/Resources/XML/";
        public const string XML_ProgramInformation = "Program";
        public const string XML_SaveInformation = "Save";
        public const string XML_ItemInformation = "Item";

        public const string XML_Node_Setting = "SettingInfo/Setting";
        public const string XML_Node_SaveSlot = "SaveInfo/Slot";

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