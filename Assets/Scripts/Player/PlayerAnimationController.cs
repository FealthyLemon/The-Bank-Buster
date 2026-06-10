using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController
    : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        bool isWalking = false;

        if (Keyboard.current != null)
        {
            isWalking =
                Keyboard.current.wKey.isPressed ||
                Keyboard.current.aKey.isPressed ||
                Keyboard.current.sKey.isPressed ||
                Keyboard.current.dKey.isPressed;
        }

        animator.SetBool(
            "IsWalking",
            isWalking);
    }
}