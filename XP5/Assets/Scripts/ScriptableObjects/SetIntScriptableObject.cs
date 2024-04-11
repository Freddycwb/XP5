using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIntScriptableObjects : MonoBehaviour
{
    [SerializeField] private IntVariable scriptableObject;

    public void SetValue(int value)
    {
        scriptableObject.Value = value;
    }

    public void AddToValue(int value)
    {
        scriptableObject.Value += value;
    }
}
