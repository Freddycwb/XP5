using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRotation : MonoBehaviour
{
    [SerializeField] private Transform obj;

    private void Update()
    {
        transform.eulerAngles -= obj.eulerAngles;
    }
}
