using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private GameObject input;
    private IInput _input;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        _input = input.GetComponent<IInput>();
    }

    void Update()
    {
        xRotation -= _input.look.x;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += _input.look.y;
        transform.eulerAngles = new Vector3(xRotation, yRotation, 0f);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
