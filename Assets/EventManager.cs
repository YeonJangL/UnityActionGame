using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public Text eventText;

    public int usercnt = 0;

    public void Awake()
    {
        eventText.gameObject.SetActive(false);
        UserConnected();
    }

    public void UserConnected()
    {
        usercnt++;

        if (usercnt == 100)
        {
            StartCoroutine(TypingText());
        }
        else
        {
            eventText.gameObject.SetActive(true);
            eventText.text = usercnt + "��° ���� �����Դϴ�";
        }
    }

    IEnumerator TypingText()
    {
        string evnetMessage = "�����մϴ�! " + usercnt + "��° ���� �����Դϴ�! �̺�Ʈ�� ��÷��~";

        eventText.text = "";
        eventText.gameObject.SetActive(true);

        foreach (char letter in  evnetMessage)
        {
            eventText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
