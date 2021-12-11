using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUps : MonoBehaviour

{
    [Header("Coins")]
    public int coins = 0;
    public Text coinsText;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins = coins + 1;
            print("Picked up coin");
            GameUI.instance.UpdateCoinsText(coins);
        }
    }
}
