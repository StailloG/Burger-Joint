using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float hInput;
    private float vInput;
    private CharacterController charController;
    private const float Gravity = 9.81f;
    private float vSpeed;
    void Awake()
    {
        charController = GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {
       HandleMovement();
       
    }

    private void HandleMovement()
    {
        //call horizontal & vertical inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        Vector3 velocity = transform.forward * (vInput * speed);
        if (charController.isGrounded)
            vSpeed = 0;

        vSpeed -= Gravity * Time.deltaTime;
        velocity.y = vSpeed; 

        //mouse movement
        charController.Move(velocity *  Time.deltaTime);
        
    }

    //Script to help other systems know when the player is moveing
    public bool IsMoving()
    {
        return charController.velocity != Vector3.zero;
    }
    
}
