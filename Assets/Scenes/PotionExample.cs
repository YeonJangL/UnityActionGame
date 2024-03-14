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
            Debug.Log("���� ���");
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

            yield return null; // ������ �ѹ��� �ѹ��� ���� ����
            cooltime -= Time.deltaTime;
            GetComponent<Image>().fillAmount = cooltime / cooltime_max;
        }

        Debug.Log("��Ÿ�� üũ �Ϸ�");
        GetComponent<Image>().color = Color.red;
        cooltime = cooltime_max;
        GetComponent<Image>().fillAmount = 1.0f;
        isUse = false;
    }
}
