using UnityEngine;

public class MusicManager
    : MonoBehaviour
{
    public static
        MusicManager
        Instance;

    public AudioSource
        backgroundMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PauseMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }
    }

    public void ResumeMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();
        }
    }

    public void StopMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }
    }
}