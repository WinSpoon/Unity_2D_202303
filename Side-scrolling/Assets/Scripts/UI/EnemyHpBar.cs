using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpBar : MonoBehaviour
{
    // ** 따라다닐 객체
    public GameObject Target;

    // ** 세부위치 조정
    private Vector3 offset;


    private void Start()
    {
        // ** 위치 셋팅
        offset = new Vector3(0.0f, 0.6f, 0.0f);
    }

    private void Update()
    {
        // ** WorldToScreenPoint = 월드좌표를 카메라 좌표로 변환.
        // ** 월드상에 있는 타겟의 좌표를 카메라 좌표로 변환하여, UI에 셋팅한다.
        transform.position = Camera.main.WorldToScreenPoint(Target.transform.position + offset);
    }
}
