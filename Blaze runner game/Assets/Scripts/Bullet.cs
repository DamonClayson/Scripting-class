using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;

    public GameObject breakableWall;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    // Bullet speed/direction
    void Start()
    {
       rb.velocity = transform.right * bulletSpeed;
    }

    // If bullet collides with breakableWall Destroy
    void OnTriggerEnter2D(Collider2D breakableWall)
    {
        Destroy(gameObject);
    }
}
