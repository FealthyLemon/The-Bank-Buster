using UnityEngine;

public class Interactable
    : MonoBehaviour
{
    public DoorInteractable
        door;

    public KeyPickup
        keyPickup;

    public ElevatorInteract
        elevator;

    public VaultInteraction
        vault;

    public LeverInteractable
        lever;

    public DollarInteraction
    dollar;

    public void Interact(
        GameObject player)
    {
        if (door != null)
        {
            door.TryOpen(
                player);
        }
        else if (
            keyPickup != null)
        {
            keyPickup
                .PickUp(
                    player);
        }
        else if (
            elevator != null)
        {
            elevator
                .ActivateElevator(
                    player);
        }
        else if (
            vault != null)
        {
            vault.TryOpen(
                player);
        }
        else if (
            lever != null)
        {
            lever.Interact(
                player);
        }
        else if (
    dollar != null)
        {
            dollar
                .CollectDollar(
                    player);
        }
    }
}