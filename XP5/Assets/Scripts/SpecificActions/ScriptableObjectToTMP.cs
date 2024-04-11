using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptableObjectToTMP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    [SerializeField] private IntVariable intValue;
    [SerializeField] private FloatVariable floatValue;
    [SerializeField] private StringVariable stringValue;

    private void Start()
    {
        if (intValue != null)
        {
            tmp.text = intValue.Value.ToString();
        }
        else if (floatValue != null)
        {
            tmp.text = floatValue.Value.ToString();
        }
        else if (stringValue != null)
        {
            tmp.text = stringValue.Value.ToString();
        }
    }

    public void SetTMP(IntVariable value)
    {
        tmp.text = value.Value.ToString();
    }

    public void SetTMP(FloatVariable value)
    {
        tmp.text = value.Value.ToString("D0");
    }

    public void SetTMP(StringVariable value)
    {
        tmp.text = value.Value;
    }
}
