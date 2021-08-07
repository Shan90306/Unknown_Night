using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{

    public class DR_Monster : DR_Character
    {
        [Header("- 몬스터 능력")]
        [SerializeField] private int currentHP;     // 현재 HP

        public int CurrentHP
        {
            get
            {
                return currentHP;
            }
        }

    }
}