using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeController : MonoBehaviour
{
    // ** 0 ~ 180
    [Range(0.0f, 360.0f)]
    public float Angle = 90.0f;
     

    // ** 가상의 선의 개수
    [Range(10, 72)]
    public int Segments = 30;


    // **  반지름
    [Range(1.0f, 50.0f)]
    public float radius = 5.0f;

    public List<Vector3> PointList = new List<Vector3>();

    private MeshFilter meshFilter;
    private Mesh mesh;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh();
    }

    void Start()
    {
        Angle = 90.0f;
        Segments = 36;
        radius = 5.0f;

#if UNITY_EDITOR

#else

#endif
    }

    void Update()
    {
        // ** 0.0 좌표를 포함해야 하기 때문에 Segments + 1의 값으로 초기화.
        int PointCount = Segments + 1;

        // ** 버텍스의 개수만큼 생성.
        Vector3[] vertices = new Vector3[PointCount];

        // ** 첫번째 원소값은 0.0f (시작 지점)
        vertices[0] = Vector3.zero;

        // ** 만약 Angle 이 180도 라면 기준값으로부터 -90의 위치부터 시작해야 하므로
        // ** (Angle * 0.5f)의 값을 기준값에서 빼준다.
        // ** Angle  = 180 이므로, (180 * 0.5f) = 90
        // ** 기준 값은 = transform.eulerAngles.y
        // ** 결과적으로 transform.eulerAngles.y - 90 으로 볼 수 있다.
        float deltaAngle = transform.eulerAngles.y - (Angle * 0.5f);

        // ** int i = 1 부터 시작해야한다.
        for (int i = 1; i < vertices.Length; ++i)
        {
            // ** 부채꼴을 형성하는 계산.
            Vector3 point = new Vector3(
                Mathf.Sin(deltaAngle * Mathf.Deg2Rad),
                0.0f,
                Mathf.Cos(deltaAngle * Mathf.Deg2Rad));


            Ray ray = new Ray(transform.position, point.normalized);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, radius))
                vertices[i] = hit.point;
            else
                vertices[i] = point * radius;

            deltaAngle += Angle / (Segments-1);
        }


        /* [두르기]
         * 하나의 면을 이룰 수 있는 최소 단위 = 폴리곤
         * 하나의 폴리곤은 3개의 버텍스가 필요하고,
         * 버텍스의 개수가 3개라면 그 세 점을 잇는 순서가 필요하다.
         * 예를들어 버텍스의 개수가 4개라면 세점을 잇는 두리기 순서는 2개가 필요하고,
         * 버텍스의 개수가5개라면 3개의 삼각형이 만들어지기 때문에 두르기 순서도 3개가 필요하다.
         * 
         * 공식 = [(버텍스 개수 - 2) * 3]
         */
        int[] triangles = new int[(PointCount - 2) * 3];

        // ** 순서를 삼각형 마다 설정.
        for (int i = 0; i < PointCount - 2; ++i)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        // ** 이전 삼각형의 위치가 포함되어 그려질 수 있기 때문에 항상 지워줘야 한다.
        mesh.Clear();

        // ** 실제 매쉬에 적용.
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // ** 매쉬를 필터에 적용
        meshFilter.mesh = mesh;


#if UNITY_EDITOR

#else

#endif
    }
}
