using UnityEngine;
using System.Collections;

public class LeverInteractable
    : MonoBehaviour
{
    public Transform
        leverHandle;

    public float
        targetXRotation =
        -70f;

    public float
        rotateSpeed =
        5f;

    public GameObject[]
        objectsToDisable;

    private bool
        isActivated =
        false;

    public void Interact(
        GameObject player)
    {
        if (isActivated)
            return;

        isActivated =
            true;

        StartCoroutine(
            RotateLever());
    }

    IEnumerator RotateLever()
    {
        Quaternion
            startRotation =
            leverHandle
            .localRotation;

        Quaternion
            targetRotation =
            Quaternion.Euler(
                targetXRotation,
                leverHandle
                .localEulerAngles.y,
                leverHandle
                .localEulerAngles.z);

        float t = 0;

        while (t < 1)
        {
            t +=
                Time.deltaTime
                * rotateSpeed;

            leverHandle
                .localRotation =
                Quaternion.Lerp(
                    startRotation,
                    targetRotation,
                    t);

            yield return null;
        }

        foreach (
            GameObject obj
            in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(
                    false);
            }
        }
    }
}