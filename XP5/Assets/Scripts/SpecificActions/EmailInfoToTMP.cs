using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmailInfoToTMP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private EmailInfos emailInfo;

    public void SetEmail(Email value)
    {
        SetTMP(value);
    }

    public void SetEmail(EmailVariable value)
    {
        SetTMP(value.Value);
    }

    private void SetTMP(Email value)
    {
        switch (emailInfo)
        {
            case EmailInfos.name:
                tmp.text = value.name;
                break;
            case EmailInfos.content:
                tmp.text = value.content;
                break;
            case EmailInfos.canPass:
                tmp.text = value.canPass ? "true" : "false";
                break;
            default:
                tmp.text = "";
                break;
        }
    }
}
