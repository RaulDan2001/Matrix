using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Movement")]

    public float MoveSpeed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 MoveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calcularea directiei de miscare 
        MoveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
    }
}
