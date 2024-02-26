using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float gravityScale;
    private float _globalGravity = -9.81f;


    private bool _isGrounded;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;

    public Action onLand;
    public Action onTakeOff;

    public bool GetIsGrounded()
    {
        return _isGrounded;
    }

    private void Start()
    {
        if (rb == null && GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        CheckGround();
    }

    private void ApplyGravity()
    {
        Vector3 gravity = _globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private void CheckGround()
    {
        Collider[] grounds = Physics.OverlapSphere(transform.position, groundCheckRadius, whatIsGround);
        if (!_isGrounded && grounds.Length > 0)
        {
            if (onLand != null)
            {
                onLand.Invoke();
            }
        }
        else if (_isGrounded && grounds.Length <= 0)
        {
            if (onTakeOff != null)
            {
                onTakeOff.Invoke();
            }
        }
        _isGrounded = grounds.Length > 0;
    }
}
