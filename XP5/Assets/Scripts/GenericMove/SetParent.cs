using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    [SerializeField] private GameObjectVariable targetGameObjectVariable;
    [SerializeField] private GameObject targetGameObject;
    private Transform _targetTransform;

    [SerializeField] private bool setParentOnStart = true;

    private void Start()
    {
        if (targetGameObjectVariable != null)
        {
            _targetTransform = targetGameObjectVariable.Value.transform;
        }
        else if (targetGameObject != null)
        {
            _targetTransform = targetGameObject.transform;
        }

        if (setParentOnStart && _targetTransform != null)
        {
            transform.SetParent(_targetTransform);
        }
    }
}
