using UnityEngine;

public class GuardAnimationController
    : MonoBehaviour
{
    public Animator animator;

    public Transform guard;

    Vector3 lastPosition;

    void Start()
    {
        lastPosition =
            guard.position;
    }

    void Update()
    {
        float distanceMoved =
            Vector3.Distance(
                guard.position,
                lastPosition);

        bool isWalking =
            distanceMoved >
            0.01f;

        animator.SetBool(
            "IsWalking",
            isWalking);

        lastPosition =
            guard.position;
    }
}