using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hell : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float jumpForce = 10.0f;
    public float crouchSpeed = 2.5f;
    public float crouchHeight = 0.5f;

    private CharacterController characterController;
    private float currentSpeed;
    private bool isCrouching = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    private void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput).normalized);

        // Walking and Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = isCrouching ? crouchSpeed : walkSpeed;
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpForce;
        }

        // Crouching
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCrouch();
        }

        // Apply movement
        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching;

        if (isCrouching)
        {
            characterController.height = crouchHeight;
        }
        else
        {
            characterController.height = 2.0f; // Default height
        }
    }
}