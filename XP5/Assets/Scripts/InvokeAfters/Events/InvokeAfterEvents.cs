using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterEvents : MonoBehaviour
{
    [SerializeField] private InvokeAfter invokeAfter;

    [SerializeField] private UnityEvent onActionCall;
    [SerializeField] private UnityEvent onSubActionCall;

    void Start()
    {
        if (invokeAfter != null)
        {
            invokeAfter.onActionCall += OnActionCall;
            invokeAfter.onSubActionCall += OnSubActionCall;
        }
    }

    void OnActionCall()
    {
        if (enabled)
        {
            onActionCall.Invoke();
        }
    }

    void OnSubActionCall()
    {
        onSubActionCall.Invoke();
    }

    private void OnDestroy()
    {
        if (invokeAfter != null)
        {
            invokeAfter.onActionCall -= OnActionCall;
            invokeAfter.onSubActionCall -= OnSubActionCall;
        }
    }
}
