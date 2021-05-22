using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// 테스트용 클래스
    /// </summary>
    public class DR_Test : MonoBehaviour
    {

        private List<Dictionary<string, object>> dialogueList;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Test - CSV 읽기");
                dialogueList = DR_CSV.Func_Read(DR_PathDefine.CSV_StoryPath + DR_PathDefine.CSV_Dialogue);
                Debug.Log("Count : " + dialogueList.Count);


                foreach (KeyValuePair<string, object> item in dialogueList[0])
                {

                }

                if (dialogueList[0].ContainsValue("Dialogue.1"))
                {
                    Debug.Log("Dialogue : 있음");

                }

                Debug.Log(dialogueList[1]["Dialogue ID"]);
                Debug.Log(dialogueList[2]["Dialogue ID"]);
            }

        }
    }
}