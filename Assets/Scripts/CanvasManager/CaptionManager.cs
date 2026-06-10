using TMPro;
using UnityEngine;
using System.Collections;

public class CaptionManager : MonoBehaviour
{
    public static CaptionManager Instance;

    public TextMeshProUGUI captionText;

    private Coroutine currentRoutine;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        captionText.gameObject.SetActive(false);
    }

    public void ShowCaption(
        string message,
        float duration = 2f)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }

        currentRoutine =
            StartCoroutine(
                ShowCaptionRoutine(
                    message,
                    duration));
    }

    IEnumerator ShowCaptionRoutine(
        string message,
        float duration)
    {
        captionText.gameObject
            .SetActive(true);

        captionText.text = message;

        yield return new WaitForSeconds(
            duration);

        captionText.gameObject
            .SetActive(false);
    }
}