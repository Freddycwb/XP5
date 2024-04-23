using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent onClick;

    void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    void OnClick()
    {
        onClick.Invoke();
    }
}
