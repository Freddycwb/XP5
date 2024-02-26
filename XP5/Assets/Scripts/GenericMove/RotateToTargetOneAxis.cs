using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.GraphicsBuffer;

public class RotateToTargetOneAxis : MonoBehaviour
{
    [SerializeField] private GameObjectVariable targetGameObjectVariable;
    [SerializeField] private GameObject targetGameObject;
    private Transform _targetTransform;

    public enum Axis
    {
        x,
        y,
        z
    }

    [SerializeField] private Axis axis; 

    [SerializeField] private float rotateVel;
    [SerializeField] private float offset;

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
        Quaternion target = Quaternion.identity;
        switch (axis)
        {
            case Axis.x:
                float rotX = Mathf.Atan2(dir.z, dir.y) * Mathf.Rad2Deg;
                target = Quaternion.Euler(rotX + offset, transform.localEulerAngles.y, transform.localEulerAngles.z);
                break;
            case Axis.y:
                float rotY = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
                target = Quaternion.Euler(transform.localEulerAngles.x, -rotY + offset, transform.localEulerAngles.z);
                break;
            case Axis.z:
                float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                target = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, rotZ + offset);
                break;
            default:
                float rotD = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
                target = Quaternion.Euler(transform.localEulerAngles.x, rotD + offset, transform.localEulerAngles.z);
                break;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotateVel);
    }
}
