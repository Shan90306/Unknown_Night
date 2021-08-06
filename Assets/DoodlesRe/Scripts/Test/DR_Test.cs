using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DoodlesRe
{
    /// <summary>
    /// 테스트용 클래스
    /// </summary>
    public class DR_Test : MonoBehaviour
    {
        public Transform[] posArr;
        public float time;

        private void Start()
        {
            Sequence aa = DOTween.Sequence();
            aa.Append(transform.DOMove(posArr[0].position, time)
                .SetEase(Ease.Linear));
            //aa.Append(transform.DOMove(posArr[1].position, time)
            //    .SetEase(Ease.Linear));
            aa.SetLoops(-1, LoopType.Yoyo);
            aa.SetSpeedBased(true);
            aa.Play();
        }

    }
}