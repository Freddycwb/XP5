using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaneMoveEvents : MonoBehaviour
{
    [SerializeField] private PlaneMove planeMove;

    [SerializeField] private UnityEvent onStartMove;
    [SerializeField] private UnityEvent onStopMove;

    void Start()
    {
        if (planeMove != null)
        {
            planeMove.onStartMove += OnStartMove;
            planeMove.onStopMove += OnStopMove;
        }
    }

    void OnStartMove()
    {
        onStartMove.Invoke();
    }

    void OnStopMove()
    {
        onStopMove.Invoke();
    }

    private void OnDestroy()
    {
        if (planeMove != null)
        {
            planeMove.onStartMove -= OnStartMove;
            planeMove.onStopMove -= OnStopMove;
        }
    }
}
