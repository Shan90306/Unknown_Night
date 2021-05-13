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
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + 0 + ".xml";
                Debug.Log(_path);
                System.IO.FileInfo _di = new System.IO.FileInfo(_path);
                if (!_di.Exists)
                {
                    Debug.Log("XML 없음");
                }
                else
                {
                    Debug.Log("XML 있음");
                }
            }
        }
    }
}