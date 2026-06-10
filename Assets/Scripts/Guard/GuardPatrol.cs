using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;

    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;

    public float waitTime = 0f;

    private int currentPointIndex = 0;
    private bool movingForward = true;

    private float waitTimer = 0f;
    private bool isWaiting = false;

    void Update()
    {
        if (patrolPoints.Length == 0)
            return;

        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0)
            {
                isWaiting = false;
                ChangePoint();
            }

            return;
        }

        MoveGuard();
    }

    void MoveGuard()
    {
        Transform targetPoint =
            patrolPoints[currentPointIndex];

        Vector3 targetPosition =
            new Vector3(
                targetPoint.position.x,
                transform.position.y,
                targetPoint.position.z
            );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        Vector3 direction =
            (targetPosition - transform.position)
            .normalized;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation =
                Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
        }

        if (Vector3.Distance(
            transform.position,
            targetPosition) < 0.1f)
        {
            if (waitTime > 0)
            {
                isWaiting = true;
                waitTimer = waitTime;
            }
            else
            {
                ChangePoint();
            }
        }
    }

    void ChangePoint()
    {
        if (movingForward)
        {
            currentPointIndex++;

            if (currentPointIndex >= patrolPoints.Length)
            {
                currentPointIndex =
                    patrolPoints.Length - 2;

                movingForward = false;
            }
        }
        else
        {
            currentPointIndex--;

            if (currentPointIndex < 0)
            {
                currentPointIndex = 1;

                movingForward = true;
            }
        }
    }
}