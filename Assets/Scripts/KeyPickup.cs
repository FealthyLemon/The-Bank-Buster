using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyName = "RedKey";

    public void PickUp(GameObject player)
    {
        Debug.Log("Picked up key");

        PlayerInventory inventory =
            player.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.AddKey(keyName);
            ObjectiveManager.Instance
        .SetObjective(
        "Open Security Door");

            Destroy(gameObject);
        }
    }
}