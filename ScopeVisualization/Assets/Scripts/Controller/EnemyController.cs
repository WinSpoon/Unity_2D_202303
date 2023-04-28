using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void Initialize()
    {
        transform.position = new Vector3(0.0f, 10.0f, 0.0f);
    }

    private void Start()
    {
        Initialize();
    }

    private void OnEnable()
    {
        Initialize();

    }

    private void OnDisable()
    {
        ObjectPoolManager.GetInstance.returnObject(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }

}
