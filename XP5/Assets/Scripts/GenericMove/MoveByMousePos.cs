using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveByMousePos : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 mouse;
    [SerializeField] private GameObjectVariable cameraObj;
    private Camera cam;
    private float speed = 45.01182f;
    private RectTransform rectTransform;

    private void OnEnable()
    {
        cam = cameraObj.Value.GetComponent<Camera>();
        rectTransform = GetComponent<RectTransform>();
        mouse = cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        startPos = rectTransform.position;
    }

    void Update()
    {
        rectTransform.position = startPos + (cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10) - mouse) * speed;
    }
}
