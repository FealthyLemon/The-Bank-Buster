using UnityEngine;

public class DoorRoomLighting
    : MonoBehaviour
{
    public GameObject
        currentRoomLights;

    public GameObject
        nextRoomLights;

    private bool
        hasActivated =
        false;

    public void ActivateRoom()
    {
        if (hasActivated)
            return;

        hasActivated =
            true;

        if (currentRoomLights
            != null)
        {
            currentRoomLights
                .SetActive(false);
        }

        if (nextRoomLights
            != null)
        {
            nextRoomLights
                .SetActive(true);
        }
    }
}