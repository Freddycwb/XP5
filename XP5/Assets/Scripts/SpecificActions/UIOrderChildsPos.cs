using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrderChildsPos : MonoBehaviour
{
    private enum Axis
    {
        x, y, minusX, minusY
    }

    [SerializeField] private Axis axis;
    [SerializeField] private float margin;
    [SerializeField] private bool invert;
    [SerializeField] private GameObjectVariable canvas;
    private RectTransform canvasObj;

    private RectTransform t;

    private void Start()
    {
        t = GetComponent<RectTransform>();
        canvasObj = canvas.Value.GetComponent<RectTransform>();
    }

    public void OrganizeChilds()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            int count = invert ? transform.childCount - 1 - i : i;
            RectTransform child = transform.GetChild(i).GetComponent<RectTransform>();
            switch (axis)
            {
                case Axis.x:
                    child.position = new Vector3(t.position.x + (margin + child.rect.width) * count * canvasObj.localScale.x, t.position.y, t.position.z);
                    break;
                case Axis.y:
                    child.position = new Vector3(t.position.x, t.position.y + (margin + child.rect.height) * count * canvasObj.localScale.x, t.position.z);
                    break;
                case Axis.minusX:
                    child.position = new Vector3(t.position.x - (margin + child.rect.width) * count * canvasObj.localScale.x, t.position.y, t.position.z);
                    break;
                case Axis.minusY:
                    child.position = new Vector3(t.position.x, t.position.y - (margin + child.rect.height) * count * canvasObj.localScale.x, t.position.z);
                    break;
            }
            child.localScale = Vector3.one;
        }
    }
}
