using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameManager gameManager;
    
    // When you enter "End" run wingame
    void OnTriggerEnter2D()
    {
        gameManager.WinGame();
    }
}
