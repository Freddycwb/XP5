using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    [SerializeField] private GameObject btn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform parent;
    [SerializeField] private List<EmailVariable> Emails = new List<EmailVariable>();
    private int count;
    private bool noMoreEmails;

    [SerializeField] private GameEventEmail newEmail;

    public List<EmailVariable> GetEmails()
    {
        return Emails;
    }

    public void CreateEmail()
    {
        if (noMoreEmails)
        {
            return;
        }
        if (count >= Emails.Count)
        {
            noMoreEmails = true;
            return;
        }
        GameObject b = Instantiate(btn, spawnPoint.position, spawnPoint.rotation);
        b.GetComponentInChildren<EmailButton>().SetEmail(Emails[count]);
        b.GetComponentInChildren<EmailInfoToTMP>().SetEmail(Emails[count]);
        b.transform.SetParent(parent);
        b.GetComponent<RectTransform>().localScale = Vector3.one;
        newEmail.Raise(Emails[count].Value);
        count++;
    }

    public void CreateEmail(EmailVariable value)
    {
        GameObject b = Instantiate(btn, spawnPoint.position, spawnPoint.rotation);
        b.GetComponentInChildren<EmailButton>().SetEmail(value);
        b.GetComponentInChildren<EmailInfoToTMP>().SetEmail(value);
        b.GetComponent<RectTransform>().localScale = Vector3.one;
        b.transform.SetParent(parent);
        newEmail.Raise(value.Value);
    }
}
