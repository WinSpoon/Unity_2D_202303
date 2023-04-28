using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initalizer : MonoBehaviour
{

    private void Awake()
    {
        var prefabManager = PrefabManager.GetInstance;
        var objectPoolManager = ObjectPoolManager.GetInstance;
    }
}
