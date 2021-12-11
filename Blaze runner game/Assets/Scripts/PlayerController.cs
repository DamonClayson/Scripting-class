using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{   
    private BoxCollider2D coll;
    private Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed = 10f;
    public float jumpForce = 15f;

    [Header("Wall Jump")]
    public float wallJumpTime = 0.2f;
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = .5f;
    public bool iswallSliding = false;
    RaycastHit2D WallCheckHit;
    float jumpTime;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public float groundRadius = 0.2f;
    bool isGrounded = false;

    bool isFacingRight = true;
    float mx = 0f;

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
    // Player movement/velocity
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 10, rb.velocity.y);

    // Player direction
        mx = Input.GetAxis("Horizontal");

        if(mx < 0) 
        {
            isFacingRight = false;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        } 
            else 
            { 
                isFacingRight = true;
                transform.localScale = new Vector2(1, transform.localScale.y);
            }        

    // Check if space is pressed and if player is on ground
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, 15);
        }
    // Check if player is on ground and if he can jump when ok ground
        bool touchingGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        if(touchingGround)
        {
            isGrounded = true;
        }
            else
            {
                isGrounded = false;
            }
    }

    // Checks if player is on ground and if he can jump when on ground
    //private bool isGrounded()
    //{
        //return Physics2D.BoxCast(GetComponent<Collider2D>().bounds.center, GetComponent<Collider2D>().bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    //}

    // Checks if player collides with "Trap". If so, make player static
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    void FixedUpdate() 
    {
        // Wall Jump
        // https://www.youtube.com/watch?v=adT3vSD-74Q&t=203s&ab_channel=MuddyWolf - Code for wall jump
         if (isFacingRight) 
        {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, jumpableGround);
            Debug.DrawRay(transform.position,  new Vector2(wallDistance, 0), Color.blue);
        } 
            else 
            {
                WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, jumpableGround);
                Debug.DrawRay(transform.position,  new Vector2(-wallDistance, 0), Color.blue);
            }

        if (WallCheckHit !&& isGrounded && mx != 0)
        {
            iswallSliding = true;
            jumpTime = Time.time + wallJumpTime;
        } 
            else if (jumpTime < Time.time) 
            {
                iswallSliding = false;
            }

        if (iswallSliding) 
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MaxValue));
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
} 
