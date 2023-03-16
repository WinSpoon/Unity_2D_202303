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

        // ** 방향 구하는 공식
        Vector3 Direction = (Player.transform.position - test.transform.position).normalized;
        transform.position += Direction * Time.deltaTime * 2.0f;
    }

    void Update()
    {
        /*
         * 거리 구하는 공식.
        {
            float x = Player.transform.position.x - test.transform.position.x;
            float y = Player.transform.position.y - test.transform.position.y;

            float distance = Mathf.Sqrt((x * x) + (y * y));
        }
         */

        /* 방향 구하는 공식1
        Vector3 Direction = new Vector3(
            Player.transform.position.x - test.transform.position.x,
            Player.transform.position.y - test.transform.position.y,
            0.0f);

        Direction.Normalize();
        */


        /* 방향 구하는 공식2
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
