using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class AnimationScripts : MonoBehaviour
{
    [Header("Flame Settings")]
    [SerializeField] float flameGrownScale1 = 1.14f;
    [SerializeField] float flameGrownScale2 = 1.06f;
    [SerializeField] float flameGrownTime = 0.38f;
    [SerializeField] int flameGrownCount = 4;
    [SerializeField] int flameGrownCount2 = 2;
    [Header("Combo Text Settings")]
    [SerializeField] float comboTextGrownScale = 2.1f;
    [SerializeField] float comboTextGrownTime = 1.2f;
    [SerializeField] float comboTextTime = 0.2f;
    [SerializeField] int comboTextCount = 3;
    [Header("Combo Count Settings")]
    [SerializeField] float comboCountTime = 0.25f;
    [SerializeField] int comboCountCount = 6;
    [Header("Lightbulb Settings")]
    [SerializeField] float lightbulbGrownScale = 1.275f;
    [SerializeField] float lightbulbGrownTime = 1f;
    [SerializeField] int lightbulbGrownCount = 3;

    public GameObject ComboCount;
    public GameObject Flame;
    public GameObject ComboText;
    public GameObject Lightbulb;
    private RectTransform flameRectTransform;

    private void Start()
    {
        flameRectTransform = Flame.GetComponent<RectTransform>();
    }

    public void ComboTextEffect()
    {
        comboTextScaleEffect();
        comboTextColorEffect();
    }

    public void IncorrectPlacedDeactivate()
    {
        ComboCount.SetActive(false);
        Flame.SetActive(false);
    }
    public void LightBulbScale()
    {
        Lightbulb.GetComponent<RectTransform>().DOScale(lightbulbGrownScale, lightbulbGrownTime).SetLoops(lightbulbGrownCount * 2, LoopType.Yoyo);
    }

    public void ComboCountEffect(int combo, bool isFirstTime)
    {
        if (isFirstTime)
        {
            ComboCount.SetActive(true);
        }
        ComboCount.GetComponent<Text>().text = "x" + combo .ToString();
        Color yellow = Color.yellow;
        Text ComboCountI = ComboCount.GetComponent<Text>();
        ComboCountI.DOColor(yellow, comboCountTime).SetLoops(comboCountCount, LoopType.Yoyo);
    }
    public void FlameScaleEffect1()
    {
        Flame.SetActive(true);
        flameRectTransform.DOScale(flameGrownScale1, flameGrownTime).SetLoops(flameGrownCount * 2, LoopType.Yoyo);
    }
    public void FlameScaleEffect2()
    {
        Flame.GetComponent<RectTransform>().DOScale(flameGrownScale2, flameGrownTime).SetLoops(flameGrownCount2 * 2, LoopType.Yoyo);
    }

    private void comboTextScaleEffect()
    {
        ComboText.SetActive(true);
        ComboText.GetComponent<RectTransform>().DOScale(comboTextGrownScale, comboTextGrownTime).SetLoops(2, LoopType.Yoyo);
    }

    private void comboTextColorEffect()
    {
        Color white = Color.white;
        Color red = Color.red;
        Color yellow = Color.yellow;

        Text comboTextI = ComboText.GetComponent<Text>();

        Sequence colorSequence = DOTween.Sequence();
        colorSequence.Append(comboTextI.DOColor(red, comboTextTime))
                     .Append(comboTextI.DOColor(yellow, comboTextTime))
                     .Append(comboTextI.DOColor(red, comboTextTime))
                     .Append(comboTextI.DOColor(white, comboTextTime));

        colorSequence.SetLoops(comboTextCount, LoopType.Restart).OnComplete(() =>
        {
            ComboText.SetActive(false);
        });
    }
}