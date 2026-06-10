using UnityEngine;
using System.Collections;

public class ElevatorSystem : MonoBehaviour
{
    public string requiredCard =
    "ElevatorCard";


    public Transform leftDoor;
    public Transform rightDoor;

    public Transform teleportLocation;

    public float openDistance = 1f;
    public float doorSpeed = 2f;

    private Vector3 leftClosedPos;
    private Vector3 rightClosedPos;

    private Vector3 leftOpenPos;
    private Vector3 rightOpenPos;

    private bool isBusy = false;
    private bool elevatorActive = false;

    private GameObject playerInside;

    void Start()
    {
        leftClosedPos =
            leftDoor.localPosition;

        rightClosedPos =
            rightDoor.localPosition;

        // OLD WORKING DOOR LOGIC
        leftOpenPos =
            leftClosedPos +
            Vector3.left *
            openDistance;

        rightOpenPos =
            rightClosedPos +
            Vector3.right *
            openDistance;
    }

    public void UseElevator(
    GameObject player)
    {
        if (isBusy)
            return;

        PlayerInventory inventory =
            player.GetComponent<
                PlayerInventory>();

        if (inventory == null)
            return;

        if (!inventory.HasKey(
            requiredCard))
        {
            CaptionManager.Instance
                .ShowCaption(
                "I need an elevator card");

            return;
        }

        playerInside = player;

        elevatorActive = true;

        StartCoroutine(OpenDoors());
    }

    public void PlayerEntered()
    {
        if (!elevatorActive ||
            isBusy ||
            playerInside == null)
            return;

        StartCoroutine(
            DelayedElevatorRide());
    }

    IEnumerator DelayedElevatorRide()
    {
        isBusy = true;

        // wait before closing
        yield return new WaitForSeconds(1f);

        yield return ElevatorRide();
    }

    IEnumerator ElevatorRide()
    {
        isBusy = true;

        yield return CloseDoors();

        // FADE TO BLACK
        yield return ScreenFader
            .Instance
            .FadeIn();

        yield return new WaitForSeconds(
            1.5f);

        // TELEPORT
        playerInside.transform.position =
            teleportLocation.position;

        // WAIT A LITTLE
        yield return new WaitForSeconds(
            1f);

        // FADE OUT
        yield return ScreenFader
            .Instance
            .FadeOut();

        yield return OpenDoors();

        elevatorActive = false;
        isBusy = false;
    }

    IEnumerator OpenDoors()
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime *
                 doorSpeed;

            leftDoor.localPosition =
                Vector3.Lerp(
                    leftDoor.localPosition,
                    leftOpenPos,
                    t);

            rightDoor.localPosition =
                Vector3.Lerp(
                    rightDoor.localPosition,
                    rightOpenPos,
                    t);

            yield return null;
        }
    }

    IEnumerator CloseDoors()
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime *
                 doorSpeed;

            leftDoor.localPosition =
                Vector3.Lerp(
                    leftDoor.localPosition,
                    leftClosedPos,
                    t);

            rightDoor.localPosition =
                Vector3.Lerp(
                    rightDoor.localPosition,
                    rightClosedPos,
                    t);

            yield return null;
        }
    }
}