using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class
    IntroDialogueManager
    : MonoBehaviour
{
    public GameObject
        dialoguePanel;

    public TMP_Text
        dialogueText;

    public MonoBehaviour
        playerMovement;

    public float
        typingSpeed = 0.03f;

    private string[]
        dialogueLines =
    {
        "Gentleman...",

        "Your mission is simple. Bust this bank.",

        "Somewhere inside this building lies a vault containing a reward of unimaginable value.",

        "It could be millions in diamonds...",

        "It could be stacks of gold...",

        "Or perhaps a fortune that changes your life forever.",

        "Unfortunately... the bank strongly disagrees with theft.",

        "Security guards patrol every floor.",

        "Cameras, lasers, locked doors... annoying little obstacles.",

        "Avoid getting caught at all costs. Prison food is terrible.",

        "Search every room carefully.",

        "Find keys. Unlock doors. Reach the vault room.",

        "One wrong move... and the guards will end your career immediately.",

        "Now go make history."
    };

    private int
        currentLine = 0;

    private bool
        isTyping = false;

    private bool
        dialogueFinished =
        false;

    void Start()
    {
        if (IntroState
    .hasPlayed)
        {
            dialoguePanel
                .SetActive(false);

            return;
        }

        dialoguePanel
            .SetActive(true);

        playerMovement
            .enabled = false;

        StartCoroutine(
            TypeLine());
    }

    void Update()
    {
        if (dialogueFinished)
            return;

        if (
    Mouse.current.leftButton
        .wasPressedThisFrame
    ||
    Keyboard.current
        .anyKey
        .wasPressedThisFrame
)
        {
            if (isTyping)
            {
                StopAllCoroutines();

                dialogueText.text =
                    dialogueLines[
                        currentLine];

                isTyping = false;
            }
            else
            {
                currentLine++;

                if (currentLine
                    < dialogueLines
                    .Length)
                {
                    StartCoroutine(
                        TypeLine());
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    IEnumerator
        TypeLine()
    {
        isTyping = true;

        dialogueText.text = "";

        foreach (
            char letter in
            dialogueLines[
                currentLine])
        {
            dialogueText.text
                += letter;

            yield return
                new WaitForSeconds(
                    typingSpeed);
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        dialogueFinished
            = true;

        dialoguePanel
            .SetActive(false);

        playerMovement
            .enabled = true;

        IntroState
    .hasPlayed =
    true;
    }
}