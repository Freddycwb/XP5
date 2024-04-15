using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerToTMP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    [SerializeField] private InvokeAfterTimer timer;
    [SerializeField] private bool countDown;

    [SerializeField] private string formatType;

    private void Update()
    {
        if (countDown)
        {
            tmp.text = timer.GetCurrentTimePass().ToString(formatType);
        }
        else
        {
            tmp.text = (timer.GetCurrentTimeToAction() - timer.GetCurrentTimePass()).ToString(formatType);
        }
    }
}
