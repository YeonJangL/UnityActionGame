using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionExample : MonoBehaviour
{
    public bool isUse;
    public float cooltime = 10.0f;
    public float cooltime_max = 10.0f;

    public void OnPotionDown()
    {
        if (isUse == false)
        {
            Debug.Log("포션 사용");
            StartCoroutine(CoolTimeCheck());
            GetComponent<Image>().color = Color.black;
            isUse = true;
        }
    }

    IEnumerator CoolTimeCheck()
    {
        while (cooltime > 0.0f)
        {
            GetComponent<Image>().color = Color.black;
            isUse = true;

            yield return null; // 프레임 한번당 한번씩 빠져 나옴
            cooltime -= Time.deltaTime;
            GetComponent<Image>().fillAmount = cooltime / cooltime_max;
        }

        Debug.Log("쿨타임 체크 완료");
        GetComponent<Image>().color = Color.red;
        cooltime = cooltime_max;
        GetComponent<Image>().fillAmount = 1.0f;
        isUse = false;
    }
}
