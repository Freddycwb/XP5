using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseManager : MonoBehaviour
{
    private Email _currentEmail;

    [SerializeField] private GameEventString wrongAnswerMessage;

    public Action onRightAnswer;
    public Action onWrongAnswer;

    public void GetCurrentEmail(Email value)
    {
        _currentEmail = value;
    }

    public void EmailSent()
    {
        if (_currentEmail.canPass)
        {
            if (onRightAnswer != null)
            {
                onRightAnswer.Invoke();
            }
        }
        else
        {
            if (onWrongAnswer != null)
            {
                onWrongAnswer.Invoke();
                wrongAnswerMessage.Raise(_currentEmail.wrongAnswerMessage);
            }
        }
    }

    public void EmailWentToSpam()
    {
        if (!_currentEmail.canPass)
        {
            if (onRightAnswer != null)
            {
                onRightAnswer.Invoke();
            }
        }
        else
        {
            if (onWrongAnswer != null)
            {
                onWrongAnswer.Invoke();
                wrongAnswerMessage.Raise(_currentEmail.wrongAnswerMessage);
            }
        }
    }
}
