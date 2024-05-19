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
        t = GetComponent<RectTransform>();
    }

    public void SetHeight()
    {
        tmp.ForceMeshUpdate();
        t.sizeDelta = new Vector2(t.sizeDelta.x, tmp.textBounds.size.y) + heightAdjust;
    }
}
