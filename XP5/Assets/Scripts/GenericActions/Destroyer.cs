using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private float delay;
    [SerializeField] private bool onStart;

    public Action onDelete;

    public float GetDelay()
    {
        return delay;
    }

    private void Start()
    {
        if (onStart)
        {
            Delete();
        }
    }

    public void Delete()
    {
        StartCoroutine(DeleteRoutine());
    }

    public void Delete(float value)
    {
        delay = value;
        StartCoroutine(DeleteRoutine());
    }

    private IEnumerator DeleteRoutine()
    {
        yield return new WaitForSeconds(delay);
        if (onDelete != null)
        {
            onDelete.Invoke();
        }
        yield return new WaitForEndOfFrame();
        Destroy(obj);
    }

    private void OnDestroy()
    {
        StopCoroutine(DeleteRoutine());
    }
}
