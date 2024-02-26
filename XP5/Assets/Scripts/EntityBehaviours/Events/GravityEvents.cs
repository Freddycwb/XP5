using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GravityEvents : MonoBehaviour
{
    [SerializeField] private Gravity gravity;

    [SerializeField] private UnityEvent onLand;
    [SerializeField] private UnityEvent onTakeOff;

    void Start()
    {
        if (onLand != null)
        {
            gravity.onLand += OnLand;
        }
        if (onTakeOff != null)
        {
            gravity.onTakeOff += OnTakeOff;
        }
    }

    void OnLand()
    {
        onLand.Invoke();
    }

    void OnTakeOff()
    {
        onTakeOff.Invoke();
    }

    private void OnDestroy()
    {
        if (onLand != null)
        {
            gravity.onLand -= OnLand;
        }
        if (onTakeOff != null)
        {
            gravity.onTakeOff -= OnTakeOff;
        }
    }
}
