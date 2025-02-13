using System.Collections;
using UnityEngine;

public class MenuToggler : MonoBehaviour
{
    public GameObject gameMenu;
    public Renderer overlayRenderer;
    public float fadeDuration = 0.5f;

    private bool isPaused = false;
    private Material overlayMaterial;
    private Coroutine fadeCoroutine;

    void Start()
    {
        Time.timeScale = 1;
        if (gameMenu == null)
        {
            gameMenu = GameObject.Find("Menu");
        }

        if (overlayRenderer != null)
        {
            overlayMaterial = overlayRenderer.material;
            overlayMaterial.color = new Color(0, 0, 0, 0);
        }
        else
        {
            Debug.LogWarning("renderer not found");
        }
    }

    public void ToggleMenu()
    {
        isPaused = !isPaused;
        if (gameMenu != null)
        {
            gameMenu.SetActive(isPaused);
        }

        if (overlayRenderer != null)
        {

            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
            }

            fadeCoroutine = StartCoroutine(FadeOverlay(isPaused ? 0.6f : 0f));
        }


        Time.timeScale = isPaused ? 0f : 1f;
    }

    private IEnumerator FadeOverlay(float targetAlpha)
    {
        if (overlayMaterial == null && overlayRenderer != null)
        {
            overlayMaterial = overlayRenderer.material;
        }

        float startAlpha = overlayMaterial.color.a;
        float elapsedTime = 0f;


        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            overlayMaterial.color = new Color(0, 0, 0, newAlpha);
            yield return null;
        }

        overlayMaterial.color = new Color(0, 0, 0, targetAlpha);
    }
}