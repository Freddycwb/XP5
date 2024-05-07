using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomXYPosUI : MonoBehaviour
{
    [SerializeField] private RectTransform obj;
    [SerializeField] private GameObjectVariable canvas;
    [SerializeField] private Vector2 maxXY;
    public void RandomPos()
    {
        float x = Random.Range(-maxXY.x, maxXY.x);
        float y = Random.Range(-maxXY.y, maxXY.y);
        Vector2 canvasLocalScale = canvas.Value.GetComponent<Canvas>().transform.localScale;
        obj.position = new Vector3(x * canvasLocalScale.x, y * canvasLocalScale.y, obj.localPosition.z);
    }
}
