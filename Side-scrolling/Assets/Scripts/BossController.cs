using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private GameObject Target;

    private Animator Anim;

    // ** 플레이어의 SpriteRenderer 구성요소를 받아오기위해...
    private SpriteRenderer renderer;

    private Vector3 Movement;

    private float CoolDown;
    private float Speed;
    private int HP;

    private bool SkillAttack;
    private bool Attack;
    private bool active;

    private void Awake()
    {
        Target = GameObject.Find("Player");

        Anim = GetComponent<Animator>();

        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        CoolDown = 1.5f ;
        Speed = 0.5f;
        HP = 30000;

        SkillAttack = false; 
        Attack = false;

        active = true;
    }

    void Update()
    {
        float result = Target.transform.position.x - transform.position.x;

        if (result < 0.0f)
            renderer.flipX = true;
        else if(result > 0.0f)
            renderer.flipX = false;

        if(active)
        {
            active = false;
            StartCoroutine(onCooldown());
        }
    }

    private IEnumerator onCooldown()
    {
        float fTime = CoolDown;

        while(fTime > 0.0f)
        {
            fTime -= Time.deltaTime;
            yield return null;
        }

        switch (Random.Range(0, 3))
        {
            case 0:
                onAttack();
                break;

            case 1:
                onWalk();
                break;

            case 2:
                onSlide();
                break;
        }
        active = true;
    }

    private void onAttack()
    {
        {
            print("onAttack");
        }
    }

    private void onWalk()
    {
        {
            print("onWalk");
        }
    }

    private void onSlide()
    {
        {
            print("onSlide");
        }
    }
}
