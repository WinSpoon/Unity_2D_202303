using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{
    // ** �Ѿ��� ���ư��� �ӵ�
    public float Speed;
    public GameObject Target; 

    public bool Option; 
    public float Angle; 
    

    // ** �Ѿ��� �浹�� Ƚ��
    //private int hp;

    // ** ����Ʈȿ�� ����
    public GameObject fxPrefab;

    // ** �Ѿ��� ���ư����� ����
    private Vector3 Direction { get; set; }

    private void Start()
    {
        // ** �ӵ� �ʱⰪ
        Speed = ControllerManager.GetInstance().BulletSpeed;

        // ** ������ ����ȭ.
        Direction = (Target.transform.position - transform.position).normalized;

        // ** �浹 Ƚ���� 3���� �����Ѵ�.
        //hp = 3;
    }

    void Update()
    {
        // ** �ǽð����� Ÿ���� ��ġ�� Ȯ���ϰ� ������ �����Ѵ�.
        if(Option)
            Direction = (Target.transform.position - transform.position).normalized;

        // ** �������� �ӵ���ŭ ��ġ�� ����
        transform.position += Direction * Speed * Time.deltaTime;
    }

    // ** �浹ü�� ���������� ���Ե� ������Ʈ�� �ٸ� �浹ü�� �浹�Ѵٸ� ����Ǵ� �Լ�. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ** �浹Ƚ�� ����.
        //--hp;

        // ** ����Ʈȿ�� ����.
        GameObject Obj = Instantiate(fxPrefab);

        // ** ����Ʈȿ���� ��ġ�� ����
        Obj.transform.position = transform.position;

        // ** collision = �浹�� ���.
        // ** �浹�� ����� �����Ѵ�. 
        if (collision.transform.tag == "wall")
            Destroy(this.gameObject);
        else
        {
            // ** ����ȿ���� ������ ������ ����.
            GameObject camera = new GameObject("Camera Test");

            // ** ���� ȿ�� ��Ʈ�ѷ� ����.
            camera.AddComponent<CameraController>();
        }

        // ** �Ѿ��� �浹 Ƚ���� 0�� �Ǹ� �Ѿ� ����.
        /*
        if (hp == 0)
            Destroy(this.gameObject, 0.016f);
         */
    }
}
