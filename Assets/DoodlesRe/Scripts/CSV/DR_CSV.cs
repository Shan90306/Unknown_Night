using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para>작 성 자 : 이승엽 </para>
    /// <para>작 성 일 : 2021-05-18 </para>
    /// <para>내    용 : CSV파일을 읽어오는 클래스 </para>
    /// </summary>
    public class DR_CSV : MonoBehaviour
    {
        static string SPLIT = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        static string LINE_SPLIT = @"\r\n|\n\r|\n|\r";
        static char[] TRIM_CHAR_ARR = { '\"' };

        public static List<Dictionary<string, object>> Func_Read(string _file)
        {
            string _path = Application.dataPath + DR_PathDefine.CSV_SavePath + _file;
            var _list = new List<Dictionary<string, object>>();
            FileInfo _fileInfo = new FileInfo(_path);

            if (_fileInfo.Exists)
            {
                //TextAsset _data = Resources.Load(_file) as TextAsset;
                StreamReader _sr = new StreamReader(_path);
                string _sorce = _sr.ReadToEnd();
                _sr.Close();

                var _line = Regex.Split(_sorce, LINE_SPLIT);
                if (_line.Length <= 1)
                {
                    return _list;
                }

                var _header = Regex.Split(_line[0], SPLIT);
                for (int i = 1; i < _line.Length; i++)
                {
                    var _values = Regex.Split(_line[i], SPLIT);
                    if (_values.Length == 0 || _values[0] == "")
                    {
                        continue;
                    }

                    var _entry = new Dictionary<string, object>();
                    for (int j = 0; j < _header.Length && j < _values.Length; j++)
                    {
                        string _value = _values[j];
                        _value = _value.TrimStart(TRIM_CHAR_ARR).TrimEnd(TRIM_CHAR_ARR).Replace("\\", "");
                        _value = _value.Replace("<br>", "\n");
                        _value = _value.Replace("<c>", ",");

                        object _finalValue = _value;
                        int _n;
                        float _f;

                        if (int.TryParse(_value, out _n))
                        {
                            _finalValue = _n;
                        }
                        else if (float.TryParse(_value, out _f))
                        {
                            _finalValue = _f;
                        }

                        _entry[_header[j]] = _finalValue;
                    }

                    _list.Add(_entry);
                }
            }

            return _list;
        }
    }
}