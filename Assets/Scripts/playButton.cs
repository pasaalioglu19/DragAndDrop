using UnityEngine;


public class PlayButton : MonoBehaviour
{
    public SceneTransition Panel;
    public void PlayScene()
    {
        Panel.TransitionToScene(); // Switches to the next scene
    }
}
