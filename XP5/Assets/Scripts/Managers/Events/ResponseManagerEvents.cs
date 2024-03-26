using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResponseManagerEvents : MonoBehaviour
{

    [SerializeField] private ResponseManager responseManager;

    [SerializeField] private UnityEvent onRightAnswer;
    [SerializeField] private UnityEvent onWrongAnswer;

    void Start()
    {
        if (responseManager != null)
        {
            responseManager.onRightAnswer += OnRightAnswer;
            responseManager.onWrongAnswer += OnWrongAnswer;
        }
    }

    void OnRightAnswer()
    {
        onRightAnswer.Invoke();
    }

    void OnWrongAnswer()
    {
        onWrongAnswer.Invoke();
    }

    private void OnDestroy()
    {
        if (responseManager != null)
        {
            responseManager.onRightAnswer += OnRightAnswer;
            responseManager.onWrongAnswer += OnWrongAnswer;
        }
    }
}
