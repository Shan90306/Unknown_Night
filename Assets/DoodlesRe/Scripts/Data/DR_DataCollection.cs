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

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2021.05.10</para>
    /// <para>내    용 : Save Load 종류</para>
    /// </summary>
    public enum SAVELOAD_KIND
    {
        Save, Load, Intro
    }

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2021.06.01</para>
    /// <para>내    용 : Main 맵 종류</para>
    /// </summary>
    public enum MAINMAP_KIND
    {
        School, Shopping_Street, Church
    }

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2021.06.02</para>
    /// <para>내    용 : 날씨 종류</para>
    /// </summary>
    public enum WEATHER_KIND
    {
        Sunny, Rainy, Cloudy
    }

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2021.06.02</para>
    /// <para>내    용 : 시간 종류</para>
    /// </summary>
    public enum TIME_KIND
    {
        Morning, Afternoon, Evening , Night
    }

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2021-06-20</para>
    /// <para>내    용 : 장비템 종류</para>
    /// </summary>
    public enum EQUIPMENT_KIND
    {
        Ring, Necklace, Wristband, Amulet
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

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 21/05/16 </para>
    /// <para> 내    용 : 씬 이름에 대한 구조체 </para>
    /// </summary>
    public struct DR_DefineSceneName
    {
        public const string IntroScene = "#00.Intro";
        public const string LoadingScene = "#01.Loading";
        public const string MainScene = "#02.Main";
    }

    public struct DR_DefineSaveLoadTitle
    {
        public const string Save = "세이브";
        public const string Load = "로드";
        public const string Intro = "세이브 / 로드";
    }

    #endregion

    #region Class 클래스

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021.04.29 </para>
    /// <para> 내    용 : 저장슬롯에 저장할 목록 클래스</para>
    /// </summary>
    [System.Serializable]
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
        /// CSV에서 읽고있는 라인
        /// </summary>
        public int csvReadLine;

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

        /// <summary>
        /// 대화중이였는지 체크
        /// </summary>
        public bool isCommunication;
    }

    #endregion

}