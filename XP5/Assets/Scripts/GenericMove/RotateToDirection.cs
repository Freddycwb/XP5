using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class RotateToDirection : MonoBehaviour
{
    [SerializeField] private GameObject input;
    private IInput _input;
    [SerializeField] private float rotateVel;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        _input = input.GetComponent<IInput>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_input.direction.magnitude != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(_input.direction.x, 0, _input.direction.y)), Time.deltaTime * rotateVel);
            transform.Rotate(offset);
        }
    }
}
