using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance;

    public Image fadeImage;

    public float fadeSpeed = 2f;

    void Awake()
    {
        Instance = this;
    }

    public IEnumerator FadeIn()
    {
        float alpha = 0;

        while (alpha < 1)
        {
            alpha +=
                Time.deltaTime *
                fadeSpeed;

            SetAlpha(alpha);

            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        float alpha = 1;

        while (alpha > 0)
        {
            alpha -=
                Time.deltaTime *
                fadeSpeed;

            SetAlpha(alpha);

            yield return null;
        }
    }

    void SetAlpha(float alpha)
    {
        Color color =
            fadeImage.color;

        color.a = alpha;

        fadeImage.color =
            color;
    }
}