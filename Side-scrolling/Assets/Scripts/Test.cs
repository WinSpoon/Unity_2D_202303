using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private Text ui;

    public GameObject Player;
    public GameObject test;

    void Start()
    {
        ui = GetComponent<Text>();

        // ** ���� ���ϴ� ����
        Vector3 Direction = (Player.transform.position - test.transform.position).normalized;
        transform.position += Direction * Time.deltaTime * 2.0f;
    }

    void Update()
    {
        /*
         * �Ÿ� ���ϴ� ����.
        {
            float x = Player.transform.position.x - test.transform.position.x;
            float y = Player.transform.position.y - test.transform.position.y;

            float distance = Mathf.Sqrt((x * x) + (y * y));
        }
         */

        /* ���� ���ϴ� ����1
        Vector3 Direction = new Vector3(
            Player.transform.position.x - test.transform.position.x,
            Player.transform.position.y - test.transform.position.y,
            0.0f);

        Direction.Normalize();
        */


        /* ���� ���ϴ� ����2
        Vector3 Direction = Player.transform.position - test.transform.position;
        Direction.Normalize();
        */

        



        /*
        float distance = Vector3.Distance(
            Player.transform.position, 
            test.transform.position);
         */

        //ui.text = distance.ToString();
        //test.GetComponent<MyGizmo>().color = distance > 5.0f ? Color.green : Color.red;
    }
}
