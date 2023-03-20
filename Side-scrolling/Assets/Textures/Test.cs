using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private List<GameObject> Images = new List<GameObject>();
    private List<GameObject> Buttons = new List<GameObject>();
    private List<Image> ButtonImages = new List<Image>();
    private float cooldown;

    private void Start()
    {
        GameObject SkillsObj = GameObject.Find("Skills");

        for (int i = 0; i < SkillsObj.transform.childCount; ++i)
            Images.Add(SkillsObj.transform.GetChild(i).gameObject);

        for (int i = 0; i < 1; ++i)
            Buttons.Add(Images[i].transform.GetChild(0).gameObject);

        for (int i = 0; i < Buttons.Count; ++i)
            ButtonImages.Add(Buttons[i].GetComponent<Image>());

        cooldown = 0.0f;
    }


    public void PushButton()
    {
        ButtonImages[0].fillAmount = 0;
        Buttons[0].GetComponent<Button>().enabled = false;

        StartCoroutine(PushButton_Coroutine());
    }

    IEnumerator PushButton_Coroutine()
    {
        float cool = cooldown;

        while (ButtonImages[0].fillAmount != 1)
        {
            ButtonImages[0].fillAmount += Time.deltaTime * cool;
            yield return null;
        }

        Buttons[0].GetComponent<Button>().enabled = true;
    }

    public void Testcase1()
    {
        cooldown = 0.5f;
        ControllerManager.GetInstance().BulletSpeed += 0.025f;
    }

    public void Testcase2()
    {
        print("테스트 메세지 2 입니다.");
    }

    public void Testcase3()
    {
        print("테스트 메세지 3 입니다.");
    }

    public void Testcase4()
    {
        print("테스트 메세지 4 입니다.");
    }

    public void Testcase5()
    {
        print("테스트 메세지 5 입니다.");
    }
}