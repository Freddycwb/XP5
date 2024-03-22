using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterEmailEvent : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEventEmail Event;
    public UnityEvent<Email> action;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public virtual void OnEventRaised(Email value)
    {
        action.Invoke(value);
    }
}
