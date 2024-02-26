using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private GameObjectVariable targetGameObjectVariable;
    [SerializeField] private GameObject targetGameObject;
    private Transform _targetTransform;
    [SerializeField] private float rotateVel;
    [SerializeField] private Vector3 offset;

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
    }

    private void FixedUpdate()
    {
        if (_targetTransform == null)
        {
            return;
        }
        Rotate();
    }

    private void Rotate()
    {
        Vector3 dir = _targetTransform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateVel);
        transform.Rotate(offset);
    }
}
