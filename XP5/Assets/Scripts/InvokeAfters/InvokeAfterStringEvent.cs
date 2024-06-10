using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterStringEvent : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEventString Event;
    public UnityEvent<string> action;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public virtual void OnEventRaised(string value)
    {
        action.Invoke(value);
    }
}
