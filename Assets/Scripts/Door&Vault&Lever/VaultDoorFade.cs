using UnityEngine;
using System.Collections;

public class VaultDoorFade
    : MonoBehaviour
{
    public Renderer[]
        vaultRenderers;

    public Collider
        vaultCollider;

    public float
        fadeSpeed = 2f;

    private Material[]
        materials;

    private bool
        isOpened =
        false;

    void Start()
    {
        var allMaterials =
            new System.Collections
            .Generic.List<Material>();

        foreach (
            Renderer renderer
            in vaultRenderers)
        {
            allMaterials
                .AddRange(
                    renderer.materials);
        }

        materials =
            allMaterials
            .ToArray();
    }

    public void OpenVault()
    {
        if (isOpened)
            return;

        isOpened =
            true;

        StartCoroutine(
            FadeOut());
    }

    IEnumerator FadeOut()
    {
        float alpha = 1f;

        while (alpha > 0)
        {
            alpha -=
                Time.deltaTime *
                fadeSpeed;

            foreach (
                Material mat
                in materials)
            {
                Color color =
                    mat.color;

                color.a =
                    alpha;

                mat.color =
                    color;
            }

            yield return null;
        }

        vaultCollider.enabled =
            false;

        Destroy(
            gameObject);
    }
}