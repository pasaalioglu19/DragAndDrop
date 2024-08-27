using UnityEngine;


public class playButton : MonoBehaviour
{
    public SceneTransition panel;
    public void playScene()
    {
        panel.TransitionToScene(); // Switches to the next scene
    }
}
