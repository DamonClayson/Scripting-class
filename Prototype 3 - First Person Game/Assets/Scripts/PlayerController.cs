using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed in units per second
    public float moveSpeed;
    // Force player upwards
    public float jumpForce;
    // Mouse sensitivity
    public float lookSensitivity;
    // Highest and lowest we can look down and up
    public float maxLookX = 50;
    public float minLookX = -50;
    // X rotation of player
    private float rotX;
    private Camera camera;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        camera = camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
    }
}


