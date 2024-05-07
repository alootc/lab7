using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image image;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(FadeIn());
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        Color c = image.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            image.color = c;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        Color c = image.color;
        for (float alpha = 0f; alpha <= 1f; alpha += 0.1f)
        {
            c.a = alpha;
            image.color = c;
            yield return new WaitForSeconds(0.1f);
        }

    }



}
