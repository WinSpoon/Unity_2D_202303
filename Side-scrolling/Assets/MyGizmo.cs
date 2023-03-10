using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // ** Gizmos의 색을 변경한다.
        Gizmos.color = Color.red;

        // ** Gizmos 그린다
        Gizmos.DrawSphere(this.transform.position, 0.2f);
    }
}
