using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using System;

public class InvokeAfter : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] private GameObject[] instantiateOnAction;
    [SerializeField] private UnityEvent subAction;
    [SerializeField] private GameObject[] instantiateOnSubAction;

    public Action onActionCall;
    public Action onSubActionCall;

    public void CallAction()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }
        InstantiateGameObjects(instantiateOnAction);
        action.Invoke();
        if (onActionCall != null)
        {
            onActionCall.Invoke();
        }
    }

    public void CallSubAction()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }
        InstantiateGameObjects(instantiateOnSubAction);
        subAction.Invoke();
        if (onSubActionCall != null)
        {
            onSubActionCall.Invoke();
        }
    }

    private void InstantiateGameObjects(GameObject[] instantiate)
    {
        if (instantiate.Length > 0)
        {
            foreach (GameObject obj in instantiate)
            {
                Instantiate(obj, transform.position, transform.rotation);
            }
        }
    }
}
