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
        Sword, Spear, Axe, Ring, Necklace, Wristband, Amulet, Weapon
    }

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2021-07-07</para>
    /// <para>내    용 : 스킬의 부적 종류</para>
    /// </summary>
    public enum SKILL_AMULET
    {
        Amulet_1, Amulet_2, Amulet_3
    }

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2021-07-07</para>
    /// <para>내    용 : 스킬의 종류</para>
    /// </summary>
    public enum SKILL_KIND
    {
        Skill_1_1, Skill_1_2, Skill_1_3, Skill_1_4,
        Skill_2_1, Skill_2_2, Skill_2_3, Skill_2_4,
        Skill_3_1, Skill_3_2, Skill_3_3, Skill_3_4
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

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 21/05/16 </para>
    /// <para> 내    용 : 세이브 UI 종류에 대한 구조체 </para>
    /// </summary>
    public struct DR_DefineSaveLoadTitle
    {
        public const string Save = "세이브";
        public const string Load = "로드";
        public const string Intro = "세이브 / 로드";
    }

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 21/05/16 </para>
    /// <para> 내    용 : 스텟에 대한 구조체 </para>
    /// </summary>
    [System.Serializable]
    public struct DR_DefineStatus
    {
        /// <summary>
        /// 레벨
        /// </summary>
        public int level;

        /// <summary>
        /// 경험치
        /// </summary>
        public int exe;

        /// <summary>
        /// 힘
        /// </summary>
        public int power;

        /// <summary>
        /// 민첩
        /// </summary>
        public int dex;

        /// <summary>
        /// 생명력
        /// </summary>
        public int health;

        /// <summary>
        /// 인내
        /// </summary>
        public int patience;

        public DR_DefineStatus(int _level, int _exe, int _power, int _dex, int _health, int _patience)
        {
            level = _level;
            exe = _exe;
            power = _power;
            dex = _dex;
            health = _health;
            patience = _patience;
        }
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
        /// 저장시간
        /// </summary>
        public string saveTime;

        /// <summary>
        /// 플레이 시간
        /// </summary>
        public string playTime;

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

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021.04.29 </para>
    /// <para> 내    용 : 저장슬롯에 저장할 목록 클래스</para>
    /// </summary>
    [System.Serializable]
    public class DR_WearingEquipment
    {
        /// <summary>
        /// 무기
        /// </summary>
        public string weapon;

        /// <summary>
        /// 반지
        /// </summary>
        public string ring;
        
        /// <summary>
        /// 목걸이
        /// </summary>
        public string necklace;

        /// <summary>
        /// 팔찌
        /// </summary>
        public string wristband;

        /// <summary>
        /// 부적
        /// </summary>
        public string amulet;
    }

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021.07.07 </para>
    /// <para> 내    용 : 플레이어가 선택한 스킬 클래스</para>
    /// </summary>
    [System.Serializable]
    public class DR_PlayerSellectSkill
    {
        /// <summary>
        /// 스킬의 부적 종류
        /// </summary>
        public SKILL_AMULET skill_Amulet;

        /// <summary>
        /// 첫번째 스킬 종류
        /// </summary>
        public SKILL_KIND skill_First;

        /// <summary>
        /// 두번째 스킬 종류
        /// </summary>
        public SKILL_KIND skill_Second;

        /// <summary>
        /// 세번째 스킬 종류
        /// </summary>
        public SKILL_KIND skill_Third;

        /// <summary>
        /// 네번째 스킬 종류
        /// </summary>
        public SKILL_KIND skill_Fourth;
    }

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021.07.07 </para>
    /// <para> 내    용 : 각 부적 별 스킬 포인트 클래스</para>
    /// </summary>
    [System.Serializable]
    public class DR_SkillPoint
    {
        public DR_SkillPoint(int _count)
        {
            skillPoint = new int[_count];
        }

        public int[] skillPoint;
    }

    #endregion

}