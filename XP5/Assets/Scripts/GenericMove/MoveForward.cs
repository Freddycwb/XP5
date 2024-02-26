using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float maxSpeed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * maxSpeed * Time.deltaTime);
    }
}
