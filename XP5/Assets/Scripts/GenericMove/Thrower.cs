using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] private Vector3 dir;
    [SerializeField] private float force;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            Throw(other.GetComponent<Rigidbody>());
        }
        else if (other.GetComponentInParent<Rigidbody>())
        {
            Throw(other.GetComponentInParent<Rigidbody>());
        }
    }

    private void Throw(Rigidbody rb)
    {
        if (dir != Vector3.zero)
        {
            rb.AddForce(transform.right * dir.normalized.x * force, ForceMode.Impulse);
            rb.AddForce(transform.up * dir.normalized.y * force, ForceMode.Impulse);
            rb.AddForce(transform.forward * dir.normalized.z * force, ForceMode.Impulse);
        }
        else
        {
            Vector3 dirToObject = rb.position - transform.position;
            rb.AddForce(dirToObject.normalized * force, ForceMode.Impulse);
        }
    }
}
