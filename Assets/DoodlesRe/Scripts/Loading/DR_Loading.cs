using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-04-29 </para>
    /// <para> 내    용 : 로딩 씬을 관리하는 클래스 </para>
    /// </summary>
    public class DR_Loading : MonoBehaviour
    {
        [Header("- 로딩 씬 스크립터블 오브젝트")]
        [SerializeField] private DR_Setting_Loading settingLoding;

        [Header("- 팁 텍스트")]
        [SerializeField] private Text text_Tip;

        [Header("- 로딩 텍스트")]
        [SerializeField] private Text text_Loading;


        private void Start()
        {
            Func_SetTip();              // Tip 텍스트 설정
            Func_SetLoadingText();      // 로딩 텍스트 설정
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : 로딩 중 팁 텍스트를 설정하는 기능 </para>
        /// </summary>
        private void Func_SetTip()
        {
            int _num = UnityEngine.Random.Range(0, settingLoding.tipArr.Length);
            text_Tip.text = settingLoding.tipArr[_num];
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : 로딩 텍스트를 바꿔주는 기능 </para>
        /// </summary>
        private void Func_SetLoadingText()
        {
            StartCoroutine(Co_SetLoadingText());
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-04-29 </para>
        /// <para> 내    용 : 로딩 텍스트를 바꿔주는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_SetLoadingText()
        {
            WaitForSecondsRealtime _waitForSecondsRealtime = new WaitForSecondsRealtime(settingLoding.text_LoadingTime);
            
            while (true)
            {
                text_Loading.text = "Loading.";
                yield return _waitForSecondsRealtime;

                text_Loading.text = "Loading..";
                yield return _waitForSecondsRealtime;

                text_Loading.text = "Loading...";
                yield return _waitForSecondsRealtime;
            }
        }
    }
}