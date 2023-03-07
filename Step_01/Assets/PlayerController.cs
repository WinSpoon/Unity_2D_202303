using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [2의 보수]
// 0 0000000 
//    0 0000001 = 1
// - 0 0000010 = 2
//--------------
// 1 - 2 = 1 + (-2)
// 1 + (-2)

//    0 0000001 = 1
// + 11111110 = (-2)
//--------------
//    11111111 = (-1)
//    00000001 = 1


// 0 0000100 = 4
// 0 0001000 = 8
// 0 0010000 = 16
// 0 0100000 = 32
// 0 1000000 = 64
// 1 1111111 =  128


public class PlayerController : MonoBehaviour
{
    // ** 움직이는 속도
    private float Speed;
    private Vector3 Movement;

    private Animator animator;

    private bool onAttack;
    private bool onHit;


    // ** 유니티 기본 제공 함수
    // ** 초기값을 설정할 때 사용
    void Start()
    {
        // ** 속도를 초기화.
        Speed = 5.0f;

        // ** player 의 Animator를 받아온다.
        animator = this.GetComponent<Animator>();

        onAttack = false;

        onHit = false;
    }

    // ** 유니티 기본 제공 함수
    // ** 프레임마다 반복적으로 실행되는 함수.
    void Update()
    {
        // ** [실수 연산 IEEE754]

        // **  Input.GetAxis =     -1 ~ 1 사이의 값을 반환함. 
        float Hor = Input.GetAxisRaw("Horizontal"); // -1 or 0 or 1 셋중에 하나를 반환.
        float Ver = Input.GetAxis("Vertical"); // -1 ~ 1 까지 실수로 반환.

        Movement = new Vector3(
            Hor * Time.deltaTime * Speed,
            Ver * Time.deltaTime * Speed,
            0.0f);

        if (Input.GetKey(KeyCode.LeftControl))
            OnAttack();

        if (Input.GetKey(KeyCode.LeftShift))
            OnHit();

        animator.SetFloat("Speed", Hor);
        transform.position += Movement;
    }

    private void OnAttack()
    {
        if (onAttack)
            return;

        onAttack = true;
        animator.SetTrigger("Attack");
    }

    private void SetAttack()
    {
        onAttack = false;
    }

    private void OnHit()
    {
        if (onHit)
            return;

        onHit = true;
        animator.SetTrigger("Hit");
    }

    private void SetHit()
    {
        onHit = false;
    }
}
