using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossChat : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject content;

    public void CreateWrongAnswer(string text)
    {
        GameObject a = Instantiate(textBox);
        a.transform.SetParent(content.transform);
        a.transform.localScale = Vector3.one;
        a.transform.localPosition = Vector3.zero;
        a.GetComponentInChildren<TextMeshProUGUI>().text = text;
        a.GetComponent<SetHeightByTMPBounds>().SetHeight();
        content.GetComponent<UIOrderChildsPos>().OrganizeChilds();

        UpdateHeight();
    }

    public void UpdateHeight()
    {
        float totalY = 0;
        for (int i = 0; i < content.transform.childCount; ++i)
        {
            totalY += content.transform.GetChild(i).GetComponent<RectTransform>().rect.height;
            Debug.Log("total: " + totalY);
            Debug.Log("curr: " + content.transform.GetChild(i).GetComponent<RectTransform>().rect.height);
        }

        content.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(content.transform.GetComponent<RectTransform>().sizeDelta.x, totalY);
    }
}
