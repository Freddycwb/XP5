using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterGameEvent : InvokeAfter
{
    [Tooltip("Event to register with.")]
    public GameEvent Event;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public virtual void OnEventRaised()
    {
        if (enabled)
        {
            CallAction();
        }
    }
}
