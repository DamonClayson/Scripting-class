using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUps : MonoBehaviour

{
    [Header("Coins")]
    public int coins = 0;
    public Text coinsText;

    public GameObject coinPickupParticle;

    // Get audio for coin pickup
    public AudioClip coinSFX;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins = coins + 1;
            print("Picked up coin");
            // Update Coins text when coin in picked up
            GameUI.instance.UpdateCoinsText(coins);
            // Create the coin pickup particle
            GameObject obj = Instantiate(coinPickupParticle, transform.position, Quaternion.identity);
            Destroy(obj, 0.8f);
        }
        // Reference Audio Source to play sound effect
        collision.GetComponent<AudioSource>().PlayOneShot(coinSFX);
    }
}
