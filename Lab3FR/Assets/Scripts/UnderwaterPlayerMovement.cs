using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float verticalSpeed = 3f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.drag = 2f; 
    }

    void FixedUpdate()
    {
        // Get movement input
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveVertical = Input.GetAxis("Vertical");     // W/S or Up/Down
        float moveUpDown = 0f;

        if (Input.GetKey(KeyCode.E))
        {
            moveUpDown = 1f;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            moveUpDown = -1f;
        }

        // Movement direction in world space
        Vector3 movement = transform.forward * moveVertical +
                           transform.right * moveHorizontal +
                           transform.up * moveUpDown;

        rb.velocity = movement * movementSpeed;
    }
}

