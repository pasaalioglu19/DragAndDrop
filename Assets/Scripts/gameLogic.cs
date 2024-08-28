using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private int placedObject = 0;
    private int objectCount = 13;
    private int combo = 0;
    private int comboStarter = 3;
    public Text ComboCount;
    public Text ComboText;
    public GameObject PopUp;
    public SceneTransition Panel;
    public Image FlameImage;
    public Image OneStar;
    public Image TwoStar;
    public Image ThreeStar;
    private Animator flameAnim;
    

    void Start()
    {
        Panel.FadeInToScene(); // Game scene start effect
        flameAnim = FlameImage.gameObject.GetComponent<Animator>();
    }

    // In case of correct placement, the relevant procedures are organised
    public void CorrectlyPlaced()
    {
        combo++;
        placedObject++;

        if (combo == comboStarter) // Handles the combo initial state
        {
            StartCoroutine(comboTextCoroutine()); // Combo text appears on the screen
            ComboCount.gameObject.SetActive(true); 
            FlameImage.gameObject.SetActive(true);
            ComboCount.text = "x" + (combo-2).ToString();
        }
        else if (combo > comboStarter) // Handles the situation where the combo continues
        {
            StartCoroutine(flameAnimCoroutine());
            ComboCount.text = "x" + (combo - 2).ToString();
        }

        // Organises the popup display and star events when all objects are correctly placed
        if (placedObject == objectCount)
        {
            if(combo - 2 > (float)(objectCount - comboStarter + 1) / 3 * 2)
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

    // Updates the relevant combo events in case of misplacement
    public void IncorrectlyPlaced()
    {
        combo = 0;
        ComboCount.gameObject.SetActive(false);
        FlameImage.gameObject.SetActive(false);
    }

    private IEnumerator comboTextCoroutine()
    {
        ComboText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        ComboText.gameObject.SetActive(false);
    }
    private IEnumerator flameAnimCoroutine()
    {
        flameAnim.SetBool("isFlame", true);
        yield return new WaitForSeconds(1f);
        flameAnim.SetBool("isFlame", false);
    }

    // Clicking the replay button opens the game again
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
