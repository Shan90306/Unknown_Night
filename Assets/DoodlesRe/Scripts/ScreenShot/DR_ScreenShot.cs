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
        /// <summary>
        /// <para>작 성 자 : 이승엽 </para>
        /// <para>작 성 일 : 2021-05-13 </para>
        /// <para>내    용 : 슬롯 번호에 맞는 스크린샷을 찍는 기능</para>
        /// </summary>
        public static void Func_SaveScreenShot(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePathName;
            System.IO.DirectoryInfo _directoryInfo = new System.IO.DirectoryInfo(_path);
            if (!_directoryInfo.Exists)
            {
                _directoryInfo.Create();
            }
            int _width = Screen.width, _height = Screen.height;

            _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePath + DR_PathDefine.ScreenShot_SaveName + _slotNum + ".png";
            RenderTexture _renderTexture = new RenderTexture(_width, _height, 24);
            Texture2D _texture2D = new Texture2D(_width, _height, TextureFormat.RGB24, false);
            Rect _rect = new Rect(0, 0, _width, _height);

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

        /// <summary>
        /// <para>작 성 자 : 이승엽 </para>
        /// <para>작 성 일 : 2021-05-13 </para>
        /// <para>내    용 : 슬롯 번호에 맞는 스크린샷을 가져와서 Sprite로 반환하는 기능</para>
        /// </summary>
        public static Sprite Func_GetSlotScreenShot(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePath + DR_PathDefine.ScreenShot_SaveName + _slotNum + ".png";
            System.IO.FileInfo _fileInfo = new System.IO.FileInfo(_path);
            if (_fileInfo.Exists)
            {
                int _width = Screen.width, _height = Screen.height;
                Sprite _screenShot = null;
                byte[] bytes = File.ReadAllBytes(_path);
                if (bytes.Length > 0)
                {
                    Texture2D _texture = new Texture2D(_width, _height);
                    Rect _rect = new Rect(0, 0, _width, _height);
                    Vector2 _pivot = new Vector2(0.5f, 0.5f);
                    _texture.LoadImage(bytes);

                    _screenShot = Sprite.Create(_texture, _rect, _pivot);
                    return _screenShot;
                }
            }

            return null;
        }

        /// <summary>
        /// <para>작 성 자 : 이승엽 </para>
        /// <para>작 성 일 : 2021-05-13 </para>
        /// <para>내    용 : 슬롯 번호에 맞는 스크린샷을 삭제하는 기능</para>
        /// </summary>
        public static void Func_DeleteSlotScreenShot(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.ScreenShot_SavePath + DR_PathDefine.ScreenShot_SaveName + _slotNum + ".png";
            System.IO.FileInfo _fileInfo = new System.IO.FileInfo(_path);
            if (_fileInfo.Exists)
            {
                _fileInfo.Delete();
            }
        }
    }
}