
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FadeSceneLoader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float timer = fadeDuration;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            Color color = fadeImage.color;
            color.a = timer / fadeDuration;
            fadeImage.color = color;

            yield return null;
        }

        Color finalColor = fadeImage.color;
        finalColor.a = 0;
        fadeImage.color = finalColor;
    }

    IEnumerator FadeOut(string sceneName)
    {
        float timer = 0;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            Color color = fadeImage.color;
            color.a = timer / fadeDuration;
            fadeImage.color = color;

            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}

