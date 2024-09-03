using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private int placedObject = 0;
    private int objectCount = 13;

    [Header("Combo Settings")]
    [SerializeField] int combo = 0;
    [SerializeField] int comboStarter = 3;
    public GameObject PopUp;
    public SceneTransition Panel;
    public Image OneStar;
    public Image TwoStar;
    public Image ThreeStar;
    public AnimationScripts AnimationScript;


    // Game scene start effect
    void Start()
    {
        Panel.FadeInToScene(); 
    }

    // Clicking the replay button opens the game again
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // In case of correct placement, the relevant procedures are organised
    public void CorrectlyPlaced(bool isCorrectlyPlaced)
    {
        if (isCorrectlyPlaced)
        {
            combo++;
            placedObject++;

            if (combo == comboStarter) // Handles the combo initial state
            {
                startTheCombo();
            }
            else if (combo > comboStarter) // Handles the situation where the combo continues
            {
                continueTheCombo();
            }

            if (placedObject == objectCount) // Organises the popup display and star events when all objects are correctly placed
            {
                finishTheGame();
            }
            return;
        }

        combo = 0;
        AnimationScript.IncorrectPlacedDeactivate();
    }

    private void startTheCombo()
    {
        AnimationScript.ComboTextEffect();
        AnimationScript.FlameScaleEffect1();
        AnimationScript.ComboCountEffect(combo - 2, true);
    }

    private void continueTheCombo()
    {
        AnimationScript.FlameScaleEffect2();
        AnimationScript.ComboCountEffect(combo - 2, false);
    }
    private void finishTheGame()
    {
        if (combo - 2 > (float)(objectCount - comboStarter + 1) / 3 * 2)
        {
            ThreeStar.gameObject.SetActive(true);
        }
        else if (combo - 2 > (float)(objectCount - comboStarter + 1) / 3)
        {
            TwoStar.gameObject.SetActive(true);
        }
        else
        {
            OneStar.gameObject.SetActive(true);
        }
        PopUp.SetActive(true);
    }

}
