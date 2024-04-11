using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterIntComparison : InvokeAfter
{
    public enum ComparisonType
    {
        less,
        lessOrEqual,
        equal,
        equalOrGreater,
        greater
    }

    [SerializeField] private IntVariable ScriptableObject;
    [SerializeField] private ComparisonType comparison;

    public void Compare(FloatVariable value)
    {
        Compare(value.Value);
    }

    public void Compare(IntVariable value)
    {
        Compare(value.Value);
    }

    public void Compare(float value)
    {
        switch (comparison)
        {
            case ComparisonType.less:
                if (ScriptableObject.Value < value)
                {
                    CallAction();
                }
                else
                {
                    CallSubAction();
                }
                break;
            case ComparisonType.lessOrEqual:
                if (ScriptableObject.Value <= value)
                {
                    CallAction();
                }
                else
                {
                    CallSubAction();
                }
                break;
            case ComparisonType.equal:
                if (ScriptableObject.Value == value)
                {
                    CallAction();
                }
                else
                {
                    CallSubAction();
                }
                break;
            case ComparisonType.equalOrGreater:
                if (ScriptableObject.Value >= value)
                {
                    CallAction();
                }
                else
                {
                    CallSubAction();
                }
                break;
            case ComparisonType.greater:
                if (ScriptableObject.Value > value)
                {
                    CallAction();
                }
                else
                {
                    CallSubAction();
                }
                break;
        }
    }
}
