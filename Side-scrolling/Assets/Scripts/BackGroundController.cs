using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    // ** BackGround 가 모여있는 계층구조의 최상위 객체(부모)
    private Transform parent;

    // ** Sprite를 포함하고 있는 구성요소
    private SpriteRenderer spriteRenderer;

    // ** 이미지
    private Sprite sprite;

    // ** 생성지점
    private float endPoint;

    // ** 삭제 지점.
    private float exitPoint;

    // ** 이미지 이동속도
    public float Speed;

    // ** 플레이어 정보
    private GameObject player;

    // ** 움직임 정보
    private Vector3 movemane;

    // ** 이미지가 중앙 위치에 정상적으로 노출될 수 있도록 하기 위한 완충역할.
    private Vector3 offset = new Vector3(0.0f, 7.5f, 0.0f);

    private void Awake()
    {
        // ** 이미지를 담고있는 구성요소를 받아온다.
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ** 구성요소에 포함된 이미지를 받아온다.
        sprite = spriteRenderer.sprite;
    }

    void Start()
    {
        // ** 플레이어의 기본정보를 받아온다.
        player = GameObject.Find("Player").gameObject;

        // ** 부모객체를 받아온다.
        parent = GameObject.Find("BackGround").transform;

        // ** 시작지점을 설정.
        endPoint = sprite.bounds.size.x * 0.5f + transform.position.x;

        // ** 종료지점을 설정.
        exitPoint = -(sprite.bounds.size.x * 0.5f) + player.transform.position.x;
    }

    void Update()
    {
        // ** 이동정보 셋팅
        movemane = new Vector3(
            Input.GetAxisRaw("Horizontal") * Time.deltaTime * Speed + offset.x, // ** singleton
            player.transform.position.y + offset.y,
            0.0f + offset.z);

        // ** 이동정보 적용
        transform.position -= movemane;
        endPoint -= movemane.x;

        // ** 동일한 이미지 복사
        if (player.transform.position.x + (sprite.bounds.size.x * 0.5f) + 1 > endPoint)
        {
            // ** 이미지를 복제한다.
            GameObject Obj =  Instantiate(this.gameObject);

            // ** 본제된 이미지의 부모를 설정한다.
            Obj.transform.parent = parent.transform;

            // ** 복제된 이미지의 이름을 설정한다.
            Obj.transform.name = transform.name;

            // ** 복제된 이미지의 위치를 설정한다.
            Obj.transform.position = new Vector3(
                endPoint + 25.0f,
                0.0f, 0.0f);

            // ** 시작지점을 변경한다.
            endPoint += endPoint + 25.0f;
        }

        // ** 종료지점에 도달하면 삭제한다.
        if(transform.position.x + (sprite.bounds.size.x * 0.5f) - 2 < exitPoint)
            Destroy(this.gameObject);
    }
}
