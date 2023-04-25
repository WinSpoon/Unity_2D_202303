using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeController : MonoBehaviour
{
    // ** 0 ~ 180
    [Range(0.0f, 180.0f)]
    public float Angle = 90.0f;
    
    // ** 가상의 선의 개수
    [Range(10, 360)]
    public int Segments = 30;

    // **  반지름
    [Range(1.0f, 50.0f)]
    public float radius = 5.0f;

    public List<Vector3> PointList = new List<Vector3>();

    void Start()
    {
        Angle = 45.0f;
        Segments = 30;
        radius = 5.0f;


#if UNITY_EDITOR

#else

#endif
    }

    void Update()
    {
#if UNITY_EDITOR

#else

#endif
    }
}
