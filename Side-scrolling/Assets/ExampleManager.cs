using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[System.Serializable]
public class MemberForm
{
    public string Name;
    public int Age;

    public MemberForm(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
// 회원가입
// 로그인


public class ExampleManager : MonoBehaviour
{
    string URL = "https://script.google.com/macros/s/AKfycbzUO8EkTbTm-vESBioS89cJVdACLDY1xaK197eBOtF7O8MiPMHSR0VLf1HCjhiYOVyL/exec";

    IEnumerator Start()
    {
        // ** 요청을 하기위한 작업.
        MemberForm member = new MemberForm("변사또", 45);

        WWWForm form = new WWWForm();

        form.AddField("Name", member.Name);
        form.AddField("Age", member.Age);

        using (UnityWebRequest request = UnityWebRequest.Post(URL, form))
        {
            yield return request.SendWebRequest();

            // ** 응답에 대한 작업.
            print(request.downloadHandler.text);
        }        
    }
}
