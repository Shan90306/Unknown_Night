using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;
using System;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.04 </para>
    /// <para> 내    용 : XML을 관리하는 스크립트 </para>
    /// </summary>
    public class DR_XML : DR_Singlton<DR_XML>
    {
        /// <summary>
        /// 선택한 XML을 캐싱
        /// </summary>
        private XmlDocument loadXMLDoc;

        protected override void Func_Init()
        {
            //Func_LoadProgramXML();
            //Func_Create_Program_InfoXML();
            //Func_LoadSaveSlotXML(0);
            //Func_Create_SaveSlotXML(1);
            //Func_DeleteXML(0);
        }

        #region XML 메서드

        private XmlElement Func_SetSlotNode(XmlDocument _xmlDoc, string _key, string _data)
        {
            // 슬롯노드에 들어갈 속성 생성
            XmlElement _setElement = _xmlDoc.CreateElement(_key);
            _setElement.InnerText = _data;

            return _setElement;
        }

        #endregion

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
            DR_Debug.Func_Log(DR_PathDefine.XML_ProgramInformation + " XML Save Success");
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
            _saveInfo.saveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _saveInfo.playTime = "00:00:00";
            _saveInfo.csvReadLine = 0;
            _saveInfo.chapter = "Test 챕터";
            _saveInfo.gold = 0;
            _saveInfo.captureName = DR_PathDefine.ScreenShot_SaveName + _slotNum + ".png";
            _saveInfo.isCommunication = true;

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
            _slotSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_SaveInformation_1, _saveInfo.saveTime));                    // 저장한 시간
            _slotSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_SaveInformation_2, _saveInfo.playTime));                    // 플레이한 시간
            _slotSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_SaveInformation_3, _saveInfo.csvReadLine.ToString()));   // CSV에서 읽고있는 라인
            _slotSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_SaveInformation_4, _saveInfo.chapter));                      // 챕터 이름
            _slotSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_SaveInformation_5, _saveInfo.gold.ToString()));                 // 소지 골드
            _slotSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_SaveInformation_6, _saveInfo.captureName));              // 캡쳐 이미지 이름
            _slotSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_SaveInformation_7, _saveInfo.isCommunication.ToString())); // 대화중이였는지 체크

            #endregion

            #region Status 노드 생성

            // 스텟 노드 생성
            XmlNode _statusSet = _xmlDoc.CreateNode(XmlNodeType.Element, "Status", string.Empty);
            _rootSet.AppendChild(_statusSet);

            _statusSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_Status_1, "1")); // 레벨
            _statusSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_Status_2, "0")); // 경험치
            _statusSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_Status_3, "5")); // 힘
            _statusSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_Status_4, "5")); // 민첩
            _statusSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_Status_5, "5")); // 체력
            _statusSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_Status_6, "5")); // 인내

            #endregion

            #region 착용 장비 노드 생성

            // 착용 장비 노드 생성
            XmlNode _wearingEquipmentSet = _xmlDoc.CreateNode(XmlNodeType.Element, "WearingEquipment", string.Empty);
            _rootSet.AppendChild(_wearingEquipmentSet);

            _wearingEquipmentSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_WearingEquip_1, string.Empty));   // 무기
            _wearingEquipmentSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_WearingEquip_2, string.Empty));   // 반지
            _wearingEquipmentSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_WearingEquip_3, string.Empty));   // 목걸이
            _wearingEquipmentSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_WearingEquip_4, string.Empty));   // 팔찌
            _wearingEquipmentSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_WearingEquip_5, string.Empty));   // 부적

            #endregion

            #region 인벤토리 노드 생성

            // 착용 장비 노드 생성
            XmlNode _inventorySet = _xmlDoc.CreateNode(XmlNodeType.Element, "Inventory", string.Empty);
            _rootSet.AppendChild(_inventorySet);

            _inventorySet.AppendChild(Func_SetSlotNode(_xmlDoc, "TestRing", "테스트 반지"));        // 반지
            _inventorySet.AppendChild(Func_SetSlotNode(_xmlDoc, "TestRing", "테스트 반지2"));        // 반지

            #endregion

            #endregion

            DirectoryInfo _di = new DirectoryInfo(Application.dataPath + DR_PathDefine.XML_SavePathName);
            if (!_di.Exists)
            {
                _di.Create();
                DR_Debug.Func_Log("XML 폴더 생성");
            }

            string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml";
            _xmlDoc.Save(_path);
            DR_Debug.Func_Log(_path + " XML Save Success");
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
                    DR_Debug.Func_Log(item.GetAttribute("Date"));
                }

            }
            else
            {
                DR_Debug.Func_Log(DR_PathDefine.XML_ProgramInformation + " Save 없음!");
                Func_Create_Program_InfoXML();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.04.29 </para>
        /// <para> 내    용 : Save XML 파일을 불러와 Slot 정보를 반환하는 메서드 </para>
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
                _saveInfo.saveTime = _nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_1).InnerText;
                _saveInfo.playTime = _nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_2).InnerText;
                _saveInfo.csvReadLine = int.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_3).InnerText);
                _saveInfo.chapter = _nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_4).InnerText;
                _saveInfo.gold = int.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_5).InnerText);
                _saveInfo.captureName = _nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_6).InnerText;
                _saveInfo.isCommunication = bool.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_7).InnerText);

                return _saveInfo;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.06.23 </para>
        /// <para> 내    용 : Save XML 파일을 불러와 플레이어가 착용한 장비 아이디를 반환하는 메서드 </para>
        /// </summary>
        public DR_DefineStatus Func_GetLoadStatus(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml";
            FileInfo _fileInfo = new FileInfo(_path);
            DR_DefineStatus _status = new DR_DefineStatus(0, 0, 0, 0, 0, 0);

            if (_fileInfo.Exists)
            {
                if (loadXMLDoc != null)
                {
                    XmlNodeList _nodes = loadXMLDoc.SelectNodes(DR_PathDefine.XML_Node_Status);

                    _status.level = int.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_Status_1).InnerText);
                    _status.exe = int.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_Status_2).InnerText);
                    _status.power = int.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_Status_3).InnerText);
                    _status.dex = int.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_Status_4).InnerText);
                    _status.health = int.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_Status_5).InnerText);
                    _status.patience = int.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_Status_6).InnerText);

                    return _status;
                }
                else
                {
                    DR_Debug.Func_RedLog("세이브파일 캐싱 X", "Intro 씬부터 시작 바람");
                }
            }

            return _status;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.06.23 </para>
        /// <para> 내    용 : Save XML 파일을 불러와 플레이어가 착용한 장비 아이디를 반환하는 메서드 </para>
        /// </summary>
        public DR_WearingEquipment Func_GetLoadWearingEquipment(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml";
            FileInfo _fileInfo = new FileInfo(_path);
            if (_fileInfo.Exists)
            {
                if (loadXMLDoc != null)
                {
                    XmlNodeList _nodes = loadXMLDoc.SelectNodes(DR_PathDefine.XML_Node_WearingEquipment);

                    DR_WearingEquipment _wearingEquipment = new DR_WearingEquipment();
                    _wearingEquipment.weapon = _nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_1).InnerText;
                    _wearingEquipment.ring = _nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_2).InnerText;
                    _wearingEquipment.necklace = _nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_3).InnerText;
                    _wearingEquipment.wristband = _nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_4).InnerText;
                    _wearingEquipment.amulet = _nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_5).InnerText;

                    return _wearingEquipment;
                }

                DR_Debug.Func_RedLog("세이브파일 캐싱 X", "Intro 씬부터 시작 바람");
            }

            return null;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.06.23 </para>
        /// <para> 내    용 : Save XML 파일을 선택하여 XML 클래스가 가지고 있게 하는 메서드 </para>
        /// </summary>
        public void Func_SellectLoadXML(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml";
            FileInfo _fileInfo = new FileInfo(_path);
            if (_fileInfo.Exists)
            {
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.Load(_path);

                loadXMLDoc = _xmlDoc;
                DR_Debug.Func_Log("선택한 파일 저장");
            }
            else
            {
                DR_Debug.Func_Log("선택한 파일 저장 실패");
            }
        }

        #endregion

        #region Save XML

        public void Func_SaveSlotXML(int _slotNum, DR_SaveInformation _saveInfo)
        {
            // 스크린샷 찍기
            DR_ScreenShot.Func_SaveScreenShot(_slotNum);

            XmlDocument _xmlDoc = loadXMLDoc;

            DR_SaveInformation _saveInfo_New = DR_ProgramManager.Instance.saveInfo;
            _saveInfo_New.saveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _saveInfo.captureName = DR_PathDefine.ScreenShot_SaveName + _slotNum + ".png";

            XmlNodeList _node = _xmlDoc.SelectNodes(DR_PathDefine.XML_Node_SaveSlot);
            XmlNode _slotInfo = _node[0];

            _slotInfo.SelectSingleNode("SaveTime").InnerText = _saveInfo_New.saveTime;
            _slotInfo.SelectSingleNode("PlayTime").InnerText = DR_ProgramManager.Instance.Func_GetPlayTime();
            _slotInfo.SelectSingleNode("CSVReadLine").InnerText = _saveInfo_New.csvReadLine.ToString();
            _slotInfo.SelectSingleNode("Chapter").InnerText = _saveInfo_New.chapter;
            _slotInfo.SelectSingleNode("Gold").InnerText = _saveInfo_New.gold.ToString();
            _slotInfo.SelectSingleNode("CaptureName").InnerText = _saveInfo_New.captureName;
            _slotInfo.SelectSingleNode("IsCommunication").InnerText = _saveInfo_New.isCommunication.ToString();


            _xmlDoc.Save(Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml");
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
                    DR_Debug.Func_Log(e.Message);
                    DR_Debug.Func_Log(e.InnerException.ToString());
                }
            }
        }

        #endregion
    }
}