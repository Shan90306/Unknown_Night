using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-05-18 </para>
    /// <para> 내    용 : 대화 기능을 담당하는 클래스 </para>
    /// </summary>
    public class DR_Communication : MonoBehaviour
    {
        [Header("- 이름 텍스트")]
        [SerializeField] private Text text_name;

        [Header("- 대화 텍스트")]
        [SerializeField] private Text text_Dialogue;

        [Header("- 텍스트 출력을 한글자씩 출력할 것인지 체크")]
        [SerializeField] private bool isFastRead;

        [Header("- 텍스트 출력을 한글자씩 출력할 시간")]
        [SerializeField] private float eachScriptTime;

        [Header("- 현재 Dialogue")]
        [SerializeField] private string nowDialogue;

        private GameObject rootOBJ;     // 대화기능 UI의 root 오브젝트
        private IEnumerator co_PrintEachText;
        private bool isNowLineEnd = false;
        string scriptText;

        #region Unity 이벤트 함수

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isFastRead)
                {
                    if (isNowLineEnd)
                    {
                        Func_NextScript();
                    }
                    else
                    {
                        StopCoroutine(co_PrintEachText);
                        isNowLineEnd = true;
                        text_Dialogue.text = scriptText;
                    }
                }
                else
                {
                    Func_NextScript();
                }
            }
        }

        private void OnDisable()
        {
            DR_ProgramManager.Instance.saveInfo.isCommunication = false;
        }

        #endregion

        #region 기능

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : 대화 기능을 초기화하는 기능 </para>
        /// </summary>
        public void Func_Init()
        {
            if (rootOBJ == null)
                rootOBJ = transform.parent.gameObject;

            nowDialogue = string.Empty;    // 현재 Dialogue 초기화
            isNowLineEnd = true;
            Func_SetTextBox(DR_ProgramManager.Instance.saveInfo.csvReadLine++);

            rootOBJ.SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-24 </para>
        /// <para> 내    용 : 다음 대화를 설정하는 기능 </para>
        /// </summary>
        public void Func_NextScript()
        {
            if (DR_ProgramManager.dialogueList.Count > DR_ProgramManager.Instance.saveInfo.csvReadLine)
            {
                // 현재 대화 스토리가 끝인지 체크
                if (!Func_IsEndStory(DR_ProgramManager.Instance.saveInfo.csvReadLine))
                {
                    Func_SetTextBox(DR_ProgramManager.Instance.saveInfo.csvReadLine++);
                }
                else
                {
                    nowDialogue = string.Empty;    // 현재 Dialogue 초기화
                    DR_Debug.Func_Log("스토리 끝. 메인화면으로 이동");
                }
            }
            else
            {
                DR_Debug.Func_Log("전체 끝");
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-24 </para>
        /// <para> 내    용 : 화면에 출력되어있는 스크립트의 다음 스크립트의 Dialogue가 다른지 체크하는 기능 </para>
        /// </summary>
        private bool Func_IsEndStory(int _csvLineNum)
        {
            string _nextDialogue = DR_ProgramManager.dialogueList[_csvLineNum]["Dialogue ID"].ToString();

            if (nowDialogue == string.Empty)
            {
                nowDialogue = _nextDialogue;
            }

            return nowDialogue != _nextDialogue;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : 대화박스를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetTextBox(int _csvLineNum)
        {
            int _listNum = (int)DR_ProgramManager.dialogueList[_csvLineNum]["Actor"];
            text_name.text = DR_ProgramManager.characterList[_listNum]["Name"].ToString();

            scriptText = DR_ProgramManager.dialogueList[_csvLineNum]["Text"] as string;

            if (isFastRead)
            {
                DR_Debug.Func_Log("한글자씩 출력 기능");
                if (rootOBJ.activeInHierarchy)
                {
                    co_PrintEachText = Co_PrintEachText(scriptText);
                    StartCoroutine(co_PrintEachText);
                }
                else
                {
                    text_Dialogue.text = scriptText;
                }
            }
            else
            {
                text_Dialogue.text = scriptText;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-24 </para>
        /// <para> 내    용 : 한글자씩 출력하는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_PrintEachText(string _scriptText)
        {
            StringBuilder _sb = new StringBuilder(123);
            WaitForSecondsRealtime _waitForSecondsRealtime = new WaitForSecondsRealtime(eachScriptTime);
            isNowLineEnd = false;

            for (int i = 0; i < _scriptText.Length; i++)
            {
                _sb.Append(_scriptText[i]);
                text_Dialogue.text = _sb.ToString();
                yield return _waitForSecondsRealtime;
            }

            isNowLineEnd = true;
        }



        #endregion
    }
}