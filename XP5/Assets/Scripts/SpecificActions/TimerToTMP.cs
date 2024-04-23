using UnityEngine;
using TMPro;
using System;

public class TimerToTMP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    [SerializeField] private InvokeAfterTimer timer;
    [SerializeField] private bool countDown;
    [SerializeField] private bool dateTime;

    [SerializeField] private string formatType;

    private void Update()
    {
        float time = timer.GetCurrentTimePass();
        if (!countDown)
        {
            time = timer.GetCurrentTimeToAction() - timer.GetCurrentTimePass();
        }

        if (dateTime)
        {
            tmp.text =  DateTime.Today.AddSeconds(time).ToString(formatType);
        }
        else
        {
            tmp.text = time.ToString(formatType);
        }
    }
}
