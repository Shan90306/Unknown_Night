using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace DoodlesRe
{
    /// <summary>
    /// 테스트용 클래스
    /// </summary>
    public class DR_Test : MonoBehaviour
    {
        [Header("- 대화 텍스트")]
        [SerializeField] private Text text_Dialogue;

        [Header("- 출력할 텍스트 인풋필드")]
        [SerializeField] private InputField textField;

        [Header("- 출력시간 인풋필드")]
        [SerializeField] private InputField timeField;

        [Header("- 텍스트 출력을 한글자씩 출력할 것인지 체크")]
        [SerializeField] private bool isFastRead;

        [Header("- 텍스트 출력을 한글자씩 출력할 시간")]
        [SerializeField] private float eachScriptTime;

        private IEnumerator co_PrintEachText;
        private string scriptText;
        private bool isNowLineEnd = false;

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-05-18 </para>
        /// <para> 내    용 : 대화박스를 설정하는 기능 </para>
        /// </summary>
        public void Func_SetTextBox()
        {            
            if (isFastRead)
            {
                Debug.Log("한글자씩 출력 기능");
                if (co_PrintEachText != null)
                {
                    StopCoroutine(co_PrintEachText);
                }

                co_PrintEachText = Co_PrintEachText(scriptText);
                StartCoroutine(co_PrintEachText);
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
            //isNowLineEnd = false;

            for (int i = 0; i < _scriptText.Length; i++)
            {
                _sb.Append(_scriptText[i]);
                text_Dialogue.text = _sb.ToString();
                yield return _waitForSecondsRealtime;
            }

            //isNowLineEnd = true;
        }

        public void Func_EndText()
        {
            scriptText = textField.text;
            Func_SetTextBox();
            textField.text = "";
        }

        public void Func_TimeText()
        {
            if (!float.TryParse(timeField.text, out eachScriptTime))
            {
                timeField.text = "숫자만 적어주세요";
            }
        }

        public void Func_OnToggle()
        {
            isFastRead = !isFastRead;
        }
    }
}