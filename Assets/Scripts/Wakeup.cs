using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WakeUpEffectWithPanel : MonoBehaviour
{
    public Image panelImage;  
    public float fadeDuration = 2f; 

    private void Start()
    {
        StartCoroutine(FadeFromBlack());
    }

    private IEnumerator FadeFromBlack()
    {
        Color panelColor = panelImage.color;
        float fadeSpeed = 1f / fadeDuration;  // Speed of fade (alpha per second)
        float progress = 0f;  // Tracks the progress of the fade

        // Gradually reduce the alpha of the panel's color to create a fade-out effect
        while (progress < 1f)
        {
            progress += Time.deltaTime * fadeSpeed;
            panelColor.a = Mathf.Lerp(1f, 0f, progress); 
            panelImage.color = panelColor;  

            yield return null; 
        }

        panelColor.a = 0f;
        panelImage.color = panelColor;
    }
}
