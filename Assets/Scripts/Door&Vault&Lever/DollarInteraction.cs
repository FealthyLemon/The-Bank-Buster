using UnityEngine;

public class DollarInteraction
    : MonoBehaviour
{
    public void CollectDollar(
        GameObject player)
    {
        FindObjectOfType
        <EndingDialogue>()
        .StartEnding();

        gameObject.SetActive(
            false);
    }
}