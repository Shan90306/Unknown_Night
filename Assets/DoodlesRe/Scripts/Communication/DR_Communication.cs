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
        [Header("- 이름")]
        [SerializeField] private Text text_name;

        [Header("- 대화")]
        [SerializeField] private Text text_Dialogue;

        private List<Dictionary<string, object>> dialogueList;
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

            dialogueList = DR_CSV.Func_Read(DR_PathDefine.CSV_Dialogue);
            for (int i = 0; i < dialogueList.Count; i++)
            {

            }

            rootOBJ.SetActive(true);
        }

        #endregion
    }
}