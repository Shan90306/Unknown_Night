using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.04 </para>
    /// <para> 내    용 : XML을 관리하는 스크립트 </para>
    /// </summary>
    public class DR_XML : DR_Singlton<DR_XML>
    {

        protected override void Func_Init()
        {
            base.Func_Init();
            //Func_LoadProgramXML();
            //Func_Create_Program_InfoXML();
            //Func_LoadSaveSlotXML(0);
            //Func_Create_SaveSlotXML(0);
            //Func_DeleteXML(0);
        }

        #region Create XML

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : 프로그램 XML 파일을 생성하는 메서드 </para>
        /// </summary>
        private void Func_Create_Program_InfoXML()
        {
            // https://itleader.tistory.com/163
            // xml 선언
            XmlDocument _xmlDoc = new XmlDocument();
            // xml 버전과 인코딩 방식 설정
            _xmlDoc.AppendChild(_xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

            #region Setting Node

            //// 루트 노드 생성
            //XmlNode _rootSet = _xmlDoc.CreateNode(XmlNodeType.Element, "SettingInfo", string.Empty);
            //_xmlDoc.AppendChild(_rootSet);

            //// 자식 노드 생성
            //XmlNode _childSet = _xmlDoc.CreateNode(XmlNodeType.Element, "Setting", string.Empty);
            //_rootSet.AppendChild(_childSet);

            //// 자식노드에 들어갈 속성 생성
            //XmlElement _setDate = _xmlDoc.CreateElement("Date");
            //_setDate.InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            //_childSet.AppendChild(_setDate);

            XmlElement _setSettingInfo = _xmlDoc.CreateElement("SettingInfo");
            _xmlDoc.AppendChild(_setSettingInfo);

            XmlElement _setSetting = _xmlDoc.CreateElement("Setting");
            _setSettingInfo.AppendChild(_setSetting);

            _setSetting.SetAttribute("Date", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

            for (int i = 0; i < 3; i++)
            {
                XmlElement _setTest = _xmlDoc.CreateElement("Test");
                _setTest.SetAttribute("TestAttribute1", i.ToString());
                _setTest.SetAttribute("TestAttribute2", i.ToString());
                _setTest.SetAttribute("TestAttribute3", i.ToString());
                _setSettingInfo.AppendChild(_setTest);

            }

            #endregion

            _xmlDoc.Save(DR_PathDefine.XML_SavePath + DR_PathDefine.XML_ProgramInformation + ".xml");
            Debug.Log(DR_PathDefine.XML_ProgramInformation + " XML Save Success");
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.04.29 </para>
        /// <para> 내    용 : 최초 Save Slot XML 파일을 생성하는 메서드 </para>
        /// </summary>
        public void Func_Create_SaveSlotXML(int _slotNum)
        {
            // 스크린샷 찍기
            DR_ScreenShot.Func_SaveScreenShot(_slotNum);

            DR_SaveInformation _saveInfo = new DR_SaveInformation();
            _saveInfo.firstStartTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _saveInfo.saveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _saveInfo.chapter = "Test 챕터";
            _saveInfo.gold = 0;
            _saveInfo.captureName = DR_PathDefine.ScreenShot_SaveName + _slotNum + ".png";

            // xml 선언
            XmlDocument _xmlDoc = new XmlDocument();
            // xml 버전과 인코딩 방식 설정
            _xmlDoc.AppendChild(_xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

            #region Setting Node

            // 루트 노드 생성
            XmlNode _rootSet = _xmlDoc.CreateNode(XmlNodeType.Element, "SaveInfo", string.Empty);
            _xmlDoc.AppendChild(_rootSet);

            #region Slot 노드 생성

            // 슬롯 노드 생성
            XmlNode _slotSet = _xmlDoc.CreateNode(XmlNodeType.Element, "Slot", string.Empty);
            _rootSet.AppendChild(_slotSet);

            // 슬롯노드에 들어갈 속성 생성
            // 최초 시작한 시간
            XmlElement _setFirstStartTime = _xmlDoc.CreateElement("FirstStartTime");
            _setFirstStartTime.InnerText = _saveInfo.firstStartTime;
            _slotSet.AppendChild(_setFirstStartTime);

            // 저장한 시간
            XmlElement _setSaveTime = _xmlDoc.CreateElement("SaveTime");
            _setSaveTime.InnerText = _saveInfo.saveTime;
            _slotSet.AppendChild(_setSaveTime);

            // 챕터 이름
            XmlElement _setChapter = _xmlDoc.CreateElement("Chapter");
            _setChapter.InnerText = _saveInfo.chapter;
            _slotSet.AppendChild(_setChapter);

            // 소지 골드
            XmlElement _setGold = _xmlDoc.CreateElement("Gold");
            _setGold.InnerText = _saveInfo.gold.ToString();
            _slotSet.AppendChild(_setGold);

            // 캡쳐 이미지 이름
            XmlElement _setCaptureName = _xmlDoc.CreateElement("CaptureName");
            _setCaptureName.InnerText = _saveInfo.captureName;
            _slotSet.AppendChild(_setCaptureName);

            #endregion

            #endregion

            DirectoryInfo _di = new DirectoryInfo(Application.dataPath + DR_PathDefine.XML_SavePathName);
            if (!_di.Exists)
            {
                _di.Create();
                Debug.Log("XML 폴더 생성");
            }

            string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml";
            _xmlDoc.Save(_path);
            Debug.Log(_path + " XML Save Success");
        }

        #endregion

        #region Load XML

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : XML 파일을 불러오는 메서드 </para>
        /// </summary>
        private void Func_LoadProgramXML()
        {
            TextAsset _textAsset = (TextAsset)Resources.Load("XML/" + DR_PathDefine.XML_ProgramInformation);

            if (_textAsset != null)
            {
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.LoadXml(_textAsset.text);

                //XmlNodeList _nodes = _xmlDoc.SelectNodes(DR_PathDefine.XML_Node_Setting);

                //_nodes[0].SelectSingleNode("Date").InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                //Debug.Log(_nodes[0].SelectSingleNode("Date").InnerText);

                //_xmlDoc.Save(DR_PathDefine.XML_SavePath + DR_PathDefine.XML_ProgramInformation + ".xml");

                XmlElement _programElement = _xmlDoc["SettingInfo"];

                foreach (XmlElement item in _programElement.ChildNodes)
                {
                    Debug.Log(item.GetAttribute("Date"));
                }

            }
            else
            {
                Debug.Log(DR_PathDefine.XML_ProgramInformation + " Save 없음!");
                Func_Create_Program_InfoXML();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.04.29 </para>
        /// <para> 내    용 : Save XML 파일을 불러오는 메서드 </para>
        /// </summary>
        public DR_SaveInformation Func_LoadSaveSlotXML(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml";
            FileInfo _fileInfo = new FileInfo(_path);
            if (_fileInfo.Exists)
            {
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(_path);

                XmlNodeList _nodes = _xmlDoc.SelectNodes(DR_PathDefine.XML_Node_SaveSlot);

                DR_SaveInformation _saveInfo = new DR_SaveInformation();
                _saveInfo.firstStartTime = _nodes[0].SelectSingleNode("FirstStartTime").InnerText;
                _saveInfo.saveTime = _nodes[0].SelectSingleNode("SaveTime").InnerText;
                _saveInfo.chapter = _nodes[0].SelectSingleNode("Chapter").InnerText;
                _saveInfo.gold = int.Parse(_nodes[0].SelectSingleNode("Gold").InnerText);
                _saveInfo.captureName = _nodes[0].SelectSingleNode("CaptureName").InnerText;

                return _saveInfo;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Save XML

        public void Func_SaveSlotXML(int _slotNum, DR_SaveInformation _saveInfo)
        {
            XmlDocument _xmlDoc = new XmlDocument();


            _xmlDoc.Save(DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml");
        }

        #endregion

        #region Delete XML

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.04.29 </para>
        /// <para> 내    용 : Save XML 파일을 삭제하는 메서드 </para>
        /// </summary>
        public static void Func_DeleteXML(int _num)
        {
            string _filePath = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _num + ".xml";

            if (File.Exists(_filePath))
            {
                try
                {
                    File.Delete(_filePath);
                    File.Delete(_filePath + ".meta");
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                    Debug.Log(e.InnerException);
                }
            }
        }

        #endregion
    }
}