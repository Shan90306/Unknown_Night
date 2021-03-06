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

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 20201-06-24 </para>
        /// <para> 내    용 : XML의 Element를 생성 후 속성과 값을 넣어 반환하는 메서드 </para>
        /// </summary>
        private XmlElement Func_SetSlotNode(XmlDocument _xmlDoc, string _key, string _data)
        {
            // 슬롯노드에 들어갈 속성 생성
            XmlElement _setElement = _xmlDoc.CreateElement(_key);
            _setElement.InnerText = _data;

            return _setElement;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 20201-06-24 </para>
        /// <para> 내    용 : XML의 Element를 생성 후 속성과 값을 넣어 반환하는 메서드 </para>
        /// </summary>
        private XmlElement Func_SetSkillNode(XmlDocument _xmlDoc, string _key, string _skill, string _sp)
        {
            // 슬롯노드에 들어갈 속성 생성
            XmlElement _setElement = _xmlDoc.CreateElement(_key);
            _setElement.SetAttribute(DR_PathDefine.XML_Key_ID, _skill);      // 스킬 번호
            _setElement.SetAttribute(DR_PathDefine.XML_Key_SP, _sp);      // SP

            return _setElement;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 20201-06-24 </para>
        /// <para> 내    용 : XML의 Element를 생성 후 속성과 값을 넣어 반환하는 메서드 </para>
        /// </summary>
        private XmlElement Func_SetItemNode(XmlDocument _xmlDoc, string _key, string _id, string _count)
        {
            // 슬롯노드에 들어갈 속성 생성
            XmlElement _setElement = _xmlDoc.CreateElement(_key);
            _setElement.SetAttribute(DR_PathDefine.XML_Key_ID, _id);            // 아이템 아이디
            _setElement.SetAttribute(DR_PathDefine.XML_Key_Count, _count);      // 아이템 소지 개수

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
            _statusSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_NodeName_SkillPoint, "5")); // 스킬포인트

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

            #region 스킬 노드 생성

            // 스킬 노드 생성
            XmlNode _skillSet = _xmlDoc.CreateNode(XmlNodeType.Element, "Skill", string.Empty);
            _rootSet.AppendChild(_skillSet);
            string _skill_ID = string.Empty;

            _skillSet.AppendChild(Func_SetSlotNode(_xmlDoc, DR_PathDefine.XML_Key_SP, "0"));    // 플레이어 SP 설정

            // 스킬의 각 SP 설정
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    _skill_ID = i.ToString() + "-" + j.ToString();
                    _skillSet.AppendChild(Func_SetSkillNode(_xmlDoc, DR_PathDefine.XML_Key_Skill, _skill_ID, "0"));
                }
            }


            #endregion

            #region 인벤토리 노드 생성

            // 착용 장비 노드 생성
            XmlNode _inventorySet = _xmlDoc.CreateNode(XmlNodeType.Element, "Inventory", string.Empty);
            _rootSet.AppendChild(_inventorySet);

            _inventorySet.AppendChild(Func_SetItemNode(_xmlDoc, DR_PathDefine.XML_Key_Item, "10001", "1"));
            _inventorySet.AppendChild(Func_SetItemNode(_xmlDoc, DR_PathDefine.XML_Key_Item, "10002", "1"));

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
        /// <para> 작 성 일 : 2021.06.23 </para>
        /// <para> 내    용 : Save XML 파일을 로드하여 캐싱하는 메서드 </para>
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
                DR_Debug.Func_Log("선택한 파일 캐싱");
            }
            else
            {
                DR_Debug.Func_Log("세이브 파일 존재하지 않음");
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
                    DR_Debug.Func_RedLog("세이브파일 캐싱 X 스테이터스", "Intro 씬부터 시작 바람");
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

                DR_Debug.Func_RedLog("세이브파일 캐싱 X 착용장비", "Intro 씬부터 시작 바람");
            }

            return null;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-06-25 </para>
        /// <para> 내    용 : Save XML 파일을 불러와 플레이어가 소유한 아이템 아이디를 반환하는 메서드 </para>
        /// </summary>
        public Dictionary<int, int> Func_GetLoadItem(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml";
            FileInfo _fileInfo = new FileInfo(_path);
            Dictionary<int, int> _dic = new Dictionary<int, int>();

            if (_fileInfo.Exists)
            {
                if (loadXMLDoc == null)
                {
                    Func_SellectLoadXML(_slotNum);
                }

                if (loadXMLDoc == null)
                {
                    DR_Debug.Func_RedLog("세이브파일 캐싱 X 아이템", "캐싱 안됨");
                    return _dic;
                }
                else
                {
                    XmlNodeList _nodes = loadXMLDoc.SelectNodes(DR_PathDefine.XML_Node_Inventory);

                    foreach (XmlElement _item in _nodes[0])
                    {
                        _dic[int.Parse(_item.GetAttribute(DR_PathDefine.XML_Key_ID))] =
                            int.Parse(_item.GetAttribute(DR_PathDefine.XML_Key_Count));
                    }
                }
            }

            return _dic;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-19 </para>
        /// <para> 내    용 : Save XML 파일을 불러와 스킬포인트를 반환하는 메서드 </para>
        /// </summary>
        public int Func_GetLoadSkillPoint(int _slotNum)
        {
            string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml";
            FileInfo _fileInfo = new FileInfo(_path);
            int _sp = 0;
            if (_fileInfo.Exists)
            {
                if (loadXMLDoc == null)
                {
                    Func_SellectLoadXML(_slotNum);
                }
                if (loadXMLDoc == null)
                {
                    DR_Debug.Func_RedLog("세이브파일 캐싱 X 아이템", "캐싱 안됨");
                    return _sp;
                }
                else
                {
                    XmlNodeList _nodes = loadXMLDoc.SelectNodes(DR_PathDefine.XML_Node_Status);

                    _sp = int.Parse(_nodes[0].SelectSingleNode(DR_PathDefine.XML_NodeName_SkillPoint).InnerText);
                }
            }

            return _sp;
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-07-13 </para>
        /// <para> 내    용 : Save XML 파일을 불러와 스킬의 부적스킬들을 반환하는 메서드 </para>
        /// </summary>
        public Dictionary<string, int> Func_GetLoadAmuletSkill(int _slotNum)
        {
            Dictionary<string, int> _dic = new Dictionary<string, int>();

            string _path = Application.dataPath + DR_PathDefine.XML_SavePath + DR_PathDefine.XML_SaveName + _slotNum + ".xml";
            FileInfo _fileInfo = new FileInfo(_path);

            if (_fileInfo.Exists)
            {
                if (loadXMLDoc == null)
                {
                    Func_SellectLoadXML(_slotNum);
                }
                if (loadXMLDoc == null)
                {
                    DR_Debug.Func_RedLog("세이브파일 캐싱 X 아이템", "캐싱 안됨");
                    return _dic;
                }
                else
                {
                    XmlNodeList _nodes = loadXMLDoc.SelectNodes(DR_PathDefine.XML_Node_Skill);

                    foreach (XmlElement _item in _nodes[0])
                    {
                        _dic[_item.GetAttribute(DR_PathDefine.XML_Key_ID)] =
                            int.Parse(_item.GetAttribute(DR_PathDefine.XML_Key_SP));
                    }
                }
            }

            return _dic;
        }

        #endregion

        #region Save XML
         
        public void Func_SaveSlotXML(int _slotNum, DR_SaveInformation _saveInfo)
        {
            // 스크린샷 찍기
            DR_ScreenShot.Func_SaveScreenShot(_slotNum);

            XmlDocument _xmlDoc = loadXMLDoc;
            DR_PlayerManager _playerManager = DR_PlayerManager.Instance;

            _saveInfo.saveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _saveInfo.captureName = DR_PathDefine.ScreenShot_SaveName + _slotNum + ".png";

            #region 슬롯 정보 저장

            XmlNodeList _slotNode = _xmlDoc.SelectNodes(DR_PathDefine.XML_Node_SaveSlot);
            XmlNode _slotInfo = _slotNode[0];

            _slotInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_1).InnerText = _saveInfo.saveTime;
            _slotInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_2).InnerText = DR_ProgramManager.Instance.Func_GetPlayTime();
            _slotInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_3).InnerText = _saveInfo.csvReadLine.ToString();
            _slotInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_4).InnerText = _saveInfo.chapter;
            _slotInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_5).InnerText = _saveInfo.gold.ToString();
            _slotInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_6).InnerText = _saveInfo.captureName;
            _slotInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_SaveInformation_7).InnerText = _saveInfo.isCommunication.ToString();

            #endregion

            #region 스테이터스 저장

            XmlNodeList _statusNode = _xmlDoc.SelectNodes(DR_PathDefine.XML_Node_Status);
            XmlNode _statusInfo = _statusNode[0];

            _statusInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_Status_1).InnerText = _playerManager.status.level.ToString();
            _statusInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_Status_2).InnerText = _playerManager.status.exe.ToString();
            _statusInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_Status_3).InnerText = _playerManager.status.power.ToString();
            _statusInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_Status_4).InnerText = _playerManager.status.dex.ToString();
            _statusInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_Status_5).InnerText = _playerManager.status.health.ToString();
            _statusInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_Status_6).InnerText = _playerManager.status.patience.ToString();
            _statusInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_SkillPoint).InnerText = _playerManager.sp.ToString();

            #endregion

            #region 장착 장비 저장

            XmlNodeList _equipNode = _xmlDoc.SelectNodes(DR_PathDefine.XML_Node_WearingEquipment);
            XmlNode _equipInfo = _equipNode[0];

            _equipInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_1).InnerText = _playerManager.wearingEquipment.weapon;
            _equipInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_2).InnerText = _playerManager.wearingEquipment.ring;
            _equipInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_3).InnerText = _playerManager.wearingEquipment.necklace;
            _equipInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_4).InnerText = _playerManager.wearingEquipment.wristband;
            _equipInfo.SelectSingleNode(DR_PathDefine.XML_NodeName_WearingEquip_5).InnerText = _playerManager.wearingEquipment.amulet;

            #endregion

            #region 스킬 저장



            #endregion

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