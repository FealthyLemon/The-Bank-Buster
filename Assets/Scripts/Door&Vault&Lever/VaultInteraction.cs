using UnityEngine;

public class VaultInteraction
    : MonoBehaviour
{
    public string
        requiredKey;

    private bool
        isOpen =
        false;

    public void TryOpen(
        GameObject player)
    {
        if (isOpen)
            return;

        PlayerInventory
            inventory =
            player
            .GetComponent
            <PlayerInventory>();

        if (inventory != null &&
            inventory
            .HasKey(
                requiredKey))
        {
            isOpen =
                true;

            GetComponent
            <VaultDoorFade>()
            .OpenVault();
        }
    }
}