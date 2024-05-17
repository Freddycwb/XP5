using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveByMousePos : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 mouse;
    private RectTransform rectTransform;

    [SerializeField] private GameObjectVariable canvasObj;
    private Canvas canvas;

    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = canvasObj.Value.GetComponent<Canvas>();
        startPos = rectTransform.localPosition;
        mouse = Input.mousePosition;
    }

    void Update()
    {
        Vector3 canvasLocalScale = canvas.transform.localScale;
        Vector3 mouseDiff = (Input.mousePosition - mouse) / canvas.scaleFactor;
        rectTransform.localPosition = startPos + mouseDiff;
    }
}
