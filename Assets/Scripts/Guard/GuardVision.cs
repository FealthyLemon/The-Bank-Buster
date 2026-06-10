using UnityEngine;

public class GuardVision : MonoBehaviour
{
    public float viewDistance = 5f;
    public float viewAngle = 90f;

    public Transform eyes;

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        Vector3 eyePosition = eyes.position;

        Vector3 playerDirection =
            player.transform.position - eyePosition;

        float distanceToPlayer =
            playerDirection.magnitude;

        if (distanceToPlayer > viewDistance)
            return;

        float angle =
            Vector3.Angle(
                transform.forward,
                playerDirection.normalized
            );

        if (angle > viewAngle / 2)
            return;

        RaycastHit hit;

        if (Physics.Raycast(
            eyePosition,
            playerDirection.normalized,
            out hit,
            viewDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                GuardPatrol patrol =
    GetComponent<GuardPatrol>();

                if (patrol != null)
                {
                    patrol.enabled = false;
                }

                GameOverManager
                    .Instance
                    .PlayerCaught();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 leftRay =
            Quaternion.Euler(
                0,
                -viewAngle / 2,
                0)
            * transform.forward;

        Vector3 rightRay =
            Quaternion.Euler(
                0,
                viewAngle / 2,
                0)
            * transform.forward;

        Gizmos.DrawRay(
            transform.position,
            leftRay * viewDistance
        );

        Gizmos.DrawRay(
            transform.position,
            rightRay * viewDistance
        );
    }
}