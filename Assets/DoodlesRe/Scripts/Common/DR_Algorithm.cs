using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-03 </para>
    /// <para> 내    용 : 알고리즘을 담당하는 클래스 </para>
    /// </summary>
    class DR_Algorithm
    {
        #region 퀵 정렬을 사용한 이미지의 이름 정렬

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.04.13 </para>
        /// <para> 내    용 : 아이템 이미지들을 이름대로 정렬 </para>
        /// </summary>
        public static void Func_ImageNameSort(Sprite[] _imageArr, int[] _imageNameArr, int _pivot, int _right)
        {
            if (_pivot < _right)
            {
                int _left = Func_Partition(_imageArr, _imageNameArr, _pivot, _right);
                Func_ImageNameSort(_imageArr, _imageNameArr, _pivot, _left - 1);
                Func_ImageNameSort(_imageArr, _imageNameArr, _left + 1, _right);
            }
        }

        static int Func_Partition(Sprite[] _imageArr, int[] _imageNameArr, int _pivot, int _right)
        {
            int _left = _pivot;

            for (int i = _pivot; i < _right; i++)
            {
                if (_imageNameArr[i] <= _imageNameArr[_right])
                {
                    Func_Swap(_imageArr, _left, i);
                    Func_SwapInteger(_imageNameArr, _left, i);
                    _left++;
                }
            }

            Func_Swap(_imageArr, _left, _right);
            Func_SwapInteger(_imageNameArr, _left, _right);
            return _left;
        }

        static void Func_Swap(Sprite[] _imageArr, int _beforeIndex, int _afterIndex)
        {
            Sprite _tmp = _imageArr[_beforeIndex];
            _imageArr[_beforeIndex] = _imageArr[_afterIndex];
            _imageArr[_afterIndex] = _tmp;
        }

        static void Func_SwapInteger(int[] _imageNameArr, int _beforeIndex, int _afterIndex)
        {
            int _tmp = _imageNameArr[_beforeIndex];
            _imageNameArr[_beforeIndex] = _imageNameArr[_afterIndex];
            _imageNameArr[_afterIndex] = _tmp;
        }

        #endregion

        #region 이진탐색

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-03 </para>
        /// <para> 내    용 : 이진탐색을 이용한 번호 찾는 기능 </para>
        /// </summary>
        public static int Func_SearchNumber(int[] _dataArr, int _data)
        {
            int _right = _dataArr.Length - 1;
            for (int _left = 0; _left <= _right; )
            {
                int _middle = (_left + _right) / 2;
                if (_data > _dataArr[_middle])
                    _left = _middle + 1;
                else if (_data < _dataArr[_middle])
                    _right = _middle - 1;
                else
                    return _middle;
            }

            // 발견되지 않음
            return -1;  
        }

        #endregion
    }
}