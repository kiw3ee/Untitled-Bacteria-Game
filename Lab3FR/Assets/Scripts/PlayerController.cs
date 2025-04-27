using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //move variables
    public float moveSpeed = 5f;
    public float acceleration = 10f;

    //dash variables
    public float dashForce = 20f;
    public float dashCooldown = 1f;
    public float dashDuration = 3f;

    public float rotationSpeed = 3f;

    private Rigidbody rb;
    private Vector3 moveInput;
    private float lastDashTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Turn off gravity for underwater movement
        rb.drag = 2f; // Some drag for smooth underwater feel
    }

    void Update()
    {
        // Get input for movement
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float vertical = Input.GetAxisRaw("Vertical");     // W/S
        float upDown = 0f;

        if (Input.GetKey(KeyCode.E)) upDown += 1f; // Up
        if (Input.GetKey(KeyCode.Q)) upDown -= 1f; // Down

        // Combine into a movement vector relative to the player's orientation
        moveInput = (transform.forward * vertical +
                     transform.right * horizontal +
                     transform.up * upDown).normalized;

        // Dash input
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDashTime + dashCooldown)
        {
            Dash();
        }

        RotatePlayer();
    }

    void FixedUpdate()
    {
        // Smooth movement force
        Vector3 targetVelocity = moveInput * moveSpeed;
        Vector3 velocityChange = (targetVelocity - rb.velocity);
        rb.AddForce(velocityChange * acceleration, ForceMode.Acceleration);
    }

    void Dash()
    {
        rb.AddForce(moveInput * dashForce, ForceMode.VelocityChange);
        lastDashTime = Time.time;
    }
    
    void RotatePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}