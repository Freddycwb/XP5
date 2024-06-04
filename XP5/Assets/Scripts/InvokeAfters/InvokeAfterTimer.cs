using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterTimer : InvokeAfter
{
    [SerializeField] private float timeToAction;
    [SerializeField] private float maxTimeToActionOPTIONAL;
    [SerializeField] private FloatVariable timeToActionVariable;
    [SerializeField] private Vector2Variable randomTimeToActionVariable;
    [SerializeField] private float valueAdjuster;
    [SerializeField] private bool overrideLastTimer = true;
    [SerializeField] private bool useUnscaledTime;

    [SerializeField] private float currentTimeToAction;
    [SerializeField] private bool isPaused;
    private bool _justSetTime;

    [SerializeField] private float currentTimePass;

    private Coroutine coroutine;

    public float GetCurrentTimeToAction()
    {
        return currentTimeToAction + valueAdjuster;
    }

    public float GetCurrentTimePass()
    {
        return currentTimePass;
    }

    public void SetPause(bool value)
    {
        isPaused = value;
    }

    public void StartTimer()
    {
        if (overrideLastTimer && coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        enabled = true;
        if (timeToAction > 0 || (randomTimeToActionVariable != null && randomTimeToActionVariable.Value != Vector2.zero) || (timeToActionVariable != null && timeToActionVariable.Value > 0))
        {
            coroutine = StartCoroutine(InvokeAfterSeconds());
        }
    }

    private IEnumerator InvokeAfterSeconds()
    {
        if (randomTimeToActionVariable != null && randomTimeToActionVariable.Value != Vector2.zero && !_justSetTime)
        {
            currentTimeToAction = Random.Range(randomTimeToActionVariable.Value.x, randomTimeToActionVariable.Value.y);
            yield return Timer(currentTimeToAction);
        }
        else if (timeToActionVariable != null && timeToActionVariable.Value > 0 && !_justSetTime)
        {
            currentTimeToAction = timeToActionVariable.Value;
            yield return Timer(currentTimeToAction);
        }
        else
        {
            if (maxTimeToActionOPTIONAL <= 0)
            {
                currentTimeToAction = timeToAction;
                if (_justSetTime)
                {
                    _justSetTime = false;
                }
                yield return Timer(currentTimeToAction);
            }
            else
            {
                currentTimeToAction = Random.Range(timeToAction, maxTimeToActionOPTIONAL);
                yield return Timer(currentTimeToAction);
            }
        }
        CallAction();
    }

    private IEnumerator Timer(float timeCount)
    {
        timeCount += valueAdjuster;
        while (timeCount > 0)
        {
            currentTimePass = timeCount;
            if (!isPaused)
            {
                if (useUnscaledTime)
                {
                    timeCount -= Time.unscaledDeltaTime;
                }
                else
                {
                    timeCount -= Time.deltaTime;
                }
            }
            yield return null;
        }
    }

    public void SetTimeToAction(float time)
    {
        timeToAction = time;
        _justSetTime = true;
        coroutine = StartCoroutine(InvokeAfterSeconds());
    }

    public void SubtractTime(float value)
    {
        if (coroutine != null)
        {
            float newTime = 0;
            if (0 < currentTimePass - value)
            {
                newTime = currentTimePass - value;
                StopCoroutine(coroutine);
                SetTimeToAction(newTime);
            }
            else
            {
                StopCoroutine(coroutine);
                SetTimeToAction(0.05f);
            }
        }
    }

    public void CancelTimer()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
}
