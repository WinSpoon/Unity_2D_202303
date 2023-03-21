using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidebarController : MonoBehaviour
{
    public GameObject sidebar;
    private Animator Anim;
    public bool check;

    private void Awake()
    {
        Anim = sidebar.GetComponent<Animator>();
    }

    void Start()
    {
        check = false;
    }

    public void ClickButton()
    {
        check = !check;
        Anim.SetBool("Move", check);
    }
}
