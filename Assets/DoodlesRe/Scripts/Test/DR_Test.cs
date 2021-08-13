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
        public Animator anim;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetTrigger("Attack");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetTrigger("Move");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetTrigger("Hit");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("Die");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Idle");
            }
        }

    }
}