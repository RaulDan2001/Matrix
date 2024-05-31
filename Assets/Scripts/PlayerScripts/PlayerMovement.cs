using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Movement")]
    private float MoveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Jumping")]
    public float JumpForce;
    public float JumpCooldown;
    public float AirMultiplier;
    bool ReadyToJump;

    [Header("KeyBinds")]
    public KeyCode jumpkey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;
    
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 MoveDirection;

    Rigidbody rb;

    public Animator gunAnimator;

    public MovementState state;

    public enum MovementState 
    {
        walking,
        sprinting,
        air
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        ReadyToJump = true;
        
    }

    private void Update()
    {
        //verificam daca jucatorul este pe pamant
        //trimitem o raza inspre pamant de la player si daca colideaza cu pamantul atunci e pe pamant
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);

        MyInput();
        SpeedControl();
        StateHandler();

        //drag handling 
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    
    }

    private void FixedUpdate()
    {
        MovePlayer();  
    }

    private void MyInput()
    {
        //colectam comenzi de la tastatura
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //cand sa sarim 
        if(Input.GetKey(jumpkey) && ReadyToJump && grounded)
        {
            ReadyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), JumpCooldown);
            //pentru ca playerul sa continue sa sara daca tinem butonul de sarit apasat
        }
    }

    private void StateHandler()
    {
        //Modul - sprint
        if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            MoveSpeed = sprintSpeed;
            gunAnimator.SetBool("Sprint",true);
            gunAnimator.SetBool("IsScoped", false);
        }

        //Modul - plimbare
        else if (grounded)
        {
            state = MovementState.walking;
            MoveSpeed = walkSpeed;
            gunAnimator.SetBool("Sprint", false);
            
        }

        //Modul - saritura
        else
        {
            state = MovementState.air;
        }
    }

    private void MovePlayer()
    {
        //calcularea directiei de miscare 
        MoveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        //pe pamant 
        if (grounded)
            rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);

        //in aer
        else if (!grounded)
            rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f * AirMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limitam velocitatea daca este nevoie
        if(flatVelocity.magnitude > MoveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * MoveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    public void Jump()
    {
        //resetam velocitatea y
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        ReadyToJump = true;
    }

}
