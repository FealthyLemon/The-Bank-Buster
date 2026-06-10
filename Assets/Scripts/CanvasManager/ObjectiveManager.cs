using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;

    public TextMeshProUGUI objectiveText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetObjective("Find Red Key");
    }

    public void SetObjective(string text)
    {
        objectiveText.text =
            "Objective:\n" + text;
    }
}