using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public GameObject transitionPanel;
    private float transitionTime = 1f;

    public void FadeInToScene()
    {
        StartCoroutine(FadeInCoroutine());
    }
    public void TransitionToScene()
    {
        StartCoroutine(TransitionCoroutine());
    }

    private IEnumerator TransitionCoroutine()
    {
        // Paneli g�ster ve fade out yap
        transitionPanel.SetActive(true);
        CanvasGroup canvasGroup = transitionPanel.GetComponent<CanvasGroup>();
        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / transitionTime);
            yield return null;
        }
        canvasGroup.alpha = 1;

        // Yeni sahneyi y�kle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator FadeInCoroutine()
    {
        // Yeni sahne y�klendi�inde fade in yap
        transitionPanel.SetActive(true);
        CanvasGroup canvasGroup = transitionPanel.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / transitionTime);
            yield return null;
        }
        canvasGroup.alpha = 0;
        transitionPanel.SetActive(false);
    }
}
