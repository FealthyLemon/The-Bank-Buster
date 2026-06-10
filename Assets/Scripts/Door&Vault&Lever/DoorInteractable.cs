using UnityEngine;

public class DoorInteractable : MonoBehaviour
{
    public AudioSource
    doorAudio;
    public Transform doorPivot;

    public string requiredKey = "RedKey";

    public float openAngle = 90f;
    public float openSpeed = 5f;

    private bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = doorPivot.rotation;

        openRotation =
            closedRotation *
            Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        Quaternion targetRotation =
            isOpen ? openRotation : closedRotation;

        doorPivot.rotation = Quaternion.Lerp(
            doorPivot.rotation,
            targetRotation,
            openSpeed * Time.deltaTime
        );
    }

    public void TryOpen(GameObject player)
    {
        if (isOpen)
            return;

        PlayerInventory inventory =
            player.GetComponent<PlayerInventory>();

        if (inventory != null &&
            inventory.HasKey(requiredKey))
        {
            isOpen = true;

            if (doorAudio != null)
            {
                doorAudio.Play();
            }

            DoorRoomLighting
             roomLighting =
             GetComponent
    <DoorRoomLighting>();


            if (roomLighting
                != null)
            {
                roomLighting
                    .ActivateRoom();
            }

     
        }
        else
        {
            CaptionManager.Instance
            .ShowCaption(
            "I need a key to open this door");
        }
    }
}