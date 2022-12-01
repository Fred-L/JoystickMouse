// FIRST PERSON MOVEMENT in 10 MINUTES - Unity Tutorial
// https://www.youtube.com/watch?v=f473C43s8nE&list=RDCMUCIWlCE2kt0RXCJLRp8HjhiQ&index=1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Controller messageController;
    public string message;

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    bool readyToJump = true;
    bool joyJump = true;
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space; //KeyCode.JoystickPress

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    int joyNum;

    Vector3 moveDirection;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        messageController = GameObject.Find("Player").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        message = messageController.message;
        //Debug.Log(message);

        //Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        PlayerInput();
        SpeedControl();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //Debug.Log(horizontalInput);
        //Debug.Log(verticalInput);
        
        //if (message == "A1 Up")
        //{
        //    horizontalInput = 1;
        //    Debug.Log(message);
        //}
        //else
        //    horizontalInput = 0;

        //if (message == "A1 Down")
        //{
        //    horizontalInput = -1;
        //    Debug.Log(message);
        //}
        //else
        //    horizontalInput = 0;

        //if (message == "A2 Up")
        //{
        //    verticalInput = 1;
        //    Debug.Log(message);
        //}
        //else
        //    verticalInput = 0;
        //if (message == "A2 Down")
        //{
        //    verticalInput = -1;
        //    Debug.Log(message);
        //}
        //else
        //    verticalInput = 0;


        if (message == "Joystick Input")
            joyJump = true;
        else
            joyJump = false;

        if (joyJump && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
