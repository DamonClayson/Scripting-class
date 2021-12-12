using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gamePaused;

    private bool gameLost = false;

    public GameObject EndGameScreenUI;

    // Instance
    public static GameManager instance;


    void Awake()
    {
        // Set instance to this script
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
    }
    

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        // Toggle the pause menu
        GameUI.instance.TogglePauseMenu(gamePaused);
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void WinGame()
    {
        // Pause game when you win
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true? 0.0f : 1.0f;

        // Display endgamescreen and unlock mouse when you win
        EndGameScreenUI.SetActive(true);
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void LoseGame()
    {
        if(gameLost == false)
        {
            // When you die restart level
            gameLost = true;
            print("You Died");
            Restart();
        }
    }
    void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }
}
