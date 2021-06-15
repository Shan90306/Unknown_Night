using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-06-03 </para>
    /// <para> 내    용 : 맵의 이벤트 정보창 클래스 </para>
    /// </summary>
    public class DR_EventInfo : MonoBehaviour, DR_IWindow
    {
        [Header("- Main")]
        [SerializeField] private DR_Main main;

        [Header("- 타이틀 텍스트")]
        [SerializeField] private Text text_Title;

        [Header("- 설명 텍스트")]
        [SerializeField] private Text text_Explanation;

        [Header("- 캐릭터 이미지 배열")]
        [SerializeField] private Image[] image_CharacterArr;

        [Header("- 캐릭터 이름 텍스트 배열")]
        [SerializeField] private Text[] text_NameArr;

        [Header("- 뒤로가기 버튼")]
        [SerializeField] private Button button_Back;

        [Header("- 뒤로가기 시간")]
        public float backTime;


        private Vector3 firstPos;   // 처음 위치

        private void Start()
        {
            firstPos = transform.position;
            gameObject.SetActive(false);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-03 </para>
        /// <para> 내    용 : 맵의 이벤트 클릭 시 호출 </para>
        /// </summary>
        public void Func_SetEnable(Vector3 _point)
        {
            gameObject.SetActive(true);
            button_Back.interactable = true;
            transform.DOMove(_point, backTime);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-03 </para>
        /// <para> 내    용 : 맵의 이벤트 정보창을 닫는 버튼 클릭 시 호출 </para>
        /// </summary>
        public void Button_SetDisable()
        {
            main.Func_DontClickESC();
            Func_SetDisable();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-03 </para>
        /// <para> 내    용 : 창을 닫게하는 기능 </para>
        /// </summary>
        private void Func_SetDisable()
        {
            button_Back.interactable = false;
            transform.DOMove(firstPos, backTime)
                .OnComplete(() => gameObject.SetActive(false));

            main.Func_SetEnlargement(false);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-03 </para>
        /// <para> 내    용 : ESC를 눌렀을 때 창을 닫게하는 기능 </para>
        /// </summary>
        public void Func_Close()
        {
            Func_SetDisable();
        }
    }
}