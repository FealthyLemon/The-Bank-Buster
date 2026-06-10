using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class EndingDialogue
    : MonoBehaviour
{
    public GameObject
        endingPanel;

    public TMP_Text
        dialogueText;

    public float
        typingSpeed =
        0.03f;

    public float
        lineDelay =
        1.5f;

    private List<string>
        dialogueLines =
        new List<string>()
    {
        "MISSION COMPLETE!",

        "You successfully infiltrated the bank,",

        "avoided security",

        "and reached the vault.",

        "Reward secured.",

        "Thanks for playing",

        "THE BANK BUSTER"   
    };

    public CanvasGroup
    panelCanvasGroup;

    public float
        fadeSpeed = 2f;

    public void StartEnding()
    {
        StartCoroutine(
            StartEndingSequence());
    }

    IEnumerator
StartEndingSequence()
    {
        MusicManager
            .Instance
            .StopMusic();

        yield return
            new WaitForSeconds(
                2f);

        endingPanel
            .SetActive(true);

        panelCanvasGroup
            .alpha = 0;

        while (
            panelCanvasGroup
            .alpha < 1)
        {
            panelCanvasGroup
                .alpha +=
                Time.deltaTime
                * fadeSpeed;

            yield return
                null;
        }

        StartCoroutine(
            PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        dialogueText.text =
            "";

        foreach (
            string line
            in dialogueLines)
        {
            yield return
                StartCoroutine(
                    TypeLine(line));

            yield return
                new WaitForSeconds(
                    lineDelay);

            dialogueText.text =
                "";
        }

        StartCoroutine(
            ReturnToMenu());
    }

    IEnumerator TypeLine(
        string line)
    {
        dialogueText.text =
            "";

        foreach (
            char letter
            in line)
        {
            dialogueText.text +=
                letter;

            yield return
                new WaitForSeconds(
                    typingSpeed);
        }
    }
    IEnumerator
ReturnToMenu()
    {
        yield return
            new WaitForSeconds(
                2f);

        SceneManager
            .LoadScene(
                "MainMenu");
    }
}