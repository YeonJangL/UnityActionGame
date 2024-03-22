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
            eventText.text = usercnt + "번째 접속 유저입니다";
        }
    }

    IEnumerator TypingText()
    {
        string evnetMessage = "축하합니다! " + usercnt + "번째 접속 유저입니다! 이벤트에 당첨된~";

        eventText.text = "";
        eventText.gameObject.SetActive(true);

        foreach (char letter in  evnetMessage)
        {
            eventText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
