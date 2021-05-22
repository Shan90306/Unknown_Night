using System.Collections;
using System.Collections.Generic;
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

        [Header("- 텍스트 출력을 스킵할것인지 체크")]
        [SerializeField] private bool isSkip;

        private GameObject rootOBJ;     // 대화기능 UI의 root 오브젝트

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

            Func_SetTextBox(DR_ProgramManager.Instance.saveInfo.csvReadLine);

            rootOBJ.SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : 대화박스를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetTextBox(int _csvLineNum)
        {
            text_name.text = DR_ProgramManager.dialogueList[_csvLineNum]["Actor"] as string;
            string _scriptText = DR_ProgramManager.dialogueList[_csvLineNum]["Text"] as string;

            if (isSkip)
            {
                Debug.Log("한글자씩 출력 기능");
            }
            else
            {
                text_Dialogue.text = _scriptText;
            }
        }

        #endregion
    }
}