using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 5f;
    public float verticalSpeed = 3f;

    [Header("Dash")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody rb;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float cooldownTimer = 0f;
    private Vector3 dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;     
        rb.drag = 1f;              
    }

    void Update()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && cooldownTimer <= 0f)
        {
            StartDash();
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = dashDirection * dashSpeed + Vector3.down * 1f; 
            dashTimer -= Time.fixedDeltaTime;

            if (dashTimer <= 0f)
            {
                isDashing = false;
                cooldownTimer = dashCooldown;
            }
        }
        else
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");     
        float moveUpDown = 0f;

        if (Input.GetKey(KeyCode.E)) moveUpDown = 1f;
        else if (Input.GetKey(KeyCode.Q)) moveUpDown = -1f;

        Vector3 inputDirection = transform.forward * moveVertical +
                                 transform.right * moveHorizontal +
                                 transform.up * moveUpDown;

        Vector3 moveVelocity = inputDirection.normalized * movementSpeed;

        Vector3 currentVelocity = rb.velocity;
        Vector3 verticalVelocity = Vector3.Project(currentVelocity, Vector3.up); 
        rb.velocity = moveVelocity + verticalVelocity;
    }

    void StartDash()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        float moveUpDown = 0f;

        if (Input.GetKey(KeyCode.E)) moveUpDown = 1f;
        else if (Input.GetKey(KeyCode.Q)) moveUpDown = -1f;

        Vector3 inputDir = transform.forward * moveVertical +
                           transform.right * moveHorizontal +
                           transform.up * moveUpDown;

        if (inputDir != Vector3.zero)
        {
            dashDirection = inputDir.normalized;
            isDashing = true;
            dashTimer = dashDuration;
        }
    }
}
