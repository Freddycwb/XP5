using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToReceiveEmail : MonoBehaviour
{
    [SerializeField] private InvokeAfterTimer timer;
    [SerializeField] private RectTransform emailsList;

    [SerializeField] private float time;

    public void IncreaseTimer()
    {
        timer.SetTimeToAction(emailsList.childCount * (time * emailsList.childCount));
    }

    public void DecreaseTimer()
    {
        timer.SubtractTime(emailsList.childCount / (time * emailsList.childCount));
    }
}
