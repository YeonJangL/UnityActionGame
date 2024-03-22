using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public GameObject button;
    public Image image;

    public void StartFadeIn()
    {
        StartCoroutine("Fade");
    }

    public void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(StartFadeIn);
        // 버튼 컴포넌트에 온 클릭 이벤트 리스너 연결
    }

    IEnumerator Fade()
    {
        float startAlpha = 0;
        while(startAlpha < 1.0f)
        {
            startAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, startAlpha);
        }
        // 화면 전환 하면서 패이드 인 되도록 하기,,
        SceneManager.LoadScene("Game");
    }
}
