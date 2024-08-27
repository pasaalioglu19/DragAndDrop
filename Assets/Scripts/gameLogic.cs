using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameLogic : MonoBehaviour
{
    private int placedObject = 0;
    private int objectCount = 13;
    private int combo = 0;
    private int comboStarter = 3;
    public Text comboCount;
    public Text comboText;
    public GameObject popUp;
    public SceneTransition panel;
    public Image flameImage;
    public Image oneStar;
    public Image twoStar;
    public Image threeStar;
    private Animator flameAnim;
    

    void Start()
    {
        panel.FadeInToScene(); // Game scene start effect
        flameAnim = flameImage.gameObject.GetComponent<Animator>();
    }

    // In case of correct placement, the relevant procedures are organised
    public void correctlyPlaced()
    {
        combo++;
        placedObject++;

        if (combo == comboStarter) // Handles the combo initial state
        {
            StartCoroutine(comboTextCoroutine()); // Combo text appears on the screen
            comboCount.gameObject.SetActive(true); 
            flameImage.gameObject.SetActive(true);
            comboCount.text = "x" + (combo-2).ToString();
        }
        else if (combo > comboStarter) // Handles the situation where the combo continues
        {
            StartCoroutine(flameAnimCoroutine());
            comboCount.text = "x" + (combo - 2).ToString();
        }

        // Organises the popup display and star events when all objects are correctly placed
        if (placedObject == objectCount)
        {
            if(combo - 2 > (float)(objectCount - comboStarter + 1) / 3 * 2)
            {
                threeStar.gameObject.SetActive(true);
            }
            else if (combo - 2 > (float)(objectCount - comboStarter + 1) / 3)
            {
                twoStar.gameObject.SetActive(true);
            }
            else
            {
                oneStar.gameObject.SetActive(true);
            }
            popUp.SetActive(true);
        }
    }

    // Updates the relevant combo events in case of misplacement
    public void incorrectlyPlaced()
    {
        combo = 0;
        comboCount.gameObject.SetActive(false);
        flameImage.gameObject.SetActive(false);
    }

    private IEnumerator comboTextCoroutine()
    {
        comboText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.4f);
        comboText.gameObject.SetActive(false);
    }
    private IEnumerator flameAnimCoroutine()
    {
        flameAnim.SetBool("isFlame", true);
        yield return new WaitForSeconds(1f);
        flameAnim.SetBool("isFlame", false);
    }

    // Clicking the replay button opens the game again
    public void retryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
