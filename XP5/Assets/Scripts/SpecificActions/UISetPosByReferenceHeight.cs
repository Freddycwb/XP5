using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class UISetPosByReferenceHeight : MonoBehaviour
{
    [SerializeField] private RectTransform reference;
    [SerializeField] private float margin;
    private RectTransform t;

    private void Awake()
    {
        t = GetComponent<RectTransform>();
    }

    public void SetPos()
    {
        t.localPosition = new Vector3(t.localPosition.x, (t.localPosition.y + reference.rect.height / 2) + margin, t.localPosition.z);
    }
}
