using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    #region Enum 열거형

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.04 </para>
    /// <para> 내    용 : Fade 열거형</para>
    /// </summary>
    public enum FADE
    {
        In, Out
    }
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2019.11.19</para>
    /// <para>내    용 : 씬의 종류</para>
    /// </summary>
    public enum SCENE_KIND
    {
        Intro, Main
    }

    #endregion

    #region Struct 구조체

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.04 </para>
    /// <para> 내    용 : 볼륨 열거형</para>
    /// </summary>
    [System.Serializable]
    public struct MD_Volume
    {
        [Range(0f, 1f)]
        public float volume_BGM;

        [Range(0f, 1f)]
        public float volume_Effect;
    }

    #endregion
    
}