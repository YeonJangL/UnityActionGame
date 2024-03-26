using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public Image image;

    public void Start()
    {
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        float startAlpha = 1;
        while (startAlpha > 0.0f)
        {
            startAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, startAlpha);
        }
    }
}
