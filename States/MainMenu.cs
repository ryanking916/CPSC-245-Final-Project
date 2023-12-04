using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Called when the "Play" button is clicked
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OnInstructionsButton()
    {
        SceneManager.LoadScene(2);
    }

    // Called when the "Quit" button clicked
    public void OnQuitButton ()
    {
        Application.Quit();
    }
}
