using UnityEngine;
using DG.Tweening;
using UnityEngine.UI; 

public class PlayButton : MonoBehaviour
{
    [Header("Button Settings")]
    [SerializeField] float buttonGrownScale = 1.14f;
    [SerializeField] float buttonGrownTime = 0.4f;
    [SerializeField] float buttonRotateAngle = 3;
    [SerializeField] float buttonRotateTime = 0.4f;
    public Button playbutton;
    void Start()
    {
        ButtonScaleEffect();
        ButtonRotateEffect();
    }
    private void ButtonScaleEffect()
    {
        Vector3 originalScale = playbutton.transform.localScale;
        playbutton.transform.DOScale(originalScale * buttonGrownScale, buttonGrownTime).SetLoops(-1, LoopType.Yoyo);
    }
    private void ButtonRotateEffect()
    {
        playbutton.transform.DORotate(new Vector3(0, 0, buttonRotateAngle), buttonRotateTime)
            .OnComplete(() =>
            {
                playbutton.transform.DORotate(new Vector3(0, 0, -buttonRotateAngle), buttonRotateTime)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetEase(Ease.InOutSine);
            })
            .SetEase(Ease.InOutSine);
    }
}
