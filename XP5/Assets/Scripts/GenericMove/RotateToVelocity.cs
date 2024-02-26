using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToVelocity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotateVel;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (rb.velocity.magnitude != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z)), Time.deltaTime * rotateVel);
            transform.Rotate(offset);
        }
    }
}
