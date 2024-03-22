using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseManager : MonoBehaviour
{
    private Email _currentEmail;

    private Action rightAnswer;
    private Action wrongAnswer;

    public void GetCurrentEmail(Email value)
    {
        _currentEmail = value;
    }

    public void EmailSent()
    {
        if (_currentEmail.canPass)
        {
            rightAnswer.Invoke();
        }
        else
        {
            wrongAnswer.Invoke();
        }
    }

    public void EmailWentToSpam()
    {
        if (!_currentEmail.canPass)
        {
            rightAnswer.Invoke();
        }
        else
        {
            wrongAnswer.Invoke();
        }
    }
}
