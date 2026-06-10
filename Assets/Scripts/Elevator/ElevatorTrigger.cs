using UnityEngine;

public class ElevatorTrigger
    : MonoBehaviour
{
    public ElevatorSystem elevator;

    private void OnTriggerEnter(
        Collider other)
    {
        if (other.CompareTag(
            "Player"))
        {
            elevator.PlayerEntered();
        }
    }
}