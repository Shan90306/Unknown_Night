using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoodlesRe
{

    public class DR_PlayerCameraController : MonoBehaviour
    {
        [Header("- 타겟")]
        [SerializeField] private Transform target;

        [Header("- 설정")]
        [SerializeField] private float posY;
        [SerializeField] private int Smoothvalue = 2;

        // Update is called once per frame
        void Update()
        {
            Vector3 Targetpos = new Vector3(target.transform.position.x, target.transform.position.y + posY, -100);
            transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * Smoothvalue);
        }
    }
}