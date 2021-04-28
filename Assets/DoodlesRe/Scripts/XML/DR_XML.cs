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
            Func_LoadProgramXML();
        }

        #region Create XML

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : 프로그램 XML 파일을 생성하는 메서드 </para>
        /// </summary>
        private void Func_Create_Program_InfoXML()
        {
            // xml 선언
            XmlDocument _xmlDoc = new XmlDocument();
            // xml 버전과 인코딩 방식 설정
            _xmlDoc.AppendChild(_xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

            #region Setting Node

            // 루트 노드 생성
            XmlNode _rootSet = _xmlDoc.CreateNode(XmlNodeType.Element, "SettingInfo", string.Empty);
            _xmlDoc.AppendChild(_rootSet);

            // 자식 노드 생성
            XmlNode _childSet = _xmlDoc.CreateNode(XmlNodeType.Element, "Setting", string.Empty);
            _rootSet.AppendChild(_childSet);

            // 자식노드에 들어갈 속성 생성
            XmlElement _setDate = _xmlDoc.CreateElement("Date");
            _setDate.InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            _childSet.AppendChild(_setDate);

            #endregion

            _xmlDoc.Save(DR_PathDefine.XML_SavePath + DR_PathDefine.XML_ProgramInformation + ".xml");
            Debug.Log(DR_PathDefine.XML_ProgramInformation + " XML Save Success");
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
            }
            else
            {
                Debug.Log(DR_PathDefine.XML_ProgramInformation + " Save 없음!");
                Func_Create_Program_InfoXML();
            }
        }

        #endregion
    }
}