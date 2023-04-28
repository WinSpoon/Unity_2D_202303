using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller {
    public void Initialize()
    {

    }
};

public class ObjectPoolManager
{
    public static ObjectPoolManager GetInstance { get; } = new ObjectPoolManager();

    private ObjectPoolManager() { }

    private Dictionary<string, Stack<GameObject>> DisableList = new Dictionary<string, Stack<GameObject>>();


    public GameObject getObject(string key)
    {
        Stack<GameObject> stack = null;
        GameObject prefab = null;

        if (DisableList.TryGetValue(key, out stack) && stack.Count > 0)
            prefab = stack.Pop();
        else
        {
            prefab =  PrefabManager.GetInstance.getPrefabByName(key);

            if (prefab == null)
                return null;

            prefab.name = key;
        }

        return prefab;
    }


    public void returnObject(GameObject Obj)
    {
        if(DisableList.ContainsKey(Obj.name))
            DisableList[Obj.name].Push(Obj);
        else
        {
            Stack<GameObject> stack = new Stack<GameObject>();

            stack.Push(Obj);
            DisableList.Add(Obj.name, stack);
        }
    }
}
