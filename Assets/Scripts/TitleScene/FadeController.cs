using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    public Image fadeImage; // フェードに使用するImage
    public float fadeSpeed = 2.0f; // フェードの速さ

    private bool isFading = false;

    public void StartFadeOut(string sceneName)
    {
        if (!isFading)
        {
            StartCoroutine(FadeOut(sceneName));
        }
    }

    private IEnumerator FadeOut(string sceneName)
    {
        isFading = true;
        fadeImage.enabled = true;

        Color color = fadeImage.color;
        while (color.a < 1.0f)
        {
            color.a += Time.deltaTime * fadeSpeed;
            fadeImage.color = color;
            yield return null;
        }

        // シーン遷移
        SceneManager.LoadScene(sceneName); 
    }
}