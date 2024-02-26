using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScriptableObjects : MonoBehaviour
{
    [SerializeField] private GameObjectVariable scriptableObject;
    [SerializeField] private GameObject value;

    private void Awake()
    {
        scriptableObject.Value = value;
    }
}
