using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScopeController))]
public class ScopeEditor : Editor
{
    /*
    private void OnSceneGUI()
    {
        ScopeController targetCompnemt = (ScopeController)target;

        Handles.DrawWireArc(targetCompnemt.transform.position, Vector3.up, Vector3.forward, 360.0f, targetCompnemt.radius);

        float Segments = targetCompnemt.Angle / targetCompnemt.Segments;

        for (int i = 0; i < targetCompnemt.Segments + 1; ++i)
        {
            Vector3 angleLeftPoint = new Vector3(
               Mathf.Sin(-(Segments * i) * Mathf.Deg2Rad),
               0.0f,
               Mathf.Cos(-(Segments * i) * Mathf.Deg2Rad));

            Vector3 angleRightPoint = new Vector3(
               Mathf.Sin((Segments * i) * Mathf.Deg2Rad),
               0.0f,
               Mathf.Cos((Segments * i) * Mathf.Deg2Rad));

            Handles.DrawLine(targetCompnemt.transform.position,
                targetCompnemt.transform.position + angleLeftPoint * targetCompnemt.radius);

            Handles.DrawLine(targetCompnemt.transform.position,
                targetCompnemt.transform.position + angleRightPoint * targetCompnemt.radius);
        }
    }
     */
}
