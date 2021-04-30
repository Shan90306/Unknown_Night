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
    public struct DR_Volume
    {
        [Range(0f, 1f)]
        public float volume_BGM;

        [Range(0f, 1f)]
        public float volume_Effect;
    }

    #endregion

    #region Class 클래스

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021.04.29 </para>
    /// <para> 내    용 : 저장슬롯에 저장할 목록 클래스</para>
    /// </summary>
    public class DR_SaveInformation
    {
        /// <summary>
        /// 최초 시작일
        /// </summary>
        public string firstStartTime;

        /// <summary>
        /// 저장시간
        /// </summary>
        public string saveTime;

        /// <summary>
        /// 현재 챕터
        /// </summary>
        public string chapter;

        /// <summary>
        /// 소지금
        /// </summary>
        public int gold;

        /// <summary>
        /// 캡쳐한 이미지 이름
        /// </summary>
        public string captureName;
    }

    #endregion

}