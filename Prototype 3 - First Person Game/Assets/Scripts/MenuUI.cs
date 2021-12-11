using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    // When button "Play" is pressed start game
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    // When button "Quit" is pressed quit game
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
