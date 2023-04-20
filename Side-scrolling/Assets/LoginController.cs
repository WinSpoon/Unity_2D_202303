using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

public class LoginController : MonoBehaviour
{
    string URL = "https://script.google.com/macros/s/AKfycbzUO8EkTbTm-vESBioS89cJVdACLDY1xaK197eBOtF7O8MiPMHSR0VLf1HCjhiYOVyL/exec";

    public InputField emailInputField;
    private string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

    public InputField passwordInputField;
    public Text message;

    void Start()
    {
        message.text =  "";
    }

    public void LoginCheck()
    {
        string email = emailInputField.text;

        if(Regex.IsMatch(email, emailPattern))
        {
            // ** true
            string password = Security(passwordInputField.text);

            print(password);

            // ** login

            


        }
        else
        {
            // ** false
            message.text = "email 형식을 다시 확인하세요! ";
        }
    }

    string Security(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            // ** true
            message.text = "password는 필수 입력 값 입니다.";
            return "null";
        }
        else
        {
            // ** 암호화 & 복호화
            // ** false
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }

            return stringBuilder.ToString();
        }
    }
}









// ** UTF-8 인코딩 설정
//request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(form.data.ToString()));
//request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");