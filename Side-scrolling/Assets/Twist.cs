using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twist : MonoBehaviour
{
    public float Angle;
    public float Speed;
    public Sprite sprite;

    private GameObject[] Bullet = new GameObject[2];

    private void Start()
    {
        GameObject ParentObj = new GameObject("Twist");

        SpriteRenderer renderer = ParentObj.AddComponent<SpriteRenderer>();

        renderer.sprite = sprite;


        Angle = 0.0f;
        Speed = 5.0f;
             
        Bullet[0] = new GameObject("TwistBullet");

        Bullet[0].transform.SetParent(transform);

        Bullet[0].AddComponent<MyGizmo>();

        Bullet[0].transform.position = new Vector3(
            transform.position.x,
            transform.position.y - 1.25f,
            0.0f);


        Bullet[1] = new GameObject("TwistBullet");

        Bullet[1].transform.SetParent(transform);

        Bullet[1].AddComponent<MyGizmo>();

        Bullet[1].transform.position = new Vector3(
            transform.position.x,
            transform.position.y + 1.25f,
            0.0f);
    }

    void Update()
    {
        Angle += 1.0f;

        Bullet[0].transform.position += new Vector3(
                1.0f,
                Mathf.Sin(Angle * Mathf.Deg2Rad),
                0.0f) * Speed * Time.deltaTime;

        Bullet[1].transform.position += new Vector3(
                1.0f,
                Mathf.Sin(-Angle * Mathf.Deg2Rad),
                0.0f) * Speed * Time.deltaTime;
    }
}
