using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    [SerializeField] private InvokeAfterCounter counter;
    [SerializeField] private FloatVariable currentVariable;
    [SerializeField] private float current;
    [SerializeField] private FloatVariable maxVariable;
    [SerializeField] private float max;

    [SerializeField] private float timeToReachLowerValue;
    [SerializeField] private float timeToReachHigherValue;
    [SerializeField] private AnimationCurve curve;
    private float _currentValue;
    private float _lastValue;
    private float _count;


    [SerializeField] private Slider slider;

    private void Start()
    {
        SetCurrentMax();
        _currentValue = current / max;
        _lastValue = _currentValue;
    }

    public void SetCurrentMax()
    {
        if (counter != null)
        {
            if (current != counter.GetCurrentValue())
            {
                _lastValue = _currentValue;
                _count = 0;
            }
            current = counter.GetCurrentValue();
            max = counter.GetMaxValue();
        }
        if (currentVariable != null)
        {
            if (current != currentVariable.Value)
            {
                _lastValue = _currentValue;
                _count = 0;
            }
            current = currentVariable.Value;
        }
        if (maxVariable != null)
        {
            max = maxVariable.Value;
        }
    }

    private void Update()
    {
        SetCurrentMax();

        if (((_currentValue > current / max) && timeToReachLowerValue > 0) || ((_currentValue < current / max) && timeToReachHigherValue > 0))
        {
            SliderLerp();
        }
        else if (((_currentValue > current / max) && timeToReachLowerValue <= 0) || ((_currentValue < current / max) && timeToReachHigherValue <= 0))
        {
            SetValueToCurrent();
        }


        slider.value = _currentValue;
    }

    private void SliderLerp()
    {
        if (_count < 1)
        {
            _count += _currentValue > current / max ? Time.deltaTime / timeToReachLowerValue : Time.deltaTime / timeToReachHigherValue;
            if (_count >= 1)
            {
                _count = 1;
            }
            _currentValue = Mathf.Lerp(_lastValue, current / max, curve.Evaluate(_count));
        }
    }

    public void SetValueToCurrent()
    {
        _currentValue = current / max;
        _lastValue = _currentValue;
        _count = 1;
    }
}
