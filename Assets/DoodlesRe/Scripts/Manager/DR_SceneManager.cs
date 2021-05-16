using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2021-04-19</para>
    /// <para>내    용 : 씬을 바꿔주는 스크립트</para>
    /// </summary>
    public class DR_SceneManager : DR_Singlton<DR_SceneManager>
    {
        [Header("가야 할 씬의 종류")]
        public SCENE_KIND sceneKind;    
        
        [Header("씬 전환에 ASync 사용 여부")]
        public bool useAsync = true;

        [Header("- ASync 퍼센트")]
        public float asyncProgress;

        [Header("씬 전환 준비 완료 체크")]
        public bool isDone;

        private AsyncOperation asyncOperation;      // Async

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-16 </para>
        /// <para> 내    용 : 해당하는 씬으로 이동 준비하는 코루틴 호출 메서드 </para>
        /// </summary>  
        public void Func_GoLoadingBeforScene(SCENE_KIND _scene)
        {
            sceneKind = _scene;
            SceneManager.LoadScene(GP_DefineSceneName.LoadingScene);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-16 </para>
        /// <para> 내    용 : 해당하는 씬으로 이동 준비하는 코루틴 호출 메서드 </para>
        /// </summary>
        public void Func_LoadSceneNameAscync(string _sceneName)
        {
            StartCoroutine(Co_LoadSceneNameAscync(_sceneName));
        }
        
        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-16 </para>
        /// <para> 내    용 : 해당하는 씬으로 이동 준비하는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_LoadSceneNameAscync(string _sceneName)
        {
            if (useAsync)       // Async 사용
            {
                isDone = false;     // 이동 준비 미완

                asyncOperation = SceneManager.LoadSceneAsync(_sceneName);
                asyncOperation.allowSceneActivation = false;

                //while (asyncOperation.progress < 0.9f)
                while (!isDone)
                {
                    asyncProgress = asyncOperation.progress;
                    if (asyncOperation.progress >= 0.9f)
                    {
                        yield return new WaitForSecondsRealtime(0.5f);
                        isDone = true;      // 이동 준비 완료
                    }
                    yield return new WaitForFixedUpdate();
                }

            }
            else  // Async 미사용
            {
                SceneManager.LoadScene(_sceneName);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-16 </para>
        /// <para> 내    용 : 씬 이동하게 설정 </para>
        /// </summary>
        public void Func_AsyncOperationDone()
        {
            asyncOperation.allowSceneActivation = true;
        }
    }
}
