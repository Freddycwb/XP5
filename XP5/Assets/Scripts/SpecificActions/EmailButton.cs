using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailButton : MonoBehaviour
{
    public GameEventEmail onEmailSelected;
    public EmailVariable email;

    public void SetEmail(EmailVariable value)
    {
        email = value;
    }

    public void OnClick()
    {
        onEmailSelected.Raise(email.Value);
    }
}
