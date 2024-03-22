using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEventEmail : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>

    private readonly List<InvokeAfterEmailEvent> _eventListeners =
        new List<InvokeAfterEmailEvent>();

    public void Raise(Email value)
    {
        for (int i = _eventListeners.Count - 1; i >= 0; i--)
            _eventListeners[i].OnEventRaised(value);
    }

    public void RegisterListener(InvokeAfterEmailEvent listener)
    {
        if (!_eventListeners.Contains(listener))
            _eventListeners.Add(listener);
    }

    public void UnregisterListener(InvokeAfterEmailEvent listener)
    {
        if (_eventListeners.Contains(listener))
            _eventListeners.Remove(listener);
    }
}