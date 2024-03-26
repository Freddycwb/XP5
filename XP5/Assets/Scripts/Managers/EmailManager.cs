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

    public void CreateEmail()
    {
        GameObject b = Instantiate(btn, spawnPoint.position, spawnPoint.rotation);
        b.GetComponentInChildren<EmailButton>().SetEmail(Emails[count]);
        b.GetComponentInChildren<EmailInfoToTMP>().SetEmail(Emails[count]);
        b.transform.SetParent(parent);
        count++;
    }

    public void CreateEmail(EmailVariable value)
    {
        GameObject b = Instantiate(btn, spawnPoint.position, spawnPoint.rotation);
        b.GetComponentInChildren<EmailButton>().SetEmail(value);
        b.GetComponentInChildren<EmailInfoToTMP>().SetEmail(value);
        b.transform.SetParent(parent);
    }
}
