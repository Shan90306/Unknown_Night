using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para>작 성 자 : 이승엽 </para>
    /// <para>작 성 일 : 2021-05-13 </para>
    /// <para>내    용 : 스크린샷을 찍는 기능을 가진 클래스 </para>
    /// </summary>
    public class DR_ScreenShot : MonoBehaviour
    {
        public static void Func_SaveScreenShot(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePathName;
            System.IO.DirectoryInfo _directoryInfo = new System.IO.DirectoryInfo(_path);
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
            }

            _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePath + DR_PathDefine.ScreenShot_SaveName + 0 + ".png";
            RenderTexture _renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
            Texture2D _texture2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            Rect _rect = new Rect(0, 0, 256, 256);

            Camera _mainCam = Camera.main;
            _mainCam.targetTexture = _renderTexture;
            _mainCam.Render();
            RenderTexture.active = _renderTexture;

            _texture2D.ReadPixels(_rect, 0, 0);
            _texture2D.Apply();

            byte[] _byteArr = _texture2D.EncodeToPNG();
            System.IO.File.WriteAllBytes(_path, _byteArr);      // png로 저장

            // 상황 해제
            RenderTexture.active = null;
            _mainCam.targetTexture = null;
            Destroy(_renderTexture);
        }

        public static Sprite Func_GetSlotScreenShot(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePath + DR_PathDefine.ScreenShot_SaveName + _slotNum + ".png";
            System.IO.FileInfo _fileInfo = new System.IO.FileInfo(_path);
            if (_fileInfo.Exists)
            {
                Sprite _screenShot = null;
                byte[] bytes = File.ReadAllBytes(_path);
                Texture2D _texture = null;
                Rect _rect = new Rect(0, 0, 256, 256);
                Vector2 _pivot = new Vector2(0.5f, 0.5f);
                _texture.LoadImage(bytes);

                _screenShot = Sprite.Create(_texture, _rect, _pivot);
                return _screenShot;
            }

            return null;
        }
    }
}