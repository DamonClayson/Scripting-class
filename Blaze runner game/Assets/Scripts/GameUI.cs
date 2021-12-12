using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI coinsText;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameText;

    public static GameUI instance;
    void Awake() 
    {
        // Set instance to this script
        instance = this;
    }
    
    public void UpdateCoinsText(int coins)
    {
        coinsText.text = "Coins: " + coins;
    }

    public void TogglePauseMenu(bool paused)
    {
        pauseMenu.SetActive(paused);
    }

    public void OnResumeButton() 
    {
        GameManager.instance.TogglePauseGame();
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
