using UnityEngine;

public class CameraSpotlightDetector
    : MonoBehaviour
{
    private bool playerCaught =
        false;

    private void OnTriggerEnter(
        Collider other)
    {
        if (playerCaught)
            return;

        if (other.CompareTag(
            "Player"))
        {
            playerCaught = true;

            GameOverManager
                .Instance
                .PlayerCaught();
        }
    }
}