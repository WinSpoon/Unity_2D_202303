using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{

    private Slider HPBar;

    private void Awake()
    {
        HPBar = GetComponent<Slider>();
    }

    private void Start()
    {
        HPBar.maxValue = ControllerManager.GetInstance().Player_HP;
        HPBar.value = HPBar.maxValue;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            ControllerManager.GetInstance().Player_HP -= 1;
        }

        if (Input.GetMouseButton(1))
        {
            ControllerManager.GetInstance().Player_HP += 1;
        }


        HPBar.value = ControllerManager.GetInstance().Player_HP;

        if(ControllerManager.GetInstance().Player_HP <= 0)
        {

        }
    }

}
