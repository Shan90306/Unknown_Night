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

        [Header("- Fade 이미지")]
        [SerializeField] private Image image_fade;

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
            int _checkNum = 0;
            while (true)
            {
                text_Loading.text = "Loading.";
                yield return _waitForSecondsRealtime;

                text_Loading.text = "Loading..";
                yield return _waitForSecondsRealtime;

                text_Loading.text = "Loading...";
                yield return _waitForSecondsRealtime;

                _checkNum++;
                if (_checkNum == 1)
                {

                }
            }
        }

        #region 씬 이동 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 20/12/31 </para>
        /// <para> 내    용 : 씬을 이동시키는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_ChangeStart()
        {
            WaitForSecondsRealtime _waitForSecondsRealtime = new WaitForSecondsRealtime(DR_ProgramManager.Instance.fadeTime + 0.5f);

            DR_ProgramManager.Instance.Func_Fade(FADE.In);
            yield return _waitForSecondsRealtime;

            // 씬매니져의 이동해야 하는 씬으로 이동 준비
            GP_SceneManager.Instance.Func_LoadSceneName(Func_ChangeSceneName());

            if (GP_SceneManager.Instance.useAsync)
            {
                while (!GP_SceneManager.Instance.isDone)
                {
                    //Debug.Log(GP_SceneManager.Instance.asyncProgress);
                    loadingBar.value = GP_SceneManager.Instance.asyncProgress;
                    yield return new WaitForFixedUpdate();
                }

                loadingBar.value = 1f;
                GP_PlayerController.Instance.Func_Fade(FADE.Out);
                yield return _waitForSecondsRealtime;

                GP_SceneManager.Instance.Func_AsyncOperationDone();
            }
        }

        #endregion

    }
}