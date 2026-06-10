using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private Interactable currentInteractable;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (currentInteractable != null)
            {
                currentInteractable.Interact(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable =
            other.GetComponent<Interactable>();

        if (interactable != null)
        {
            currentInteractable = interactable;

            Debug.Log("Can interact with: "
                + other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable interactable =
            other.GetComponent<Interactable>();

        if (interactable != null &&
            currentInteractable == interactable)
        {
            currentInteractable = null;
        }
    }
}