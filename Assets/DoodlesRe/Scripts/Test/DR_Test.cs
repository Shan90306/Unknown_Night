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
                string _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePathName;
                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(_path);
                if (directoryInfo.Exists)
                {
                    _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePath + DR_PathDefine.XML_SaveName + 0 + ".png";
                    RenderTexture _renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
                    Texture2D _texture2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                    Rect _rect = new Rect(0, 0, Screen.width, Screen.height);

                    Camera _mainCam = Camera.main;
                    _mainCam.targetTexture = _renderTexture;
                    _mainCam.Render();
                    RenderTexture.active = _renderTexture;

                    _texture2D.ReadPixels(_rect, 0, 0);
                    _texture2D.Apply();

                    byte[] _byteArr = _texture2D.EncodeToPNG();
                    System.IO.File.WriteAllBytes(_path, _byteArr);

                    RenderTexture.active = null;
                    _mainCam.targetTexture = null;
                    Destroy(_renderTexture);
                    Debug.Log("스크린샷 생성");
                }
                else
                {
                    directoryInfo.Create();
                    Debug.Log("스크린샷 폴더 생성");
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                string _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePath + DR_PathDefine.XML_SaveName + 0 + ".png";
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(_path);
                if (fileInfo.Exists)
                {
                    Debug.Log("스크린샷 있음");
                }
                else
                {
                    Debug.Log("스크린샷 없음");

                }
            }
        }
    }
}