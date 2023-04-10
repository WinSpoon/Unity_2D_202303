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
// ȸ������
// �α���


public class ExampleManager : MonoBehaviour
{
    string URL = "https://script.google.com/macros/s/AKfycbzUO8EkTbTm-vESBioS89cJVdACLDY1xaK197eBOtF7O8MiPMHSR0VLf1HCjhiYOVyL/exec";

    IEnumerator Start()
    {
        // ** ��û�� �ϱ����� �۾�.
        MemberForm member = new MemberForm("�����", 45);

        WWWForm form = new WWWForm();

        form.AddField("Name", member.Name);
        form.AddField("Age", member.Age);

        using (UnityWebRequest request = UnityWebRequest.Post(URL, form))
        {
            yield return request.SendWebRequest();

            // ** ���信 ���� �۾�.
            print(request.downloadHandler.text);
        }        
    }
}
