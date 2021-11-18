using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private BoxCollider2D coll;
    private Rigidbody2D rb;

// Can player jump on ground
    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {   
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7, rb.velocity.y);

    // Check if space is pressed and if player is on ground
        if(Input.GetKeyDown("space") && IsGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, 10);
        }
    }

// Checks if player is on ground and if he can jump when on ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(GetComponent<Collider2D>().bounds.center, GetComponent<Collider2D>().bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
} 
