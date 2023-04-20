using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

[System.Serializable]
public class MemberForm
{
    public string userID;
    public string password;
    public int gender;

    public MemberForm(string userID, string password, int gender)
    {
        this.userID = userID;
        this.password = password;
        this.gender = gender;
    }
}
// ȸ������
// �α���


public class ExampleManager : MonoBehaviour
{
    string URL = "https://script.google.com/macros/s/AKfycbzUO8EkTbTm-vESBioS89cJVdACLDY1xaK197eBOtF7O8MiPMHSR0VLf1HCjhiYOVyL/exec";

    public InputField emailInputField;
    private string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

    /*
     [\w-\.]+ : ������ ����, ������(-) �Ǵ� ��ħǥ(.)�� �ϳ� �̻� �ݺ��Ǵ� �κ��� ã���ϴ�. �̰��� �̸��� �ּ��� ���� �κ�(local part)�� �ش��մϴ�.
    @ : '@' ���ڸ� ã���ϴ�. �̰��� �̸��� �ּ��� ���� �κа� ������ �κ� ���̿� �ֽ��ϴ�.
    ([\w-]+\.)+ : ������ ���� �Ǵ� ������(-)�� �ϳ� �̻� �ݺ��ǰ�, �� �ڿ� ��ħǥ(.)�� �ִ� �κ��� ã���ϴ�. �̰��� ������ �ּ��� ù ��° �κа� �ڵ����� ���� �����ο� �ش��մϴ�.
    [\w-]{2,4} : ������ ���� �Ǵ� ������(-)�� 2~4ȸ �ݺ��Ǵ� �κ��� ã���ϴ�. �̰��� ������ �ּ��� �ֻ��� �����ο� �ش��մϴ� (��: .com, .org, .net ��).
    $ : ���ڿ��� ���� ��Ÿ���ϴ�.
     */

    public InputField passwordInputField;
    public Text message;

    public string SHA256Hash(string data)
    {
        SHA256 sha = new SHA256Managed();
        byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
        StringBuilder stringBuilder = new StringBuilder();

        foreach (byte b in hash)
        {
            stringBuilder.AppendFormat("{0:x2}", b);
        }
        return stringBuilder.ToString();
    }

    IEnumerator Request(string userID, string password, int gender)
    {
        MemberForm member = new MemberForm(userID, SHA256Hash(password), gender);
        WWWForm form = new WWWForm();

        form.AddField("order", "sign up");
        form.AddField("name", member.userID);
        form.AddField("age", member.password);
        form.AddField("gender", member.gender);

        using (UnityWebRequest request = UnityWebRequest.Post(URL, form))
        {
            // ** ��û�� �ϱ����� �۾�.
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.Success)
            {
                // ** ���信 ���� �۾�.
                print(request.downloadHandler.text);
                SceneManager.LoadScene("progressScene");
            }
        }
    }

    public void NextScene()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        if (Regex.IsMatch(email, emailPattern))
        {
            if(string.IsNullOrEmpty(password))
            {
                message.text = "password �� �ʼ� �Է� �� �Դϴ�.";
            }
            else
                StartCoroutine(Request(email, password, 1));
        }
        else
        {
            // �̸����� ��ȿ���� ���� ��� ���� �޽��� ǥ�� �Ǵ� ����ڿ��� �˸�
            message.text = "email �� �߸��� ���� �Դϴ�.";
        }
    }


    /*
    void function()
    {
        // ** �Խ�Ʈ ��� �ĺ���
        //System.Guid uid = System.Guid.NewGuid();
        //return uid.ToString();
    }
     */

}
