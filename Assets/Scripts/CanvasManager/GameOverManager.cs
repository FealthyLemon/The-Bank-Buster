using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{

    public AudioSource
    gameOverAudio;

    public static GameOverManager Instance;

    public GameObject caughtPanel;
    public RectTransform panelTransform;

    public float animationSpeed = 8f;

    private bool isCaught = false;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        caughtPanel.SetActive(false);
    }

    public void PlayerCaught()
    {
        if (isCaught)
            return;

        isCaught = true;

        if (gameOverAudio != null)
        {
            gameOverAudio.Play();
        }
        MusicManager
    .Instance
    .PauseMusic();
        StartCoroutine(
            ShowCaughtScreen());
    }

    IEnumerator ShowCaughtScreen()
    {
        Time.timeScale = 0f;

        caughtPanel.SetActive(true);

        panelTransform.localScale =
            Vector3.zero;

        while (
            panelTransform.localScale.x
            < 1)
        {
            panelTransform.localScale =
                Vector3.Lerp(
                    panelTransform.localScale,
                    Vector3.one,
                    animationSpeed *
                    Time.unscaledDeltaTime
                );

            yield return null;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager
            .GetActiveScene()
            .buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            "MainMenu");
    }
}