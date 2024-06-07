using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterStringComparison : InvokeAfter
{
    [SerializeField] private string compareValue;
    [SerializeField] private StringVariable compareValueVariable;

    public void SetValueToCompare(string value)
    {
        compareValue = value;
    }

    public void SetValueToCompare(StringVariable value)
    {
        compareValue = value.Value;
    }

    public void Compare(StringVariable value)
    {
        Compare(value.Value);
    }

    public void Compare(string value)
    {
        if (value == compareValue)
        {
            CallAction();
        }
        else
        {
            CallSubAction();
        }
    }
}
