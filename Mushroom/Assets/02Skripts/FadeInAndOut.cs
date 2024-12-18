using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOut : MonoBehaviour
{
    public Player player;
    public void DoFadeIn(Image image, float fadeDuration)
        => StartCoroutine(FadeIn(image, fadeDuration));

    public void DoFadeOut(Image image, float fadeDuration)
        => StartCoroutine(FadeOut(image, fadeDuration));

    public IEnumerator FadeIn(Image image, float fadeDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            Color color = image.color;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            image.color = color;
            yield return null;
        }

        Color resCol = image.color;
        resCol.a = 1f;
        image.color = resCol;
    }

    public IEnumerator FadeOut(Image image, float fadeDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            Color color = image.color;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            image.color = color;
            yield return null;
        }

        Color resCol = image.color;
        resCol.a = 1f;
        image.color = resCol;

        yield return new WaitForSeconds(2f);
        player.imageGallery.displayImage.gameObject.SetActive(true);
    }
}
