using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{
    public Button PlayButton;
    public GameObject TransitionPanel;
    private float transitionTime = 1f;

    public void FadeInToScene()
    {
        StartCoroutine(fadeInCoroutine());
    } 
    public void TransitionToScene()
    {
        StartCoroutine(transitionCoroutine());
    }

    private IEnumerator transitionCoroutine()
    {
        TransitionPanel.SetActive(true);
        CanvasGroup canvasGroup = TransitionPanel.GetComponent<CanvasGroup>();
        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / transitionTime);
            yield return Time.deltaTime;
        }
        canvasGroup.alpha = 1;

        PlayButton.transform.DOKill();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator fadeInCoroutine()
    {
        TransitionPanel.SetActive(true);
        CanvasGroup canvasGroup = TransitionPanel.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / transitionTime);
            yield return null;
        }
        canvasGroup.alpha = 0;
        TransitionPanel.SetActive(false);
    }
}
