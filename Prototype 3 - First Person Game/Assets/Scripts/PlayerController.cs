using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    // Movement speed in units per second
    public float moveSpeed;
    // Force player upwards
    public float jumpForce;
    public int curHP;
    public int maxHP;
    [Header("Mouse Look")]
    // Mouse sensitivity
    public float lookSensitivity;
    // Highest and lowest we can look down and up
    public float maxLookX = 50;
    public float minLookX = -50;
    // X rotation of player
    private float rotX;
    private Camera camera;
    private Rigidbody rb;
    private Weapon weapon;

    void Awake() 
    {
        weapon = GetComponent<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
            Die();
    }
    // If Players health is zero, run Die()
    void Die()
        {
            
        }
    
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        
        // rb.velocity = new Vector3(x, rb.velocity.y, z); <- Old code
        // Move direction relative to camera
        Vector3 dir = transform.right * x + transform.forward * z;
        rb.velocity = dir;
        dir.y = rb.velocity.y;


    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }

        if(Input.GetButtonDown("Jump"))
            Jump();
    }

}


