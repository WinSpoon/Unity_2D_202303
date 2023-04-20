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
// 회원가입
// 로그인


public class ExampleManager : MonoBehaviour
{
    string URL = "https://script.google.com/macros/s/AKfycbzUO8EkTbTm-vESBioS89cJVdACLDY1xaK197eBOtF7O8MiPMHSR0VLf1HCjhiYOVyL/exec";

    public InputField emailInputField;
    private string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

    /*
     [\w-\.]+ : 영숫자 문자, 하이픈(-) 또는 마침표(.)가 하나 이상 반복되는 부분을 찾습니다. 이것은 이메일 주소의 로컬 부분(local part)에 해당합니다.
    @ : '@' 문자를 찾습니다. 이것은 이메일 주소의 로컬 부분과 도메인 부분 사이에 있습니다.
    ([\w-]+\.)+ : 영숫자 문자 또는 하이픈(-)이 하나 이상 반복되고, 그 뒤에 마침표(.)가 있는 부분을 찾습니다. 이것은 도메인 주소의 첫 번째 부분과 뒤따르는 하위 도메인에 해당합니다.
    [\w-]{2,4} : 영숫자 문자 또는 하이픈(-)이 2~4회 반복되는 부분을 찾습니다. 이것은 도메인 주소의 최상위 도메인에 해당합니다 (예: .com, .org, .net 등).
    $ : 문자열의 끝을 나타냅니다.
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
            // ** 요청을 하기위한 작업.
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.Success)
            {
                // ** 응답에 대한 작업.
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
                message.text = "password 는 필수 입력 값 입니다.";
            }
            else
                StartCoroutine(Request(email, password, 1));
        }
        else
        {
            // 이메일이 유효하지 않은 경우 오류 메시지 표시 또는 사용자에게 알림
            message.text = "email 이 잘못된 형식 입니다.";
        }
    }


    /*
    void function()
    {
        // ** 게스트 모드 식별자
        //System.Guid uid = System.Guid.NewGuid();
        //return uid.ToString();
    }
     */

}
