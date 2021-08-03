using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2021-08-03 </para>
    /// <para> 내    용 : 아이템 데이터를 가지고 있는 스크립터블 오브젝트 클래스 </para>
    /// </summary>
    [CreateAssetMenu(fileName = "Setting_Item", menuName = "DoodlesRe/Setting_Item", order = int.MinValue)]
    public class DR_Setting_Item : DR_BaseScriptableObject
    {
        [Header("- 아이템 이미지 배열")]
        public Sprite[] sprite_ItemArr;

        private int[] itemNameArr;       // 아이템 이름의 숫자 배열


        public override void Func_Init()
        {
            Func_SetItemNameArr();                  // 아이템 이름들을 정수형으로 저장
            DR_Algorithm.Func_ImageNameSort(sprite_ItemArr, itemNameArr, 0, sprite_ItemArr.Length - 1);  // 아이템 순서 정렬
        }

        #region 아이템 이미지의 이름을 모두 정수형으로 저장

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021.04.13 </para>
        /// <para> 내    용 : 아이템 이미지들의 이름을 숫자로 변환하여 저장 </para>
        /// </summary>
        private void Func_SetItemNameArr()
        {
            itemNameArr = new int[sprite_ItemArr.Length];

            for (int i = 0; i < sprite_ItemArr.Length; i++)
            {
                itemNameArr[i] = int.Parse(sprite_ItemArr[i].name);
            }
        }

        #endregion

        #region 기능들

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2021-08-03 </para>
        /// <para> 내    용 : 아이템의 아이디에 따라 그에 맞는 이미지를 불러오는 기능 </para>
        /// </summary>
        /// <param name="_id">아이템의 아이디 값</param>
        /// <returns>아이디에 맞는 이미지, 없으면 null</returns>
        public Sprite Func_GetIDImage(int _id)
        {
            int _data = DR_Algorithm.Func_SearchNumber(itemNameArr, _id);
            if ( _data != -1)
            {
                return sprite_ItemArr[_data];
            }

            return null;
        }

        #endregion
    }
}