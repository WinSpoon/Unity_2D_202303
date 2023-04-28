using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject Parent = null;
    private string EnemyName = "Enemy";

    private void Awake()
    {
        Parent = new GameObject("ObjectList");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject Object = ObjectPoolManager.GetInstance.getObject(EnemyName);
            Object.SetActive(true);
            Object.transform.SetParent(Parent.transform);
        }
    }
}
