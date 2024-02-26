using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfViewEvents : MonoBehaviour
{
    [SerializeField] private FieldOfView fov;

    [SerializeField] private UnityEvent onTargetEnterFOV;
    [SerializeField] private UnityEvent onTargetExitFOV;

    void Start()
    {
        fov.onTargetEnterFOV += OnTargetEnterFOV;
        fov.onTargetExitFOV += OnTargetExitFOV;
    }

    void OnTargetEnterFOV()
    {
        onTargetEnterFOV.Invoke();
    }

    void OnTargetExitFOV()
    {
        onTargetExitFOV.Invoke();
    }

    private void OnDestroy()
    {
        fov.onTargetEnterFOV -= OnTargetEnterFOV;
        fov.onTargetExitFOV -= OnTargetExitFOV;
    }
}
