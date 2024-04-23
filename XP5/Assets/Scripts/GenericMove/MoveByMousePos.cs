using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveByMousePos : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 mouse;
    private RectTransform rectTransform;

    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        mouse = Input.mousePosition;
        startPos = rectTransform.position;
    }

    void Update()
    {
        rectTransform.position = startPos + (Input.mousePosition - mouse);
    }
}
