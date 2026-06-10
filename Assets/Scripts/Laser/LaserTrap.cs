using UnityEngine;
using System.Collections;

public class LaserTrap
    : MonoBehaviour
{
    public float onTime = 2f;
    public float offTime = 1f;

    private bool laserActive =
        true;

    private Renderer laserRenderer;
    private Collider laserCollider;

    void Start()
    {
        laserRenderer =
            GetComponent<Renderer>();

        laserCollider =
            GetComponent<Collider>();

        StartCoroutine(
            BlinkLaser());
    }

    IEnumerator BlinkLaser()
    {
        while (true)
        {
            SetLaserState(true);

            yield return
                new WaitForSeconds(
                    onTime);

            SetLaserState(false);

            yield return
                new WaitForSeconds(
                    offTime);
        }
    }

    void SetLaserState(
        bool state)
    {
        laserActive = state;

        laserRenderer.enabled =
            state;

        laserCollider.enabled =
            state;
    }

    private void OnTriggerEnter(
        Collider other)
    {
        if (!laserActive)
            return;

        if (other.CompareTag(
            "Player"))
        {
            GameOverManager
                .Instance
                .PlayerCaught();
        }
    }
}