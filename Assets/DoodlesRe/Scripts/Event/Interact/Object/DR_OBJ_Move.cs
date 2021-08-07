using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DoodlesRe
{

    public class DR_OBJ_Move : DR_InteractObject
    {
        [Header("- SETTING")]
        [SerializeField] private Transform[] movePointArr;
        [SerializeField] private LoopType loopType;
        [SerializeField] private float moveTime;

        protected override void Func_Move()
        {
            Sequence _sequence = DOTween.Sequence();
            for (int i = 0; i < movePointArr.Length; i++)
            {
                _sequence.Append(transform.DOMove(movePointArr[i].position, moveTime)
                    .SetEase(Ease.Linear));
            }

            _sequence.SetLoops(-1, loopType);
        }
    }
}