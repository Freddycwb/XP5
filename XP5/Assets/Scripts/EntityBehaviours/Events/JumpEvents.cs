using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpEvents : MonoBehaviour
{
    [SerializeField] private Jump jump;

    [SerializeField] private UnityEvent onJump;

    void Start()
    {
        if (jump != null)
        {
            jump.onJump += OnJump;
        }
    }

    void OnJump()
    {
        onJump.Invoke();
    }

    private void OnDestroy()
    {
        if (jump != null)
        {
            jump.onJump -= OnJump;
        }
    }
}
