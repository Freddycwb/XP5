using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform parent;

    public Action<GameObject> onObjCreated;

    public void CreateObject()
    {
        GameObject a = Instantiate(obj, spawnPoint.position, spawnPoint.rotation);
        a.transform.SetParent(parent);
        if (onObjCreated != null)
        {
            onObjCreated.Invoke(a);
        }
    }

    public void CreateObject(Transform value)
    {
        GameObject a = Instantiate(obj, value.position, value.rotation);
        a.transform.SetParent(parent);
        if (onObjCreated != null)
        {
            onObjCreated.Invoke(a);
        }
    }

    public void CreateObject(GameObjectVariable value)
    {
        GameObject a = Instantiate(obj, value.Value.transform.position, value.Value.transform.rotation);
        a.transform.SetParent(parent);
        if (onObjCreated != null)
        {
            onObjCreated.Invoke(a);
        }
    }
}
