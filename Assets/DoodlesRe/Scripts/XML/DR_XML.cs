using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
            Func_Create_Program_InfoXML();
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

            #endregion

            _xmlDoc.Save(DR_PathDefine.XML_SavePath + DR_PathDefine.XML_ProgramInformation + ".xml");
            Debug.Log(DR_PathDefine.XML_ProgramInformation + " XML Save Success");
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.04.29 </para>
        /// <para> 내    용 : Save XML 파일을 생성하는 메서드 </para>
        /// </summary>
        private void Func_Create_Save_InfoXML(int _slotNum)
        {
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
            _setFirstStartTime.InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            _slotSet.AppendChild(_setFirstStartTime);

            // 저장한 시간
            XmlElement _setSaveTime = _xmlDoc.CreateElement("SaveTime");
            _setSaveTime.InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            _slotSet.AppendChild(_setSaveTime);

            // 챕터 이름
            XmlElement _setChapter = _xmlDoc.CreateElement("Chapter");
            _setChapter.InnerText = "테스트 챕터 이름";
            _slotSet.AppendChild(_setChapter);

            // 소지 골드
            XmlElement _setGold = _xmlDoc.CreateElement("Gold");
            _setGold.InnerText = "0";
            _slotSet.AppendChild(_setGold);

            // 캡쳐 이미지 이름
            XmlElement _setCaptureName = _xmlDoc.CreateElement("CaptureName");
            _setCaptureName.InnerText = "테스트 캡쳐 이미지 이름";
            _slotSet.AppendChild(_setCaptureName);

            #endregion

            #endregion

            _xmlDoc.Save(DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveInformation + _slotNum + ".xml");
            Debug.Log(DR_PathDefine.XML_SaveInformation + _slotNum + " XML Save Success");
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

                XmlNodeList _nodes = _xmlDoc.SelectNodes(DR_PathDefine.XML_Node_Setting);

                _nodes[0].SelectSingleNode("Date").InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Debug.Log(_nodes[0].SelectSingleNode("Date").InnerText);

                _xmlDoc.Save(DR_PathDefine.XML_SavePath + DR_PathDefine.XML_ProgramInformation + ".xml");
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
        public void Func_LoadSaveSlotXML(int _slotNum)
        {
            TextAsset _textAsset = (TextAsset)Resources.Load("XML/" + DR_PathDefine.XML_SaveInformation + _slotNum);

            if (_textAsset != null)
            {
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.LoadXml(_textAsset.text);

                XmlNodeList _nodes = _xmlDoc.SelectNodes(DR_PathDefine.XML_Node_SaveSlot);

                _nodes[0].SelectSingleNode("SaveTime").InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Debug.Log(_nodes[0].SelectSingleNode("SaveTime").InnerText);
            }
            else
            {
                Debug.Log(DR_PathDefine.XML_SaveInformation + _slotNum + " Save 없음!");
                Func_Create_Save_InfoXML(_slotNum);                 // Save XML 파일 생성
            }
        }

        #endregion
    }
}