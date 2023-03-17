using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Target;

    public float Speed;
    public int HP;
    private Animator Anim;
    private Vector3 Movement;

    private float CoolDown;
    private bool Attack;
    private bool SkillAttack;

    private void Awake()
    {
        Target = GameObject.Find("Player");

        Anim = GetComponent<Animator>();
    }

    void Start()
    {
        Speed = 0.2f;
        Movement = new Vector3(1.0f, 0.0f, 0.0f);
        HP = 3;

        Attack = false;
        SkillAttack = true;
        CoolDown = 5.0f;
    }

    void Update()
    {
        Movement = ControllerManager.GetInstance().DirRight ? 
            new Vector3(Speed + 1.0f, 0.0f, 0.0f) : new Vector3(Speed, 0.0f, 0.0f);

        float Distance = Vector3.Distance(Target.transform.position, transform.position);

        if (Distance < 0.5f)
        {
            Attack = true;
            Anim.SetTrigger("Attack");
        }
        else if (Distance < 8.0f && !Attack)
        {
            if (SkillAttack)
            {
                Attack = true;
                SkillAttack = false;
                StartCoroutine(Skill());
            }
        }
        else
        {
            Attack = false;
        }

        if(!Attack)
        {
            Anim.SetFloat("Speed", Movement.x);
            transform.position -= Movement * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            --HP;

            if(HP <= 0 )
            {
                Anim.SetTrigger("Die");
                GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }

    IEnumerator Skill()
    {
        Anim.SetTrigger("Skill");

        while(CoolDown > 0.0f)
        {
            CoolDown -= Time.deltaTime;
            yield return null;
        }

        CoolDown = 5.0f;
        SkillAttack = true;
    }


    private void DestroyEnemy()
    {
        Destroy(gameObject, 0.016f);
    }
}
