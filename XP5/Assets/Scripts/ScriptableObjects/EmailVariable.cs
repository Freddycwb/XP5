using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Email
{
    public string name;
    public string header;
    public string content;
    public bool canPass;
    public int wrongAnswerMessage;
}

public enum EmailInfos
{
    name,
    header,
    content,
    canPass,
    wrongAnswerMessage
}

[CreateAssetMenu]
public class EmailVariable : Variable<Email>
{
    public string name;
    [Multiline] public string header;
    [Multiline] public string content;
    public bool canPass;
    public int wrongAnswerMessage;

    private void OnEnable()
    {
        Value.name = name;
        Value.header = header;
        Value.content = content;
        Value.canPass = canPass;
        Value.wrongAnswerMessage = wrongAnswerMessage;
    }
}
