using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetHeightByTMPBounds : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private Vector2 heightAdjust;
    private RectTransform t;

    private void Awake()
    {
        SetT();
    }

    private void SetT()
    {
        t = GetComponent<RectTransform>();
    }

    public void SetHeight()
    {
        if (t == null)
        {
            SetT();
        }
        tmp.ForceMeshUpdate(true);
        t.sizeDelta = new Vector2(t.sizeDelta.x, tmp.textBounds.size.y) + heightAdjust;
    }

    public void SetHeights(TextMeshProUGUI[] tmps)
    {
        if (t == null)
        {
            SetT();
        }
        float totalY = 0;
        foreach (TextMeshProUGUI text in tmps)
        {
            text.ForceMeshUpdate(true);
            totalY += text.textBounds.size.y + heightAdjust.y;
            Debug.Log("curr text: " + text.textBounds.size.y);
            Debug.Log("total: " + totalY);
        }
        t.sizeDelta = new Vector2(t.sizeDelta.x, totalY);
    }
}
