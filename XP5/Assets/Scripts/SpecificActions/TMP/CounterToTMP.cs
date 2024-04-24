using UnityEngine;
using TMPro;
using System;

public class CounterToTMP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    [SerializeField] private InvokeAfterCounter counter;

    [SerializeField] private string formatType;

    private void Start()
    {
        counter.onSubActionCall += UpdateTMP;
    }

    public void UpdateTMP()
    {
        float currentValue = counter.GetCurrentValue();
        tmp.text = currentValue.ToString(formatType);
    }
}
