using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // When button "Play" is pressed play game
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level 1");
    }
    // When button "Quit", quit game
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
