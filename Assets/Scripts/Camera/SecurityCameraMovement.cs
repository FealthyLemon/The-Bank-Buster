using UnityEngine;

public class SecurityCameraMovement : MonoBehaviour
{
    public float rotationAngle = 45f;
    public float rotationSpeed = 2f;

    private float startYRotation;

    void Start()
    {
        startYRotation =
            transform.eulerAngles.y;
    }

    void Update()
    {
        float angle =
            Mathf.Sin(
                Time.time * rotationSpeed
            ) * rotationAngle;

        transform.rotation =
            Quaternion.Euler(
                transform.eulerAngles.x,
                startYRotation + angle,
                transform.eulerAngles.z
            );
    }
}