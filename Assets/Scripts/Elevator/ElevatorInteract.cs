using UnityEngine;

public class ElevatorInteract : MonoBehaviour
{
    public ElevatorSystem elevator;

    public void ActivateElevator(
        GameObject player)
    {
        elevator.UseElevator(player);
    }
}