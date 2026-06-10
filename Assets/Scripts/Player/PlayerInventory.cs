using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    private HashSet<string> keys =
        new HashSet<string>();

    public void AddKey(string keyName)
    {
        keys.Add(keyName);

        Debug.Log("Picked up: " + keyName);
    }

    public bool HasKey(string keyName)
    {
        return keys.Contains(keyName);
    }
}