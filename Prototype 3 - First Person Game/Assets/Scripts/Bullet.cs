using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

    public float lifetime;

    private float shootTime;

    void OnEnable()
    {
            shootTime = Time.time;
    }
    
    void OnTriggerEnter(Collider other)
    {
        // If player or enemy gets hit, take damage
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        else if(other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);
        // Disable projectile
        gameObject.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);  
    }
}