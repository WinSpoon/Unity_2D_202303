using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern : MonoBehaviour
{
    public enum Pattern
    {
        ScrewPattern,
        B, C, D, E, F, G
    };

    public Pattern pattern;

    public List<GameObject> BulletList = new List<GameObject>();

    void Start()
    {
        pattern = Pattern.ScrewPattern;

        switch (pattern)
        {
            case Pattern.ScrewPattern:
                GetScrewPattern();
                break;

            case Pattern.B:

                break;

            case Pattern.C:

                break;

            case Pattern.D:

                break;

            case Pattern.E:

                break;

            case Pattern.F:

                break;

            case Pattern.G:

                break;
        }
    }

    private void GetScrewPattern()
    {
        float fAngle = 5.0f;

        int iCount = (int)(360 / fAngle);

        for (int i = 0; i < iCount; ++i)
        {
            GameObject Obj = new GameObject("Bullet");

            Obj.AddComponent<MyGizmo>();

            fAngle += 5.0f;
            Obj.transform.position = new Vector3(
                Mathf.Cos(fAngle * 3.141592f / 180),
                Mathf.Sin(fAngle * 3.141592f / 180),
                0.0f) * 5 + transform.position;

            BulletList.Add(Obj);
        }
    }
}
