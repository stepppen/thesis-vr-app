using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public Renderer overlayRenderer;

    public void ExitBtn()
    {
        Time.timeScale = 1;

        if (overlayRenderer != null)
        {
            Material overlayMaterial = overlayRenderer.material;
            overlayMaterial.color = new Color(0, 0, 0, 0);
        }


        SceneManager.LoadScene("StartMenu");
    }
}