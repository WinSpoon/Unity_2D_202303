using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PrefabManager
{
    // ** �ν��Ͻ� ����.
    public static PrefabManager GetInstance { get; } = new PrefabManager();

    // ** ������ �����.
    private Dictionary<string, GameObject> prototypeObjectList = new Dictionary<string, GameObject>();

    private PrefabManager()
    {
        // ** �����͸� �ҷ��´�.
        GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefabs");

        // ** �ҷ��� �����͸� Dictionary �� ����.
        foreach (GameObject element in prefabs)
            prototypeObjectList.Add(element.name, element);
    }

    // ** �ܺο��� �������� Prefab�� ���� �� �� �ֵ��� Getter�� ����.
    public GameObject getPrefabByName(string key)
    {
        // ** ���࿡ key�� ���� �Ѵٸ� ���� ��ü�� ��ȯ�ϰ�...
        if (prototypeObjectList.ContainsKey(key))
            return prototypeObjectList[key];

        // ** �׷��� ���������� null
        return null;
    }
}